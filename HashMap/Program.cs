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
            HashMap<int, int> map = new HashMap<int, int>(4);
            for(int i = 1; i <= 5; i++)
            {
                map.Add(i, i);
            }
            map.Add(12, 12);
            map.Add(13, 13);
            map.Add(14, 14);
            map.Remove(12);
        }
    }
}
