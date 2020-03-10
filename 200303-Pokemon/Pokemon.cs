using System;
using System.Collections.Generic;
using System.Text;
using _200303_Pokemon.Exceptions;
using _200303_Pokemon.Enums;
using static _200303_Pokemon.Enums.PokemonElementsEnum;
using _200303_Pokemon.Capacity;

namespace _200303_Pokemon
{
    public class Pokemon
    {
        string name;
        int pv;
        int atk;
        PokemonElementsEnum type;
        PokemonAlterationEnum alteration;
        AbstractCapacity capacity;

        public string Name { get => name; set => name = value; }
        public int Pv { get => pv; set => pv = value; }
        public int Atk { get => atk; set => atk = value; }
        public PokemonElementsEnum Type { get => type; set => type = value; }
        public PokemonAlterationEnum AlterationState { get => alteration; set => alteration = value; }
        public AbstractCapacity Capacity { get => capacity; set => capacity = value; }

        public Pokemon(string name, int pv, int atk, PokemonElementsEnum type, AbstractCapacity capa)
        {
            Name = name;
            Pv = pv;
            Atk = atk;
            Type = type;
            SetCapacity(capa);
            SetAlteration(PokemonAlterationEnum.NONE);
        }

        public void SetCapacity(AbstractCapacity capa)
        {
            Capacity = capa;
        }
        public void SetAlteration(PokemonAlterationEnum alterationCapacity)
        {
            AlterationState = alterationCapacity;
        }
        public void UseCapacity(Pokemon target)
        {
            Capacity.UseCapacity(this, target);
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

        /// <summary>
        /// Check if this instance of Pokemon has a stronger element than an enemy.
        /// </summary>
        /// <param name="enemy"></param>
        /// <returns>bool</returns>
        public bool CheckStrongerElement(Pokemon caster, Pokemon enemy)
        {
            if (this.Type == FIRE && enemy.Type == PLANT)
                return true;

            if (this.Type == PLANT && enemy.Type == WATER)
                return true;

            if (this.Type == WATER && enemy.Type == FIRE)
                return true;

            return false;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
