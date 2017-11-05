using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.i_7.Zadatak
{
    public class AsyncExample
    {
        public static int FactorialDigitSumNotAsync(int n)
        {
            int number = 1;
            for (int i = 2; i <= n; i++)
            {
                number *= i;
            }
            int sum = 0;
            while (n != 0)
            {
                sum += number % 10;
                number = number / 10;
            }
            return sum;
        }

        public static async Task<int> FactorialDigitSumAsync(int n)
        {
            return await Task.Run(() => FactorialDigitSumNotAsync(n));
        }

        private static async Task LetsSayUserClickedAButtonOnGuiMethod()
        {
            var result = await GetTheMagicNumber();
            Console.WriteLine(result);
        }
        private static async Task<int> GetTheMagicNumber()
        {
            return await IKnowIGuyWhoKnowsAGuy();
        }
        private static async Task<int> IKnowIGuyWhoKnowsAGuy()
        {
            return await IKnowWhoKnowsThis(10) + await IKnowWhoKnowsThis(5);
        }
        private static async Task<int> IKnowWhoKnowsThis(int n)
        {
            return await FactorialDigitSumAsync(n);
        }
        // Ignore this part .
        static void Main(string[] args)
        {
            // Main method is the only method that
            // can ’t be marked with async .
            // What we are doing here is just a way for us to simulate
            // async - friendly environment you usually have with
            // other . NET application types ( like web apps , win apps etc .)
            // Ignore main method , you can just focus on
            //LetsSayUserClickedAButtonOnGuiMethod() as a
            // first method in the call hierarchy .
            var t = Task.Run(() => LetsSayUserClickedAButtonOnGuiMethod());
            Console.Read();
        }
    }
}
