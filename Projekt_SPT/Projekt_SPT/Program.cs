using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*! \mainpage Dokumentace projektu - převodník čísel
 *
 * \section main Popis programu
 *
 * Program má sloužit k převodu čísel v dekadickém formátu na čísla v dvojkové, osmičkové a šestnáckové soustavě
 *   - Uživatel zadá číslo v dekadickém formátu
 *   - Vybere danou soustavu, do které chce číslo převést
 *   - V případě potřeby může pokračovat v procesu
 *   - Vstupy jsou ošetřené proti pádu programu
 *   - Velikost pole se vytváří na základě výpočtu ze vstupu uživatele (vytvoří se přesně taková velikost jak je minimálně potřeba)
 *   
 * \section variables Proměnné programu
 * 
 *   - int x - input uživatel čísla, které chce převést
 *   - string pokracovat - slouží k uchování hodnoty, zda chce uživatel pokračovat v převodu
 *   - bool ok slouží k ověření, že uživatel zadal validní vstup
 *   - string soustava - slouží k uložení volby do jaké soustavy chce uživatel převést číslo
 *   - double preVelikostBin/Osm/Hex - slouží k uložení výpočtu pro přesnou velikost pole
 *   - int hodnotaBin/Osm/Hex - slouží k počítání v převodním algoritmu
 *   - int Bin/Osm/HexVelikostPole - slouží k přetypování proměnné z double na int a zároveň funguje jako informace pro cyklus kdy má skončit
 *   - pole charArrayBin/Osm/Hex - slouží k uložení samotného výsledku výpočtu
 *   
 * \section methods Použité metody
 * 
 *   - Math.Log - slouží k vypočítání ideální velikost pole. Logaritmus o základu 2 sloužil k počítání binárního převodu. Základ 8 k osmičkovému převodu atp.
 *   - Math.Floor - zaokrouhlení celého čísla směrem dolů, číslo se použilo pro vytvoření ideální velikosti pole.
 *   - Array.Reverse - slouží k "přehození" celého pole. Jelikož je výsledek z počítání zapsán naopak, stejně jak když provádíme výpočet na papíře.
 *   
 *   
 * 
 */

/**
 * \file Program.cs
 * \brief Zdrojový kód programu
 * \author Tomáš Hanzelka, Martin Hýbl, Tomáš Macík
 * \date April 2019
 * \details Převodník čísel z desetinné soustavy - konzolová aplikace 
 *
 */

namespace Projekt_SPT
{
    /**
     * \brief Hlavní třída programu, kde se nachází celý algoritmus
     */
    class Program
    {
        /**
         * \brief Hlavní funkce pro otestování programu
         */
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
                            preVelikostPoleBin = 0; // pro pole o velikosti 1                            
                        }
                        int binVelikostPole = (int)preVelikostPoleBin; // pretypovani vysledku logaritmu a prirazeni k prommenne diky ktere vytvori idealni velikost pole
                        char[] charArrayBin = new char[binVelikostPole + 1]; // vytvoreni samotne pole, inkrementace je nutna, k tomu abychom nezasahovali za velikost pole

                        for (int i = 0; i <= binVelikostPole; i++)
                        {
                            // samotny algoritmus pro prevedeni cisla, jedna o klasky postup deleni cisla cislem potrebne soustavy (napr pro binarni soustavu delime cislem 2, vysledky se zapisuji do pole
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

                        Array.Reverse(charArrayBin); // jelikoz je prevedeni cislo zapsano naopak, je potreba ho pred vypsanim prevest
                        Console.WriteLine($"Cislo {x} v binarni soustave: ");
                        foreach (char prvek in charArrayBin)
                        {
                            // cyklus pro vypsani reversnuteho pole
                            Console.Write($"{prvek} ");
                        }
                        break;

                        // cely algoritmus se opakuje i u ostatnich soustav
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

                    case "8":

                        double preVelikostPoleOsm;
                        int hodnotaOsm = x;
                        if (hodnotaOsm != 0)
                        {
                            preVelikostPoleOsm = Math.Floor(Math.Log(x, 8));
                        }
                        else
                        {
                            preVelikostPoleOsm = 0;
                        }
                        int osmVelikostPole = (int)preVelikostPoleOsm;
                        char[] charArrayOsm = new char[osmVelikostPole + 1];


                        for (int i = 0; i <= osmVelikostPole; i++)
                        {
                            if (i == osmVelikostPole) 
                            {
                                if (hodnotaOsm % 8 == 1)
                                {
                                    charArrayOsm[i] = '1';
                                }
                                else if (hodnotaOsm % 8 == 2)
                                {
                                    charArrayOsm[i] = '2';
                                }
                                else if (hodnotaOsm % 8 == 3)
                                {
                                    charArrayOsm[i] = '3';
                                }
                                else if (hodnotaOsm % 8 == 4)
                                {
                                    charArrayOsm[i] = '4';
                                }
                                else if (hodnotaOsm % 8 == 5)
                                {
                                    charArrayOsm[i] = '5';
                                }
                                else if (hodnotaOsm % 8 == 6)
                                {
                                    charArrayOsm[i] = '6';
                                }
                                else if (hodnotaOsm % 8 == 7)
                                {
                                    charArrayOsm[i] = '7';
                                }
                                else
                                {
                                    charArrayOsm[i] = '0';
                                }
                            }

                            else
                            {
                                if (hodnotaOsm % 8 == 1)
                                {
                                    charArrayOsm[i] = '1';
                                    hodnotaOsm /= 8;
                                }
                                else if (hodnotaOsm % 8 == 2)
                                {
                                    charArrayOsm[i] = '2';
                                    hodnotaOsm /= 8;
                                }
                                else if (hodnotaOsm % 8 == 3)
                                {
                                    charArrayOsm[i] = '3';
                                    hodnotaOsm /= 8;
                                }
                                else if (hodnotaOsm % 8 == 3)
                                {
                                    charArrayOsm[i] = '3';
                                    hodnotaOsm /= 8;
                                }
                                else if (hodnotaOsm % 8 == 4)
                                {
                                    charArrayOsm[i] = '4';
                                    hodnotaOsm /= 8;
                                }
                                else if (hodnotaOsm % 8 == 5)
                                {
                                    charArrayOsm[i] = '5';
                                    hodnotaOsm /= 8;
                                }
                                else if (hodnotaOsm % 8 == 6)
                                {
                                    charArrayOsm[i] = '6';
                                    hodnotaOsm /= 8;
                                }
                                else if (hodnotaOsm % 8 == 7)
                                {
                                    charArrayOsm[i] = '7';
                                    hodnotaOsm /= 8;
                                }
                                else
                                {
                                    charArrayOsm[i] = '0';
                                    hodnotaOsm /= 8;
                                }
                            }                          
                        }
                        Array.Reverse(charArrayOsm);

                        Console.WriteLine($"Cislo {x} v osmickove soustave: ");
                        foreach (char prvek in charArrayOsm)
                        {
                            Console.Write($"{prvek}");
                        }
                        break;

                        // default case v pripade, ze uzivatel zada neexistujici soustavu
                    default:
                        Console.WriteLine("\nMusite zadat 2, 8 nebo 16 pro prevod do dane soustavy!");
                        break;
                }

                Console.WriteLine("\n\nPokud chcete pokracovat napiste ano, v jinem pripade bude program ukoncen.");
               // cyklus pro pohodlne opakovane pouzivani
            } while((pokracovat = Console.ReadLine()) == "ano");             

            Console.ReadKey();

        }
    }
}

