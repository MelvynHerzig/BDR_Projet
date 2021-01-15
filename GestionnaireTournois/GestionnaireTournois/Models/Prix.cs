using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionnaireTournois.Models
{
    public class Prix
    {
        private int id;
        private double montantArgent;

        public int Id { get => id; set => id = value; }
        public double MontantArgent { get => montantArgent; set => montantArgent = value; }

        public Prix(int id, double montantArgent)
        {
            Id = id;

            MontantArgent = montantArgent;
        }


        public void CreerInDB()
        {
            Id = DataBaseConnector.CreerPrix(this);
        }
        public List<Objet> GetObjets()
        {
            return DataBaseConnector.GetObjetsPrix(this);
        }

        public void AjouterObjets(List<Objet> objets)
        {
            RetirerObjets(objets);
            objets.RemoveAll(o1 => GetObjets().Any(o2 => o1.Id == o2.Id));
            DataBaseConnector.AjouterObjetsPrix(this, objets);
        }

        public void ModifierMontantArgent(double montantArgent)
        {
            DataBaseConnector.ModifierMontantArgentPrix(this, montantArgent);
        }
        private void RetirerObjets(List<Objet> objets)
        {
            List<Objet> objetsAEnlever = GetObjets();
            objetsAEnlever.RemoveAll(o1 => objets.Any(o2 => o1.Id == o2.Id));
            DataBaseConnector.RetirerObjetsPrix(this, objetsAEnlever);
        }
    }
}
