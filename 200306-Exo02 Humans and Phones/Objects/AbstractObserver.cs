using System;
using System.Collections.Generic;
using System.Text;

namespace _200306_Exo02_Humans_and_Phones.Objects
{
    public abstract class AbstractObserver
    {
        public string Name { get; set; }

        protected  AbstractObserver(string name) { Name = name; }
        public virtual void Notify() { }

        public override bool Equals(object obj)
        {
            if (obj.GetType() == typeof(AbstractObserver))
            {
                if (((AbstractObserver)obj).Name.Equals(this.Name))
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
    }
}
