using Microsoft.VisualBasic.FileIO;

namespace ex02_BattaileCorse
{
    internal class Program
    {
        public enum CarteCouleur
        {
            COEUR,
            PIQUE,
            CARREAU,
            TREFLE
        }
        public enum CarteValeur
        {
            SEPT,
            HUIT,
            NEUF,
            DIX,
            VALET,
            DAME,
            ROI,
            AS
        }

        public static void Main(string[] args)
        {
            List<string> listCouleur = new List<string>();
            List<string> listValeur = new List<string>();
            List<string> listPaquet = new List<string>();

            foreach (var color in Enum.GetValues(typeof(CarteCouleur)))
            {
                foreach (var value in Enum.GetValues(typeof(CarteValeur)))
                {
                    listPaquet.Add(value.ToString() + " de " + color.ToString());
                }
            }

            // Affichage du paquet 
            /*foreach (var item in listPaquet)
            {
                Console.WriteLine(item);
            }*/

            Random randomPaquet = new Random();
            var shuffledListePaquet = listPaquet.OrderBy(item => randomPaquet.Next()).ToList();
            Console.WriteLine("Shuffled List:");
            foreach (var item in shuffledListePaquet)
            {
                Console.WriteLine(item);
            }



            // gérer l'init du paquet de cartes

            // créer 1 enum pour les coueleurs et 1 enum pour les valeurs
            // puis utiliser Enum.GetValues()
            // cela va créer

            // shuffle la liste

            // console.writeline sur tout ce qu'il y a dans le jeu de carte
            // mélanger 
            // puis réafficher une fois mélangé

            // 1 classe anneau + 1 classe maillon
            // 
            // on passe par la classe anneau pour récupérer le maillon
        }
    }
}
