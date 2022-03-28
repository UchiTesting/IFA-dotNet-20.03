using System;
using System.Text;
using System.Collections.Generic;
using static Simple_IO.AskData;
using _200303_Pokemon.Exceptions;
using static _200303_Pokemon.Enums.PokemonElementsEnum;

namespace _200303_Pokemon
{
    class Program
    {
        static Pokemon Pikachu;
        static Pokemon Hitokage;

        static void Main(string[] args)
        {
            Console.WriteLine("Exo 01: Pokemon");

            Pikachu = new Pokemon("Pikachu", 500, 13,WATER);
            Hitokage = new Pokemon("Hitokage", 550, 10, FIRE);
            char choice;
            bool WinnerExists = false;
            do
            {
                RefreshDisplay();
                choice = AskChar("Please select a pokemon: ");
                try
                {
                    switch (choice)
                    {
                        case '1':
                            Pikachu.Attaquer(Hitokage);
                            break;
                        case '2':
                            Hitokage.Attaquer(Pikachu);
                            break;
                    }
                    Console.WriteLine("Choice value: "+choice);
                    ConsoleKey truc = Console.ReadKey(true).Key;
                }
                catch (CannotAttackDeadEnemyException)
                {
                    Console.WriteLine("\nCannot attack a dead enemy.");
                }
                finally { WinnerExists = CheckWinner(); }
                
                
            } while (choice != '0' && !WinnerExists);
        }

        private static bool CheckWinner()
        {
            List<Pokemon> pokemons = new List<Pokemon>();
            pokemons.Add(Pikachu);
            pokemons.Add(Hitokage);

            foreach (Pokemon p in pokemons)
            {
                if (p.Pv <= 0)
                    return true;
            }

            return false;
        }

        private static void DisplayPokemonSelectMenu()
        {
            Console.SetCursorPosition(0,0) ;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Pokemon Select Menu")
                .AppendLine("1) Pikachu")
                .AppendLine("2) Hitokage")
                .AppendLine("0) Quitter");
            Console.WriteLine(sb.ToString());
        }

        private static void RefreshDisplay()
        {
            Console.Clear();
            DisplayHPInfo();
            DisplayPokemonSelectMenu();
        }

        private static void DisplayHPInfo()
        {
            Console.SetCursorPosition(30, 1);
            Console.WriteLine(string.Format("{0} {1}", Pikachu.Name, Pikachu.Pv));
            Console.SetCursorPosition(30, 2);
            Console.WriteLine(string.Format("{0} {1}", Hitokage.Name, Hitokage.Pv)); ;
        }
    }
}
