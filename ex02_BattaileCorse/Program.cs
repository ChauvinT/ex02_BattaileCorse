using ex02_BattaileCorse.Classes;
using Microsoft.VisualBasic.FileIO;

namespace ex02_BattaileCorse
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            List<string> CartesAjouer = new List<string>();
            List<Joueur> ListeJoueurs = new List<Joueur>();


            BatailleCorse PaquetBatailleCorse = new BatailleCorse(CartesAjouer, ListeJoueurs);
            CartesAjouer = PaquetBatailleCorse.MelangerCarte();
            PaquetBatailleCorse.AfficherCarte(CartesAjouer);


            Joueur joueur01 = new Joueur("Thomas", new List<String> { });
            ListeJoueurs.Add(joueur01);
            Joueur joueur02 = new Joueur("Rémi", new List<String> { });
            ListeJoueurs.Add(joueur02);

            PaquetBatailleCorse.DistribueToutesLesCartes(CartesAjouer, ListeJoueurs);

            joueur01.AfficherSesCartes();

            joueur02.AfficherSesCartes();

            joueur01.TirerUneCarte();
            joueur01.AfficherSesCartes();

            // 1 classe anneau + 1 classe maillon
            // 
            // on passe par la classe anneau pour récupérer le maillon
        }
    }
}
