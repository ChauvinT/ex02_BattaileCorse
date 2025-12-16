using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ex02_BattaileCorse.Classes
{
    public class Anneau<T> where T : class
    {
        public int NbElements {get; private set;}

        private Maillon<T> premierMaillon;

        public Anneau()
        {
            this.NbElements = 0;
            premierMaillon = null;
        }

        public void AjouterALaFin(T element)
        {
            var maillon = premierMaillon.Suivant;
            while(maillon.Suivant != null)
            {
                maillon = maillon.Suivant;
            }

            maillon.Suivant = new Maillon<T>(element);
        }

        public void Retirer(T element)
        {            
            var maillon = premierMaillon.Suivant;
            while(maillon.Suivant.Valeur != element)
            {
                maillon = maillon.Suivant;
            }

            maillon.Suivant = maillon.Suivant.Suivant;
        }

        public T RetirerPremier()
        {
            var premier = premierMaillon.Valeur;

            premierMaillon = premierMaillon.Suivant;
            
            return premier;
        }
    }
}
