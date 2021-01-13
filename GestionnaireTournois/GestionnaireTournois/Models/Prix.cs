using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionnaireTournois.Models
{
    class Prix
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

        public List<Objet> GetObjets()
        {
            return DataBaseConnector.GetObjetsPrix(this);
        }
    }
}
