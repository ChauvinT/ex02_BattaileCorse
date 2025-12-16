using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex02_BattaileCorse.Classes
{
    internal class BatailleCorse
    {
        Anneau<Joueur> ListeJoueurs;
        Anneau<Carte> ListeCartesDefaussees = new Anneau<Carte>();
        public int indexJoueurEnCours = 0;

        public BatailleCorse(Anneau<Joueur>listeJoueurs ) 
        {
            ListeJoueurs = listeJoueurs;
        }

        public void PlayGame()
        {
            
            while (ListeJoueurs.NbElements > 1)
            {
                JouerTour();
            }

            Console.WriteLine($"Le Joueur {ListeJoueurs.RetirerPremier().Nom} remporte la partie");
        }

        public void JouerTour()
        {
            var joueurEnCours = ListeJoueurs.RetirerPremier();
            
            if (joueurEnCours.Cartes.Count() == 0)
            {
                Console.WriteLine($"Le Joueur {joueurEnCours.GetNomJoueur()} ne possède plus de carte : il est éliminé\n");
                return;
            }

            var carteTiree = new Carte(new CarteCouleur(), new CarteValeur());
            try
            {
                carteTiree = joueurEnCours.TirerUneCarte();
                ListeCartesDefaussees.AjouterALaFin(carteTiree);
            }
            catch
            {
                Console.WriteLine($"Le Joueur {joueurEnCours.GetNomJoueur()} ne possède plus de carte : il est éliminé\n");
                return;
            }


            Console.WriteLine($"{joueurEnCours.GetNomJoueur()} joue : {carteTiree.ToString()}");


            if ((int) carteTiree.Valeur > (int) CarteValeur.DIX)
            {
                RealiserDefi(carteTiree, joueurEnCours);
            }

            ListeJoueurs.AjouterALaFin(joueurEnCours);
        }

        public void RealiserDefi(Carte carteTiree, Joueur joueurEnCours)
        {
            var carteProchainJoueur = new Carte(new CarteCouleur(), new CarteValeur());
            int nbTentatives = carteTiree.GetTentativesAuthorisees();

            //Console.WriteLine("DEFI Carte : " + carteTiree.ToString());
            //Console.WriteLine("Nb tentatives :" + nbTentatives);

            bool defiRemporte = false;
            var prochainJoueur = ListeJoueurs.RetirerPremier();

            while (!defiRemporte && nbTentatives > 0)
            {        
                try{
                    carteProchainJoueur = prochainJoueur.TirerUneCarte();
                    ListeCartesDefaussees.AjouterALaFin(carteProchainJoueur);
                }
                catch
                {
                    Console.WriteLine($"Le Joueur {prochainJoueur.GetNomJoueur()} ne possède plus de carte : il est éliminé \n");
                    return;
                }

                Console.WriteLine($"{prochainJoueur.GetNomJoueur()} joue : {carteProchainJoueur.ToString()}");

                if ((int)carteProchainJoueur.Valeur > (int)CarteValeur.DIX)
                {
                    defiRemporte = true;
                }
                else
                {
                    nbTentatives--;
                }
            }

            // le jouer qui a lancé le défi remporte les cartes défaussées;
            if (!defiRemporte)
            {
                Console.WriteLine($"Le défi est perdu ! {joueurEnCours.GetNomJoueur()} remporte {ListeCartesDefaussees.NbElements} cartes.\n");
                while(ListeCartesDefaussees.NbElements >0)
                {
                    joueurEnCours.Cartes.Add(ListeCartesDefaussees.RetirerPremier());
                }
            }
            else
            {
                RealiserDefi(carteProchainJoueur, prochainJoueur);
            }
        }
    }
}
