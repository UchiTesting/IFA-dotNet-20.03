using System;
using System.Collections.Generic;
using System.Text;
using _200306_Exo02_Humans_and_Phones.Enums;

namespace _200306_Exo02_Humans_and_Phones.Objects
{
    public class Human : AbstractObserver
    {
        List<Phone> phones;
        HumanStance Stance { get; set; }
        public Human(string name) : base(name)
        {
            phones = new List<Phone>();
            Stance = HumanStance.NONE;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() == typeof(Human))
            {
                if (((Human)obj).Name.Equals(this.Name))
                    return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return Name;
        }

        public void AddPhone(Phone p)
        {
            phones.Add(p);
        }

        public void AddPhones(List<Phone> p)
        {
            phones.AddRange(p);
        }

        public void RemovePhone(int idx)
        {
            phones.RemoveAt(idx);
        }

        public void RemovePhone(Phone phone)
        {
            Phone tmpPhone = phones.Find(p => p.Equals(phone));

            phones.Remove(tmpPhone);
        }

        public override void Notify()
        {
            UpdateStance();
            Console.WriteLine(Name + " is " + Stance);
        }

        private void UpdateStance()
        {
            if (HasRingingPhone())
            {
                Stance = HumanStance.HAPPY;

            }
            else
                Stance = HumanStance.ANGRY;
        }
        private bool HasRingingPhone()
        {
            Phone tmpPhone = phones.Find(p => p.State == Phone_State.RINGING);
            if (tmpPhone != null)
                return true;

            return false;

        }
    }
}
