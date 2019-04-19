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

