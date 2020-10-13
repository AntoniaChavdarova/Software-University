using System;

namespace CustomList
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList<int> list = new MyList<int>() {1,2,3,4,5,6 };

            var removed = list.RemoveAll(n => n % 2 == 0);

            Console.WriteLine(removed);

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            

        }
    }
}
