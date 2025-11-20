using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex02_BattaileCorse.Classes
{
    public class Anneau<T>
    {
        private int NbElements;

        public T Valeur { get; set; }

        public Anneau<T> Premier { get; private set; }

        public Anneau<T> Dernier;

        public Anneau()
        {
 
        }

        public void AjouterALaFin(T element)
        {
            if (Premier == null)
            {
                Premier = new Anneau<T> { Valeur = element };
            }
            else
            {

            }
        }

        public void Retirer(T element)
        {
            if (Premier == null)
            {
                return;
            }
            else
            {

            }
        }
    }
}
