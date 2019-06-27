using System;
using System.Collections.Generic;

namespace BlackJack.GAME.Extentions
{
    public static class ListExtentions
    {
        public static void Shuffle<T>(this IList<T> list)
        {
            Random random = new Random();
            int randomIndex = 0;

            for (int i = 0; i < list.Count - 1; i++)
            {
                randomIndex = random.Next(i + 1);
                T val = list[randomIndex];
                list[randomIndex] = list[i];
                list[i] = val;
            }
        }
    }
}
