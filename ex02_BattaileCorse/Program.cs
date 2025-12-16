using ex02_BattaileCorse.Classes;
using Microsoft.VisualBasic.FileIO;

namespace ex02_BattaileCorse
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            List<Carte> CartesAjouer = new List<Carte>();
            Anneau<Joueur> ListeJoueurs = new Anneau<Joueur>();


            Paquet PaquetBatailleCorse = new Paquet(CartesAjouer, ListeJoueurs);
            CartesAjouer = PaquetBatailleCorse.MelangerCarte();
            PaquetBatailleCorse.AfficherCarte(CartesAjouer);


            Joueur joueur01 = new Joueur("Julie", new List<Carte> { });
            ListeJoueurs.AjouterALaFin(joueur01);
            Joueur joueur02 = new Joueur("Maxime", new List<Carte> { });
            ListeJoueurs.AjouterALaFin(joueur02);
            Joueur joueur03 = new Joueur("Melanie", new List<Carte> { });
            ListeJoueurs.AjouterALaFin(joueur03);

            PaquetBatailleCorse.DistribueToutesLesCartes(CartesAjouer, ListeJoueurs);

            /*joueur01.AfficherSesCartes();
            joueur02.AfficherSesCartes();
            joueur03.AfficherSesCartes();

            joueur01.TirerUneCarte();
            joueur01.AfficherSesCartes();*/

            BatailleCorse nouvelleBatailleCorse = new BatailleCorse(ListeJoueurs);
            nouvelleBatailleCorse.PlayGame();

            // Pour lancer

            // 1 classe anneau + 1 classe maillon
            // 
            // on passe par la classe anneau pour récupérer le maillon
        }
    }
}
