using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex02_BattaileCorse.Classes
{
    public class Carte
    {
        public CarteCouleur Couleur;
        public CarteValeur Valeur;
        public Carte(CarteCouleur couleur, CarteValeur valeur) 
        {
            Couleur = couleur;
            Valeur = valeur;
        }

        public override string ToString()
        {
            return Valeur.ToString() + " de " + Couleur.ToString();
        }

        public int GetTentativesAuthorisees()
        {
            int nbTentatives = 1;

            switch (Valeur)
            {
                case CarteValeur.VALET:
                    nbTentatives = 4;
                    break;
                case CarteValeur.DAME:
                    nbTentatives = 3;
                    break;
                case CarteValeur.ROI:
                    nbTentatives = 2;
                    break;
                case CarteValeur.AS:
                    nbTentatives = 1;
                    break;
                default:
                    nbTentatives = 1;
                    break;
            }
            return nbTentatives;
        }
    }
}
