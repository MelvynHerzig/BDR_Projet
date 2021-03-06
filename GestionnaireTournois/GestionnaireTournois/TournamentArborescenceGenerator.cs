﻿/*
 -------------------------------------------------------------------------------
 Projet      : Gestionnaire de tournois Rocket League
 Fichier     : TournamentArboresceceGenerator.cs
 Auteur(s)   : Berney Alec, Forestier Quentin, Herzig Melvyn
 Version     : 1.0.0

 But         : Utilitaire pour créer l'arborescence d'un tournoi
 
Remarque(s) : Code repris et adapté de : 
              https://stackoverflow.com/questions/9732347/c-sharp-how-to-generate-a-tournament-bracket-html-table
              
              Le but du cours n'étant pas l'affichage en C#, nous nous sommes permis 
              de ne pas approfondir plus que nécessaire la compréhension du code repris

 -------------------------------------------------------------------------------
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionnaireTournois.Models;
using MySql.Data.MySqlClient;

namespace GestionnaireTournois
{
    public class TournamentArborescenceGenerator
    {

        /// <summary>
        /// Génère le code HTML de l'arborescence du tournoi passé en paramètre
        /// </summary>
        /// <param name="t">Tournoi dont il faut créer l'arborescence</param>
        /// <param name="actionSerie">Texte a afficher dans les boutons des séries</param>
        /// <returns>Le code HTML de l'arborescence sous forme de string</returns>
        public static string Generate(Tournoi t, string actionSerie)
        {

            int match_white_span;
            int match_span;
            int position_in_match_span;
            int column_stagger_offset;
            int effective_row;
            int col_match_num;
            int effective_serie_id;
            int rounds = t.GetNbTours();
            int teams = t.NbEquipesMax;
            int max_rows = teams << 1;
            StringBuilder HTMLTable = new StringBuilder();

            HTMLTable.AppendLine("<style type=\"text/css\">");
            HTMLTable.AppendLine("    .thd {background: rgb(220,220,220); font: bold 10pt Arial; text-align: center;}");
            HTMLTable.AppendLine("    .team {color: white; background: rgb(100,100,100); font: bold 10pt Arial; border-right: solid 2px black;}");
            HTMLTable.AppendLine("    .winner {color: white; background: rgb(60,60,60); font: bold 10pt Arial;}");
            HTMLTable.AppendLine("    .vs {font: bold 7pt Arial; border-right: solid 2px black; text-align : center;}");
            HTMLTable.AppendLine("    td, th {padding: 3px 15px; border-right: dotted 2px rgb(200,200,200); text-align: right;}");
            HTMLTable.AppendLine("    h1 {font: bold 14pt Arial; margin-top: 24pt;}");
            HTMLTable.AppendLine("    .vs button {border: 1px solid #e7e7e7; background-color:white; text-align: center; text-decoration: none; display: inline-block; font-size: 9px; border-radius: 8px;}");
            HTMLTable.AppendLine("    .vs button:hover {background-color: #e7e7e7;}");
            HTMLTable.AppendLine("</style>");

            HTMLTable.AppendLine("<h1>Tournoi : " + t.Nom + "</h1>");
            HTMLTable.AppendLine("<table border=\"0\" cellspacing=\"0\">");



            for (int row = 0; row <= max_rows; row++)
            {
                HTMLTable.AppendLine("    <tr>");
                for (int col = 1; col <= rounds + 1; col++)
                {
                    match_span = 1 << (col + 1);
                    match_white_span = (1 << col) - 1;
                    column_stagger_offset = match_white_span >> 1;

                    int noTour = (rounds - col + 1);

                    if (row == 0)
                    {
                        if (col <= rounds)
                        {
                            HTMLTable.AppendLine("        <th class=\"thd\">Tour " + noTour + "</th>");
                        }
                        else
                        {
                            HTMLTable.AppendLine("        <th class=\"thd\">Vainqueur</th>");
                        }
                    }
                    else if (row == 1)
                    {
                        HTMLTable.AppendLine("        <td class=\"white_span\" rowspan=\"" + (match_white_span - column_stagger_offset) + "\">&nbsp;</td>");
                    }
                    else
                    {
                        effective_row = row + column_stagger_offset;
                        if (col <= rounds)
                        {
                            position_in_match_span = effective_row % match_span;
                            position_in_match_span = (position_in_match_span == 0) ? match_span : position_in_match_span;
                            col_match_num = (effective_row / match_span) + ((position_in_match_span < match_span) ? 1 : 0);

                            effective_serie_id = col_match_num;

                            Tour tour = t.GetTourByNo(noTour);
                            Serie serie = tour.GetSerieById(effective_serie_id);

                            if ((position_in_match_span == 1) && (effective_row % match_span == position_in_match_span))
                            {
                                HTMLTable.AppendLine("        <td class=\"white_span\" rowspan=\"" + match_white_span + "\">&nbsp;</td>");
                            }
                            else if ((position_in_match_span == ((match_span >> 1) + 1)) && (effective_row % match_span == position_in_match_span))
                            {
                                string disabled = "";
                                if(serie == null || serie.GetEquipes() == null || serie.GetEquipes().Contains(null))
                                {
                                    disabled = "disabled";
                                }
                                HTMLTable.AppendLine("        <td class=\"vs\" rowspan=\"" + match_white_span + "\"> VS <br><button " + disabled + " name=\"" + t.Id + ";" + noTour + ";" + effective_serie_id + "\">" + actionSerie + "</button></td>");
                            }
                            else
                            {
                                if (serie != null)
                                {
                                    List<Equipe> equipes = serie.GetEquipes();

                                    if ((position_in_match_span == (match_span >> 1)) && (effective_row % match_span == position_in_match_span))
                                    {
                                        HTMLTable.AppendLine("        <td class=\"team\">" + (equipes[0] == null ? "N.A" : equipes[0].Acronyme) + "</td>");
                                    }
                                    else if ((position_in_match_span == match_span) && (effective_row % match_span == 0))
                                    {
                                        HTMLTable.AppendLine("        <td class=\"team\">" + (equipes[1] == null ? "N.A" : equipes[1].Acronyme) + "</td>");
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (row == column_stagger_offset + 2)
                            {
                                Equipe gagnant = t.GetGagnant();


                                HTMLTable.AppendLine("        <td class=\"winner\">" + (gagnant == null ? "N.A" : gagnant.Acronyme) + "</td>");
                            }
                            else if (row == column_stagger_offset + 3)
                            {
                                HTMLTable.AppendLine("        <td class=\"white_span\" rowspan=\"" + (match_white_span - column_stagger_offset) + "\">&nbsp;</td>");
                            }
                        }
                    }
                }
                HTMLTable.AppendLine("    </tr>");
            }
            HTMLTable.AppendLine("</table>");


            return HTMLTable.ToString();
        }

    }
}
