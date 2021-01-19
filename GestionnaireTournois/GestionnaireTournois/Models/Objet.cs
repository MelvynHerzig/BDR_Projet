/*
 -------------------------------------------------------------------------------
 Projet      : Gestionnaire de tournois Rocket League
 Fichier     : Objet.cs
 Auteur(s)   : Berney Alec, Forestier Quentin, Herzig Melvyn
 Version     : 1.0.0

 But         : Modèle représentant un objet. 
               Il reprend chaque champ de la table objet de la base de données.
               Contient différentes méthodes en lien avec l'objet demandant un 
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

        /// <summary>
        /// Obtient la liste des objets existants dans la base de données
        /// </summary>
        /// <returns>Liste contenant les objets de la base de données</returns>
        public static List<Objet> GetObjets()
        {
            return DataBaseConnector.GetObjets();
        }

        /// <summary>
        /// Ajoute l'objet instancié dans la base de données
        /// </summary>
        public void AjouterInDB()
        {
            DataBaseConnector.AjouterObjet(this);
        }
    }
}
