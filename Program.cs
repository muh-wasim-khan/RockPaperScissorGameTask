using System;
using System.IO;

namespace RockScissorPaper_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--------------------------------------------------------------------------------------");
            Console.WriteLine("------              !!!ROCKE, PAPER & SCISSOR GAME!!!!!!!                       ------");
            Console.WriteLine("--------------------------------------------------------------------------------------");
            string strPlayerA = string.Empty, strPlayerB = string.Empty;
            int intCount = 0, intPlayerA_W = 0, intPlayerA_L = 0, intPlayerA_D = 0;
            Random randNumber = new Random();

            while (intCount < 100)
            {
                strPlayerA = "R"; // As playerA always bet on stone, so we will define R=Rock for playerA.
                
                //As PlayerB should be random number, so we will select random number between 1-3, where 1=Rock, 2=Paper & 3=Scissor
                strPlayerB = randNumber.Next(1, 4).ToString();
                strPlayerB = (strPlayerB == "1" ? "R" : ((strPlayerB == "2" ? "P" : "S")));

                Console.ForegroundColor = ConsoleColor.White;
                if (strPlayerA == strPlayerB)
                {
                    Console.WriteLine("SeqNo."+ intCount.ToString() + " :: PlayerA(" + strPlayerA + ")  & PlayerB(" + strPlayerB + ") & Score is Tie!!");
                    intPlayerA_D++;
                }
                else if (strPlayerA == "R" && strPlayerB == "P")
                {
                    Console.WriteLine("SeqNo." + intCount.ToString() + " :: PlayerA(" + strPlayerA + ") loser & PlayerB(" + strPlayerB + ") is winner!");
                    intPlayerA_L++;
                }
                else if (strPlayerA == "R" && strPlayerB == "S")
                {
                    Console.WriteLine("SeqNo." + intCount.ToString() + " :: PlayerA(" + strPlayerA + ") winner & PlayerB(" + strPlayerB + ") is loser!");
                    intPlayerA_W++;
                }
                else if (strPlayerA == "P" && strPlayerB == "R")
                {
                    Console.WriteLine("SeqNo." + intCount.ToString() + " :: PlayerA(" + strPlayerA + ") winner & PlayerB(" + strPlayerB + ") is loser!");
                    intPlayerA_W++;
                }
                else if (strPlayerA == "P" && strPlayerB == "S")
                {
                    Console.WriteLine("SeqNo." + intCount.ToString() + " :: PlayerA(" + strPlayerA + ") loser & PlayerB(" + strPlayerB + ") is winner!");
                    intPlayerA_L++;
                }
                else if (strPlayerA == "S" && strPlayerB == "R")
                {
                    Console.WriteLine("SeqNo." + intCount.ToString() + " :: PlayerA(" + strPlayerA + ") loser & PlayerB(" + strPlayerB + ") is winner!");
                    intPlayerA_L++;
                }
                else if (strPlayerA == "S" && strPlayerB == "P")
                {
                    Console.WriteLine("SeqNo." + intCount.ToString() + " :: PlayerA(" + strPlayerA + ") winner & PlayerB(" + strPlayerB + ") is loser!");
                    intPlayerA_W++;
                }
                intCount++;
            };
            Console.WriteLine("");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Symmary: Total Sequences: " + intCount.ToString() + ", PlayerA Winner: " + intPlayerA_W.ToString() + ", PlayerA Looser: " + intPlayerA_L.ToString() + " & PlayerA Tie: " + intPlayerA_D.ToString() + ")");

            //Writing Summary into LogFile.
            StreamWriter swObject = new StreamWriter("LogFile.txt", true);
            try
            {
                swObject.WriteLine("Symmary: Total Sequences: " + intCount.ToString() + ", PlayerA Winner: " + intPlayerA_W.ToString() + ", PlayerA Looser: " + intPlayerA_L.ToString() + " & PlayerA Tie: " + intPlayerA_D.ToString() + ")");
                swObject.Close();
            }
            catch (Exception ex)
            {
                swObject.Close();
            }
        }
    }
}
