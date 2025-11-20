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
            Console.WriteLine("The values of the Colors Enum are:");
            foreach (var value in Enum.GetValues(typeof(CarteCouleur)))
            {
                Console.WriteLine(value);
                listCouleur.Add(value.ToString());
            }


            Console.WriteLine();

            List<string> listValeur = new List<string>();
            Console.WriteLine("The values of the Styles Enum are:");
            foreach (var value in Enum.GetValues(typeof(CarteValeur)))
            {
                Console.WriteLine(value);
                listValeur.Add(value.ToString());
            }

            Console.WriteLine();


            
            Random rndCouleur = new Random();
            var shuffledListCouleur = listCouleur.OrderBy(item => rndCouleur.Next()).ToList();
            Console.WriteLine("Shuffled List:");
            foreach (var item in shuffledListCouleur)
            {
                Console.Write(item + " ");
            }

            Random rndValeur = new Random();
            var shuffledListValeur = listValeur.OrderBy(item => rndValeur.Next()).ToList();
            Console.WriteLine("Shuffled List:");
            foreach (var item in shuffledListValeur)
            {
                Console.Write(item + " ");
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
