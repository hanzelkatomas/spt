using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_SPT
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string pokracovat;
            bool ok;
            int x;
            Console.WriteLine("Prevodnik v0.1\n--------------\n");
            

            do
            {
                Console.WriteLine("Zadejte cislo, ktere chcete prevest:");
                do
                {                    
                    ok = int.TryParse(Console.ReadLine(), out x);
                    if (!ok) Console.WriteLine("Musite zadat cislo!");
                } while (!ok);
                
                
                Console.WriteLine("Zvolte soustavu do ktere chcete cislo prevest:\nHexadecimalni - 16\nOsmickova - 8\nBinarni - 2");
                string soustava = Console.ReadLine();
            ;
                switch (soustava)
                {
                    case "2":

                        double preVelikostPoleBin;
                        int hodnotaBin = x;
                        if (hodnotaBin != 0)
                        {
                            preVelikostPoleBin = Math.Floor(Math.Log(x, 2));                           
                        }
                        else
                        {
                            preVelikostPoleBin = 0;                            
                        }
                        int binVelikostPole = (int)preVelikostPoleBin;
                        char[] charArrayBin = new char[binVelikostPole + 1];

                        for (int i = 0; i <= binVelikostPole; i++)
                        {
                            if ((hodnotaBin % 2 == 1) && (i < binVelikostPole))
                            {
                                charArrayBin[i] = '1';
                                hodnotaBin /= 2;
                            }
                            else if ((hodnotaBin % 2 == 0) && (i == binVelikostPole))
                            {
                                charArrayBin[i] = '0';
                            }
                            else if ((hodnotaBin % 2 == 1) && (i == binVelikostPole))
                            {
                                charArrayBin[i] = '1';
                            }
                            else
                            {
                                charArrayBin[i] = '0';
                                hodnotaBin /= 2;
                            }
                        }

                        Array.Reverse(charArrayBin);
                        Console.WriteLine($"Cislo {x} v binarni soustave: ");
                        foreach (char prvek in charArrayBin)
                        {
                            Console.Write($"{prvek} ");
                        }
                        break;

                    case "16":

                        double preVelikostPoleHex;
                        int hodnotaHex = x;
                        if (hodnotaHex != 0)
                        {
                            preVelikostPoleHex = Math.Floor(Math.Log(x, 16));
                        }
                        else
                        {
                            preVelikostPoleHex = 0;
                        }
                        int hexVelikostPole = (int)preVelikostPoleHex;
                        Console.WriteLine();

                        char[] charArrayHex = new char[hexVelikostPole + 1];
                        // hexadecimalni
                        for (int i = 0; i <= hexVelikostPole; i++)
                        {
                            if (i == hexVelikostPole)
                            {
                                if (hodnotaHex % 16 == 1)
                                {
                                    charArrayHex[i] = '1';
                                }
                                else if (hodnotaHex % 16 == 2)
                                {
                                    charArrayHex[i] = '2';
                                }
                                else if (hodnotaHex % 16 == 3)
                                {
                                    charArrayHex[i] = '3';
                                }
                                else if (hodnotaHex % 16 == 4)
                                {
                                    charArrayHex[i] = '4';
                                }
                                else if (hodnotaHex % 16 == 5)
                                {
                                    charArrayHex[i] = '5';
                                }
                                else if (hodnotaHex % 16 == 6)
                                {
                                    charArrayHex[i] = '6';
                                }
                                else if (hodnotaHex % 16 == 7)
                                {
                                    charArrayHex[i] = '7';
                                }
                                else if (hodnotaHex % 16 == 8)
                                {
                                    charArrayHex[i] = '8';
                                }
                                else if (hodnotaHex % 16 == 9)
                                {
                                    charArrayHex[i] = '9';
                                }
                                else if (hodnotaHex % 16 == 10)
                                {
                                    charArrayHex[i] = 'A';
                                }
                                else if (hodnotaHex % 16 == 11)
                                {
                                    charArrayHex[i] = 'B';
                                }
                                else if (hodnotaHex % 16 == 12)
                                {
                                    charArrayHex[i] = 'C';
                                }
                                else if (hodnotaHex % 16 == 13)
                                {
                                    charArrayHex[i] = 'D';
                                }
                                else if (hodnotaHex % 16 == 14)
                                {
                                    charArrayHex[i] = 'E';
                                }
                                else if (hodnotaHex % 16 == 15)
                                {
                                    charArrayHex[i] = 'F';
                                }
                                else
                                {
                                    charArrayHex[i] = '0';
                                }
                            }
                            else
                            {
                                if (hodnotaHex % 16 == 1)
                                {
                                    charArrayHex[i] = '1';
                                    hodnotaHex /= 16;
                                }
                                else if (hodnotaHex % 16 == 2)
                                {
                                    charArrayHex[i] = '2';
                                    hodnotaHex /= 16;
                                }
                                else if (hodnotaHex % 16 == 3)
                                {
                                    charArrayHex[i] = '3';
                                    hodnotaHex /= 16;
                                }
                                else if (hodnotaHex % 16 == 4)
                                {
                                    charArrayHex[i] = '4';
                                    hodnotaHex /= 16;
                                }
                                else if (hodnotaHex % 16 == 5)
                                {
                                    charArrayHex[i] = '5';
                                    hodnotaHex /= 16;
                                }
                                else if (hodnotaHex % 16 == 6)
                                {
                                    charArrayHex[i] = '6';
                                    hodnotaHex /= 16;
                                }
                                else if (hodnotaHex % 16 == 7)
                                {
                                    charArrayHex[i] = '7';
                                    hodnotaHex /= 16;
                                }
                                else if (hodnotaHex % 16 == 8)
                                {
                                    charArrayHex[i] = '8';
                                    hodnotaHex /= 16;
                                }
                                else if (hodnotaHex % 16 == 9)
                                {
                                    charArrayHex[i] = '9';
                                    hodnotaHex /= 16;
                                }
                                else if (hodnotaHex % 16 == 10)
                                {
                                    charArrayHex[i] = 'A';
                                    hodnotaHex /= 16;
                                }
                                else if (hodnotaHex % 16 == 11)
                                {
                                    charArrayHex[i] = 'B';
                                    hodnotaHex /= 16;
                                }
                                else if (hodnotaHex % 16 == 12)
                                {
                                    charArrayHex[i] = 'C';
                                    hodnotaHex /= 16;
                                }
                                else if (hodnotaHex % 16 == 13)
                                {
                                    charArrayHex[i] = 'D';
                                    hodnotaHex /= 16;
                                }
                                else if (hodnotaHex % 16 == 14)
                                {
                                    charArrayHex[i] = 'E';
                                    hodnotaHex /= 16;
                                }
                                else if (hodnotaHex % 16 == 15)
                                {
                                    charArrayHex[i] = 'F';
                                    hodnotaHex /= 16;
                                }
                                else
                                {
                                    charArrayHex[i] = '0';
                                    hodnotaHex /= 16;
                                }                                
                            }                         
                        }

                        Array.Reverse(charArrayHex);

                        Console.WriteLine($"Cislo {x} v hexadecimalni soustave: ");
                        foreach (char prvek in charArrayHex)
                        {
                            Console.Write($"{prvek}");
                        }
                        break;

                    


                    default:
                        Console.WriteLine("\nMusite zadat 2, 8 nebo 16 pro prevod do dane soustavy!");
                        break;
                }

                Console.WriteLine("\n\nPokud chcete pokracovat napiste ano, v jinem pripade bude program ukoncen.");
               
            } while((pokracovat = Console.ReadLine()) == "ano");             

            Console.ReadKey();

        }
    }
}

