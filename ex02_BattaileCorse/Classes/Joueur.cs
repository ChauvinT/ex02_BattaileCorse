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
        public List<Carte> Cartes = new List<Carte>();
        public Joueur(string nom, List<Carte> cartes)
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

        public Carte TirerUneCarte()
        {
            if (Cartes.Count == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(Cartes));
            }
            var CarteTiree = Cartes[0];

            Cartes.RemoveAt(0);

            return CarteTiree;
        }

        public String GetNomJoueur()
        {
            return Nom;
        }
    }
}
