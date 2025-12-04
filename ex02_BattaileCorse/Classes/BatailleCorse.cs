using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex02_BattaileCorse.Classes
{
    internal class BatailleCorse
    {
        List<Joueur> ListeJoueurs = new List<Joueur>();
        List<Carte> ListeCartesDefaussees = new List<Carte>();
        public int indexJoueurEnCours = 0;

        public BatailleCorse(List<Joueur>listeJoueurs ) 
        {
            ListeJoueurs = listeJoueurs;
        }

        public void PlayGame()
        {
            
            while (ListeJoueurs.Count() > 1)
            {
                JouerTour();
            }
            Console.WriteLine($"Le Joueur {ListeJoueurs[0].GetNomJoueur()} remporte la partie");
        }

        public void JouerTour()
        {
            if (indexJoueurEnCours >= ListeJoueurs.Count())
            {
                indexJoueurEnCours = 0;
            }

            var joueurEnCours = ListeJoueurs[indexJoueurEnCours].GetNomJoueur();
            
            if (ListeJoueurs[indexJoueurEnCours].Cartes.Count() == 0)
            {
                Console.WriteLine($"Le Joueur {joueurEnCours} ne possède plus de carte : il est éliminé\n");
                ListeJoueurs.RemoveAt(indexJoueurEnCours);
                return;
            }

            var carteTiree = new Carte(new CarteCouleur(), new CarteValeur());
            try
            {
                carteTiree = ListeJoueurs[indexJoueurEnCours].TirerUneCarte();
                ListeCartesDefaussees.Add(carteTiree);
            }
            catch
            {
                Console.WriteLine($"Le Joueur {joueurEnCours} ne possède plus de carte : il est éliminé\n");
                ListeJoueurs.RemoveAt(indexJoueurEnCours);
                return;
            }


            Console.WriteLine($"{joueurEnCours} joue : {carteTiree.ToString()}");


            if ((int) carteTiree.Valeur > (int) CarteValeur.DIX)
            {
                RealiserDefi(carteTiree);
            }
            indexJoueurEnCours++;
        }

        public void RealiserDefi(Carte carteTiree)
        {
            var carteProchainJoueur = new Carte(new CarteCouleur(), new CarteValeur());
            int nbTentatives = carteTiree.GetTentativesAuthorisees();

            //Console.WriteLine("DEFI Carte : " + carteTiree.ToString());
            //Console.WriteLine("Nb tentatives :" + nbTentatives);

            int indexProchainJoueur = indexJoueurEnCours+1;
            bool defiRemporte = false;

            if (indexProchainJoueur >= ListeJoueurs.Count())
            {
                indexProchainJoueur = 0;
            }

            while (!defiRemporte && nbTentatives > 0)
            {        
                try{
                    carteProchainJoueur = ListeJoueurs[indexProchainJoueur].TirerUneCarte();
                    ListeCartesDefaussees.Add(carteProchainJoueur);
                }
                catch
                {
                    Console.WriteLine($"Le Joueur {ListeJoueurs[indexProchainJoueur].GetNomJoueur()} ne possède plus de carte : il est éliminé \n");
                    ListeJoueurs.RemoveAt(indexProchainJoueur);
                    return;
                }

                Console.WriteLine($"{ListeJoueurs[indexProchainJoueur].GetNomJoueur()} joue : {carteProchainJoueur.ToString()}");

                if ((int)carteProchainJoueur.Valeur > (int)CarteValeur.DIX)
                {
                    defiRemporte = true;
                }
                else
                {
                    nbTentatives--;
                    if (indexProchainJoueur >= ListeJoueurs.Count())
                    {
                        indexProchainJoueur = 0;
                    }
                }
            }

            // le jouer qui a lancé le défi remporte les cartes défaussées;
            if (!defiRemporte)
            {
                foreach (var carte in ListeCartesDefaussees)
                {
                    ListeJoueurs[indexJoueurEnCours].Cartes.Add(carte);
                }
                Console.WriteLine($"Le défi est perdu ! {ListeJoueurs[indexJoueurEnCours].GetNomJoueur()} remporte {ListeCartesDefaussees.Count} cartes.\n");
                ListeCartesDefaussees.Clear();
            }

            indexJoueurEnCours = indexProchainJoueur;
            if (defiRemporte) 
            {
                RealiserDefi(carteProchainJoueur);
            }
        }
    }
}
