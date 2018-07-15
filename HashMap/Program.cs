using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashMap
{
    class Program
    {
        static void Main(string[] args)
        {
            // head, addFirst

            MyList<int> numbers = new MyList<int>();

            numbers.AddLast(1);
            numbers.AddLast(2);
            numbers.AddLast(3);

            //foreach(var num in numbers)
            //{
            //    Console.WriteLine(num);
            //}


            HashMap<int, int> map = new HashMap<int, int>(4);
            for (int i = 1; i <= 5; i++)
            {
                map.Add(i, i);
            }

            //foreach and print
            foreach (var pair in map)
            {
                Console.WriteLine(pair);
            }

            map.Clear();

            Console.ReadKey();
        }
    }
}
