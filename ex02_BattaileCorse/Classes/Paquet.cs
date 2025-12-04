using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex02_BattaileCorse.Classes
{
    public class Paquet
    {
        public List<Carte> ListeCartes;
        public Paquet(List<Carte> listeCartes, List<Joueur> listeJoueurs) 
        { 
            ListeCartes = listeCartes;
        }

        // Initialise puis mélange un nouveau paquet de carte
        public List<Carte> MelangerCarte()
        {
            List<Carte> listPaquet     = new List<Carte>();
            List<Carte> listMelangees  = new List<Carte>();

            foreach (var color in Enum.GetValues(typeof(CarteCouleur)))
            {
                foreach (var value in Enum.GetValues(typeof(CarteValeur)))
                {
                    listPaquet.Add(new Carte((CarteCouleur) color, (CarteValeur) value));
                }
            }

            Random randomPaquet = new Random();
            var shuffledListePaquet = listPaquet.OrderBy(item => randomPaquet.Next()).ToList();
            foreach (var item in shuffledListePaquet)
            {
                listMelangees.Add(item);
            }

            return listMelangees;
        }

        public void AfficherCarte(List<Carte> listPaquet)
        {
            foreach (var item in listPaquet)
            {
                Console.WriteLine(item);
            }
        }

        public bool DistribueUneCarte(List<Carte> listeCartes, Joueur joueur)
        {
            if (listeCartes.Count == 0)
            {
                Console.WriteLine("Il n'y a plus de cartes à distribuer \n");
                return false;
            }
            
            joueur.Cartes.Add(listeCartes[0]);
            listeCartes.RemoveAt(0);

            return true;
        }

        public bool DistribueToutesLesCartes(List<Carte> listeCartes, List<Joueur> listeJoueurs)
        {
            if (listeCartes.Count == 0)
            {
                Console.WriteLine("Il n'y a plus de cartes à distribuer \n");
                return false;
            }

            while(listeCartes.Count > 0)
            {
                foreach (var unJoueur in listeJoueurs)
                {
                    if (DistribueUneCarte(listeCartes, unJoueur) == false)
                    {
                        break;
                    }
                }
            }
            Console.WriteLine("Toutes les cartes ont été distribué \n");
            return true;
        }

        public List<Carte> getListeCarte()
        {
            return ListeCartes;
        }
    }
}
