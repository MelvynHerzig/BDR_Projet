/*
 -------------------------------------------------------------------------------
 Projet      : Gestionnaire de tournois Rocket League
 Fichier     : Prix.cs
 Auteur(s)   : Berney Alec, Forestier Quentin, Herzig Melvyn
 Version     : 1.0.0

 But         : Modèle représentant un prix. 
               Il reprend chaque champ de la table Prix de la base de données.
               Contient différentes méthodes en lien avec le prix demandant un 
               accès à la base de données

 Remarque(s) : /

 -------------------------------------------------------------------------------
 */
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

        #region Récupération de données en rapport avec le prix

        public List<Objet> GetObjets()
        {
            return DataBaseConnector.GetObjetsPrix(this);
        }

        #endregion


        #region Modification de données en rapport avec le prix

        /// <summary>
        /// Ajout le prix instancié dans la base de données
        /// </summary>
        public void CreerInDB()
        {
            Id = DataBaseConnector.CreerPrix(this);
        }


        /// <summary>
        /// Ajoute les objets pas encore en lien avec le prix
        /// </summary>
        /// <param name="objets">Liste des objets à être en lien avec le prix</param>
        public void AjouterObjets(List<Objet> objets)
        {
            RetirerObjets(objets);
            objets.RemoveAll(o1 => GetObjets().Any(o2 => o1.Id == o2.Id));
            DataBaseConnector.AjouterObjetsPrix(this, objets);
        }

        /// <summary>
        /// Modifie le montant d'argents associés au prix
        /// </summary>
        /// <param name="montantArgent"></param>
        public void ModifierMontantArgent(double montantArgent)
        {
            DataBaseConnector.ModifierMontantArgentPrix(this, montantArgent);
        }

        /// <summary>
        /// Retire les objets qui sont déjà en lien avec le prix
        /// </summary>
        /// <param name="objets">Objets a retirer</param>
        private void RetirerObjets(List<Objet> objets)
        {
            List<Objet> objetsAEnlever = GetObjets();
            objetsAEnlever.RemoveAll(o1 => objets.Any(o2 => o1.Id == o2.Id));
            DataBaseConnector.RetirerObjetsPrix(this, objetsAEnlever);
        }

        #endregion

    }
}
