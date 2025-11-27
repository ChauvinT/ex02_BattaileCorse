using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex02_BattaileCorse.Classes
{
    public class Joueur
    {
        public String Nom {  get; set; }
        public List<String> Cartes = new List<String>();
        public Joueur(string nom, List<string> cartes)
        {
            Nom = nom;
            Cartes = cartes;
        }
        public void AfficherSesCartes()
        {
            Console.WriteLine($"Le Joueur {GetNomJoueur()} possède les cartes suivantes :");
            foreach (var carte in Cartes)
            {
                Console.WriteLine(carte);
            }
            Console.WriteLine();
        }

        public void TirerUneCarte()
        {
            Console.WriteLine($"Le Joueur {GetNomJoueur()} a tiré la carte : {Cartes[0]} (celle-ci est défaussée) \n");
            Cartes.RemoveAt(0);
        }

        public String GetNomJoueur()
        {
            return Nom;
        }
    }
}
