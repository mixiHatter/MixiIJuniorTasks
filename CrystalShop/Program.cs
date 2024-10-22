using System;

namespace CrystalShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int userCoins;
            int crystalPrice = 12;
            int userCrystals;
            
            Console.Write("Сколько у вас монет: ");
            userCoins = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Здравствуй путник! Цена кристалла {crystalPrice} монет.");
            Console.Write("Сколько кристаллов возьмёшь? ");
            userCrystals = Convert.ToInt32(Console.ReadLine());
            userCoins = userCoins - crystalPrice * userCrystals;
            Console.WriteLine($"У тебя {userCoins} монет и {userCrystals} кристалов");
        }
    }
}
