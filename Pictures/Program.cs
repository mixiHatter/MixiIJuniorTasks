using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pictures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int picturesRow = 3;
            int userPictures = 52;
            int fillRow;
            int overfillRow;

            fillRow = userPictures / picturesRow;
            overfillRow = userPictures % picturesRow;

            Console.WriteLine($"В ряду {picturesRow} картинок, у пользователя {userPictures} картинок.");
            Console.WriteLine($"Заполненных рядов: {fillRow}, картинок сверх меры: {overfillRow}.");
        }
    }
}
