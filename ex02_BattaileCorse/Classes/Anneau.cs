using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ex02_BattaileCorse.Classes
{
    public class Anneau<T>
    {
        private int NbElements;

        public Maillon<T> Maillon;

        public LinkedList<T> anneau = new LinkedList<T>();
        public Anneau<T> suivant;

        public Anneau()
        {
            this.NbElements = 0;
            suivant = null;
        }

        public void AjouterALaFin(T element)
        {
            anneau.AddLast(element);
        }

        public void Retirer(T element)
        {
            anneau.Remove(element);
        }

        public void RetirerPremier()
        {
            anneau.RemoveFirst();
        }
    }
}
