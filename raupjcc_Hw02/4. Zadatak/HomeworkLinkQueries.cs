using _1.zadatak;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Zadatak
{
    public class HomeworkLinkQueries
    {
        public static string[] Linq1(int[] intArray)
        {
            return intArray.OrderBy(n=>n).GroupBy (numbers=> numbers).Select (s => $"Broj {s.Key} se ponavlja {s.Count()} puta.").ToArray();         
        }
        public static University[] Linq2_1(University[] universityArray)
        {
            return universityArray.Where(u => u.Students.Where(s => s.Gender == Gender.Male).Count() == u.Students.Count()).ToArray();
        }
        public static University[] Linq2_2(University[] universityArray)
        {
            return universityArray.Where(u => u.Students.Count() < universityArray.Average(un => un.Students.Count())).ToArray();
        }
        public static Student[] Linq2_3(University[] universityArray)
        {
            return universityArray.SelectMany(u => u.Students).Distinct().ToArray();
        }
        public static Student[] Linq2_4(University[] universityArray)
        {
            //return (universityArray.Where(u => u.Students.Where(s => s.Gender == Gender.Male)).Join(universityArray.Where(u=>u.Students.Where(s => s.Gender == Gender.Female)))).SelectMany(u => u.Students).Distinct().ToArray();
            throw new NotImplementedException();
        }
        public static Student[] Linq2_5(University[] universityArray)
        {
            throw new NotImplementedException();
        }
    }
}
