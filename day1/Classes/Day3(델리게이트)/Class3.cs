#define E03_01
#define e03_02
#define E03_03

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 
 * 델리게이트란?
 * - 메소드를 데이터처럼 특정 메소드에 입력으로 전달하거나 출력으로 메소드를 반환할 수 있게 해주는
 * 기능을 의미한다. 델리게이트를 활용하면 특정 발생되는 이벤트에 따라 객체의 상태를 처리하는 콜백
 * 구조로 프로그램을 설계하는 것이 가능하다.
 */


/*
 * partial 키워드란?
 * - 특정 클래스 또는 구조체를 여러 파일에 나누어서 구현할 수 있게 해주는 키워드
 *  해당 키워드를 활용하면 복잡한 명령문으로 이루어진 큰 클래스를 특정 분류에 따라 여러 파일에 나누어
 *  작성함으로써 코드에 대한 유지보수성을 증가시키는 역할을 한다.
 */
public static partial class CExtension {
    // 값을 오름차순 정렬하는 메소드
    public static void ExSort<T>(this List<T> a_oSender,
        Func<T, T, int> a_oCompare) {
        // 삽입 정렬
        for (int i = 1; i < a_oSender.Count; ++i) {
            int j = 0;
            T tCompareVal = a_oSender[i];

            for (j = i - 1; j >= 0 && a_oCompare(a_oSender[j], tCompareVal) > 0; --j) {
                a_oSender[j + 1] = a_oSender[j];
            }
            a_oSender[j + 1] = tCompareVal;
        }
    }
}


namespace day1.Classes.Day3 {
    // Example 3
    class Class3 {
#if E03_01
        // 오름차순 비교
        public static int CompareByAscending<T>(T a_nLhs, T a_nRhs) where T: IComparable {
            return a_nLhs.CompareTo(a_nRhs);
        }

        // 내림차순 비교
        public static int CompareByDescending<T>(T a_nLhs, T a_nRhs) where T: IComparable {
            return a_nRhs.CompareTo(a_nLhs);
        }

#elif E03_02

#elif E03_03

#endif  // E03_01

        //  초기화
        public static void Start(string[] args) {
#if E03_01
            var oRandom = new Random();
            var oValList01 = new List<int>();
            var oValList02 = new List<float>();

            for (int i = 0; i < 5; ++i) {
                oValList01.Add(oRandom.Next(1, 100));
                oValList02.Add((float)(oRandom.NextDouble() * 100.0));
            }

            Console.WriteLine(">> 정렬 전");
            
            for(int i = 0; i < oValList01.Count; ++i) {
                Console.Write("{0}, ", oValList01[i]);
            }
            Console.WriteLine();

            for (int i = 0; i < oValList02.Count; ++i) {
                Console.Write("{0:0.00}, ", oValList02[i]);
            }

            oValList01.ExSort(CompareByDescending);
            oValList02.ExSort(CompareByDescending);

            Console.WriteLine("\n\n>> 정렬 후");

            for (int i = 0; i < oValList01.Count; ++i) {
                Console.Write("{0}, ", oValList01[i]);
            }

            Console.WriteLine();
            for (int i = 0; i < oValList02.Count; ++i) {
                Console.Write("{0:0.00}, ", oValList02[i]);
            }

            oValList01.ExPrint();

#elif E03_02

#elif E03_03

#endif  // E03_01
        }
    }
}
