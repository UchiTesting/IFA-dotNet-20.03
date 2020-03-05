using System;
using System.Collections.Generic;
using System.Text;
using _200303_Pokemon.Exceptions;
using _200303_Pokemon.Enums;
using static _200303_Pokemon.Enums.PokemonElementsEnum;

namespace _200303_Pokemon
{
    class Pokemon
    {
        string name;
        int pv;
        int atk;
        PokemonElementsEnum type;

        public string Name { get => name; set => name = value; }
        public int Pv { get => pv; set => pv = value; }
        public int Atk { get => atk; set => atk = value; }
        internal PokemonElementsEnum Type { get => type; set => type = value; }

        public Pokemon(string name, int pv, int atk, PokemonElementsEnum type)
        {
            Name = name;
            Pv = pv;
            Atk = atk;
            Type = type;
        }

        public void Attaquer(Pokemon enemy)
        {
            int atkratio = 1;
            if (CheckStrongerElement(enemy))
                atkratio = 2;

            if (enemy.pv > 0)
                enemy.pv -= this.atk * atkratio;
            else
            {
                throw new CannotAttackDeadEnemyException(string.Format("Enemy {0} is dead.", enemy.Name));
            }

            if (enemy.pv <= 0)
                enemy.pv = 0;
        }

        /// <summary>
        /// Check if this instance of Pokemon has a stronger element than an enemy.
        /// </summary>
        /// <param name="enemy"></param>
        /// <returns>bool</returns>
        public bool CheckStrongerElement(Pokemon enemy)
        {
            if (this.Type == FIRE && enemy.Type == PLANT)
                return true;

            if (this.Type == PLANT && enemy.Type == WATER)
                return true;

            if (this.Type == WATER && enemy.Type == FIRE)
                return true;

            return false;
        }
    }
}
