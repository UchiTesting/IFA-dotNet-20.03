using System;
using System.Collections.Generic;
using System.Text;
using _200319_Exo06_Humans_and_Phones.Enums;

namespace _200319_Exo06_Humans_and_Phones.Objects
{
    public class Human
    {
        List<Phone> phones;

        string Name { get; set; }
        HumanStance Stance { get; set; }
        public Human(string name)
        {
            Name = name;
            phones = new List<Phone>();
            Stance = HumanStance.NONE;
        }

        public void OnPhoneRinging(object o, EventArgs e)
        {
            Phone thePhone = ((Phone)o);

            if (thePhone.Owner.Equals(this))
                Stance = HumanStance.HAPPY;
            else
            Stance = HumanStance.ANGRY;
        }
        public void OnPhoneNotRinging(object o, EventArgs e)
        {
            Stance = HumanStance.NONE;
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

        public override string ToString()
        {
            return Name;
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
    }
}
