using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionnaireTournois
{
    public class TournamentArborescenceGenerator
    {
                      
        public static string Generate(int asjdhkasd, string infoMatch)
        {
            int match_white_span;
            int match_span;
            int position_in_match_span;
            int column_stagger_offset;
            int effective_row;
            int col_match_num;
            int cumulative_matches;
            int effective_match_id;
            int rounds = asjdhkasd;
            int teams = 1 << rounds;
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

            HTMLTable.AppendLine("<table border=\"0\" cellspacing=\"0\">");
            for (int row = 0; row <= max_rows; row++)
            {
                cumulative_matches = 0;
                HTMLTable.AppendLine("    <tr>");
                for (int col = 1; col <= rounds + 1; col++)
                {
                    match_span = 1 << (col + 1);
                    match_white_span = (1 << col) - 1;
                    column_stagger_offset = match_white_span >> 1;
                    if (row == 0)
                    {
                        if (col <= rounds)
                        {
                            HTMLTable.AppendLine("        <th class=\"thd\">Round " + col + "</th>");
                        }
                        else
                        {
                            HTMLTable.AppendLine("        <th class=\"thd\">Winner</th>");
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
                            effective_match_id = cumulative_matches + col_match_num;
                            if ((position_in_match_span == 1) && (effective_row % match_span == position_in_match_span))
                            {
                                HTMLTable.AppendLine("        <td class=\"white_span\" rowspan=\"" + match_white_span + "\">&nbsp;</td>");
                            }
                            else if ((position_in_match_span == (match_span >> 1)) && (effective_row % match_span == position_in_match_span))
                            {
                                //HTMLTable.AppendLine("        <td class=\"team\">Team " + tournament.TournamentRoundMatches[col][effective_match_id].teamid1 + "</td>");
                                HTMLTable.AppendLine("        <td class=\"team\">Team " + 1 + "</td>");
                            }
                            else if ((position_in_match_span == ((match_span >> 1) + 1)) && (effective_row % match_span == position_in_match_span))
                            {
                                HTMLTable.AppendLine("        <td class=\"vs\" rowspan=\"" + match_white_span + "\">VS <br><button name=\"edit\" id=" + col + ">" + infoMatch + "</button></td>");
                            }
                            else if ((position_in_match_span == match_span) && (effective_row % match_span == 0))
                            {
                                //HTMLTable.AppendLine("        <td class=\"team\">Team " + tournament.TournamentRoundMatches[col][effective_match_id].teamid2 + "</td>");
                                HTMLTable.AppendLine("        <td class=\"team\">Team " + 2 + "</td>");
                            }
                        }
                        else
                        {
                            if (row == column_stagger_offset + 2)
                            {
                                //HTMLTable.AppendLine("        <td class=\"winner\">Team " + tournament.TournamentRoundMatches[rounds][cumulative_matches].winner + "</td>");
                                HTMLTable.AppendLine("        <td class=\"winner\">Team " + 1 + "</td>");
                            }
                            else if (row == column_stagger_offset + 3)
                            {
                                HTMLTable.AppendLine("        <td class=\"white_span\" rowspan=\"" + (match_white_span - column_stagger_offset) + "\">&nbsp;</td>");
                            }
                        }
                    }
                    if (col <= rounds)
                    {
                        //cumulative_matches += tournament.TournamentRoundMatches[col].Count;
                    }
                }
                HTMLTable.AppendLine("    </tr>");
            }
            HTMLTable.AppendLine("</table>");

            
            return HTMLTable.ToString();
        }
        
    }
}
