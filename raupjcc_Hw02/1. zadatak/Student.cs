using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.zadatak
{
    public class Student
    {
        public string Name { get; set; }
        public string Jmbag { get; set; }
        public Gender Gender { get; set; }
        public Student(string name, string jmbag)
        {
            Name = name;
            Jmbag = jmbag;
        }

        public override bool Equals(object obj)
        {
            if (this ==null || obj==null || obj.GetType() != this.GetType())
            {
                return false;
            }

            Student obj2 = (Student)obj;

            if (obj2.Jmbag.Equals(this.Jmbag))
            {
                return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.Jmbag.GetHashCode();
        }

        public static bool operator ==(Student obj1, Student obj2)
        {
            return obj1.Equals(obj2);
        }

        public static bool operator !=(Student obj1, Student obj2)
        {
            return !(obj1.Equals(obj2));
        }
    }

    public enum Gender
    {
        Male, Female

    }
}
