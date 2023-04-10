#define P01_01
//#define P01_02
//#define P01_03
//#define P01_04

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Classes.Practice_01 {
    class CPractice_01 {
#if P01_01
#elif P01_02
#elif P01_03
#elif P01_04
#endif  // #if P01_01

        public static void Start(string[] args) {
#if P01_01
            var Random = new Random();
            int Answer = Random.Next(1, 100);

            Console.WriteLine("정답: {0}\n", Answer);

            while (true) {
                int.TryParse(Console.ReadLine(), out int Val);
            }
#elif P01_02
#elif P01_03
#elif P01_04
#endif // #if P01_01
        }
    }
}
