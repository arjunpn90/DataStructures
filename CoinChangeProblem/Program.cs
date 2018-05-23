using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinChangeProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 4;

            int[] coins = { 1, 2, 3 };
            Console.WriteLine(MakeChange(coins, n));
        }

        public static long MakeChange(int[] coins, int money)
        {
            return MakeChange(coins, money, 0);
        }

        public static long MakeChange(int[] coins, int money, int index)
        {
            if (index >= coins.Length)
                return 0;
            if (money == 0)
                return 1;

            int amountWithCoins = 0;
            long ways = 0;
            while (amountWithCoins <= money)
            {
                int remainingMoney = money - amountWithCoins;                
                ways += MakeChange(coins, remainingMoney, index + 1);
                amountWithCoins += coins[index];
            }
            return ways;
        }
    }
}
