using System;
using System.Text;
using System.Collections.Generic;
using static Simple_IO.AskData;
using _200303_Pokemon.Exceptions;
using static _200303_Pokemon.Enums.PokemonElementsEnum;
using _200303_Pokemon.Capacity;

namespace _200303_Pokemon
{
    class Program
    {
        static Pokemon Pikachu;
        static Pokemon Hitokage;

        static List<Pokemon> pokemons = new List<Pokemon>();


        static void Main(string[] args)
        {
            Console.WriteLine("Exo 01: Pokemon");

            AbstractCapacity lightningAttack25 = new AttackCapacity("Lightning Attack", 25);
            AbstractCapacity lightningAttack10 = new AttackCapacity("Lightning Attack", 10);

            AbstractCapacity vampirize25 = new VampirizeCapacity(25);
            AbstractCapacity vampirize50 = new VampirizeCapacity();

            AbstractCapacity heal100 = new HealCapacity(100);
            AbstractCapacity heal10 = new HealCapacity();

            AbstractCapacity AlterationNone = new AlterationCapacity("OK", Enums.PokemonAlterationEnum.NONE);
            AbstractCapacity AlterationConfused = new AlterationCapacity("Confused", Enums.PokemonAlterationEnum.CONFUSED);
            AbstractCapacity AlterationSilence = new AlterationCapacity("Silenced", Enums.PokemonAlterationEnum.SILENCED);


            Pikachu = new Pokemon("Pikachu", 500, 13, WATER, lightningAttack25);
            Hitokage = new Pokemon("Hitokage", 550, 10, FIRE, vampirize25);

            pokemons.Add(Pikachu);
            pokemons.Add(Hitokage);

            char choice;
            bool WinnerExists = false;
            do
            {
                RefreshDisplay();
                choice = askChar("Please select a pokemon: ");
                try
                {
                    switch (choice)
                    {
                        case '1':
                            Pikachu.UseCapacity(Hitokage);
                            break;
                        case '2':
                            Hitokage.UseCapacity(Pikachu);
                            break;
                    }
                    Console.WriteLine("Choice value: " + choice);
                    ConsoleKey truc = Console.ReadKey(true).Key;
                }
                catch (CannotRemoveHP_OnDeadEnemyException)
                {
                    Console.WriteLine("\nCannot attack a dead enemy.");
                    //return;
                }
                finally { WinnerExists = CheckWinner(); }

                if (Hitokage.Pv < 100)
                    Hitokage.SetCapacity(heal10);
                if (Hitokage.Pv > 500)
                    Hitokage.SetCapacity(vampirize25);

                if (Pikachu.Pv < 300)
                {
                    Hitokage.SetCapacity(AlterationSilence);
                    Hitokage.UseCapacity(Pikachu);
                    Hitokage.SetCapacity(new AttackCapacity("Special Attack", 96));
                    Hitokage.UseCapacity(Pikachu);
                }
                    

            } while (choice != '0' || WinnerExists);
        }

        private static bool CheckWinner()
        {
            foreach (Pokemon p in pokemons)
            {
                if (p.Pv <= 0)
                    return true;
            }

            return false;
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
            Console.WriteLine(string.Format("{0} {1} {2}", Pikachu.Name, Pikachu.Pv, Pikachu.AlterationState));
            Console.SetCursorPosition(30, 2);
            Console.WriteLine(string.Format("{0} {1} {2}", Hitokage.Name, Hitokage.Pv, Pikachu.AlterationState)); ;
        }
        private static void DisplayPokemonSelectMenu()
        {
            Console.SetCursorPosition(0, 0);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Pokemon Select Menu")
                .AppendLine("1) Pikachu")
                .AppendLine("2) Hitokage")
                .AppendLine("0) Quitter");
            Console.WriteLine(sb.ToString());
        }
    }
}
