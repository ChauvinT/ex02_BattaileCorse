using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex02_BattaileCorse.Classes
{
    public class BatailleCorse
    {
        public List<string> ListeCartes;
        public BatailleCorse(List<string> listeCartes, List<Joueur> listeJoueurs) 
        { 
            ListeCartes = listeCartes;
        }

        // Initialise puis mélange un nouveau paquet de carte
        public List<String> MelangerCarte()
        {
            List<string> listCouleur    = new List<string>();
            List<string> listValeur     = new List<string>();
            List<string> listPaquet     = new List<string>();
            List<string> listMelangees  = new List<string>();

            foreach (var color in Enum.GetValues(typeof(CarteCouleur)))
            {
                foreach (var value in Enum.GetValues(typeof(CarteValeur)))
                {
                    listPaquet.Add(value.ToString() + " de " + color.ToString());
                }
            }

            Random randomPaquet = new Random();
            var shuffledListePaquet = listPaquet.OrderBy(item => randomPaquet.Next()).ToList();
            foreach (var item in shuffledListePaquet)
            {
                listMelangees.Add(item.ToString());
            }

            return listMelangees;
        }

        public void AfficherCarte(List<string> listPaquet)
        {
            foreach (var item in listPaquet)
            {
                Console.WriteLine(item);
            }
        }

        public bool DistribueUneCarte(List<String> listeCartes, Joueur joueur)
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

        public bool DistribueToutesLesCartes(List<String> listeCartes, List<Joueur> listeJoueurs)
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

        public List<string> getListeCarte()
        {
            return ListeCartes;
        }
    }
}
