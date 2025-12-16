using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex02_BattaileCorse.Classes
{
    public class Maillon<T>
    {
        public readonly T Valeur;
        public Maillon<T> Suivant;

        public Maillon(T valeur, Maillon<T> suivant = null)
        {
            Valeur = valeur;
            Suivant = suivant;
        }
    }
}
