using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinChangeProblem
{
    class Program
    {
        static int[] coins = { 1, 2, 3 };

        static void Main(string[] args)
        {
            int n = 4;
            //Console.WriteLine(GetCoinsRecursion(n));
            Console.WriteLine(GetCountDynamicProgramming(n));
        }

        /// <summary>
        /// Helper method to call recursive method
        /// </summary>
        /// <param name="money"></param>
        /// <returns></returns>
        public static int GetCoinsRecursion(int money)
        {
            return GetCoinsRecursion(money, 0);
        }

        /// <summary>
        /// Get the combination of coins using recursion
        /// </summary>
        /// <param name="money"></param>
        /// <param name="currentCoin"></param>
        /// <returns></returns>
        public static int GetCoinsRecursion(int money, int currentCoin)
        {
            if (money == 0)
                return 1;

            if (money < 0)
                return 0;

            int ways = 0;
            for (int coin=currentCoin; coin < coins.Length; coin++)
            {
                ways += GetCoinsRecursion(money - coins[coin], coin);
            }
            return ways;
        }
        
        /// <summary>
        /// Get coin denominations using Dynamic Programming
        /// </summary>
        /// <param name="money"></param>
        /// <returns></returns>
        public static int GetCountDynamicProgramming(int money)
        {
            int[] combination = new int[money + 1];
            combination[0] = 1;

            foreach (int coin in coins)
            {
                for (int amount=1; amount <combination.Length; amount++)
                {                                            
                    if (amount >= coin)
                        combination[amount] += combination[amount - coin];
                }
            }

            return combination[money];
        }
    }
}
