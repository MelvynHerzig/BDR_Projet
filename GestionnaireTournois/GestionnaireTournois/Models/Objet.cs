using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionnaireTournois.Models
{
    public class Objet
    {
        private int id;
        private string nom;

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }

        public Objet(int id, string nom)
        {
            Id = id;
            Nom = nom;
        }

        public override string ToString()
        {
            return Nom;
        }

        public static List<Objet> GetObjets()
        {
            return DataBaseConnector.GetObjets();
        }

        public void AjouterInDB()
        {
            DataBaseConnector.AjouterObjet(this);
        }
    }
}
