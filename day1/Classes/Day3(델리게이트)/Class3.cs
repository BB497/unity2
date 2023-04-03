//#define E03_01
//#define E03_02
#define E03_03

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

/*
 * 
 * >> 델리게이트란?
 * - 메소드를 데이터처럼 특정 메소드에 입력으로 전달하거나 출력으로 메소드를 반환할 수 있게 해주는
 * 기능을 의미한다. 델리게이트를 활용하면 특정 발생되는 이벤트에 따라 객체의 상태를 처리하는 콜백
 * 구조로 프로그램을 설계하는 것이 가능하다.
 * 
 * 또한, C# 은 델리게이트를 활용해서 람다(Lambda) 또는 무명 메소드를 구현하는 것이 가능하다.
 * 
 * 
 * 
 * >> 람다 및 무명 메소드란?
 * - 일반적인 메소드와 달리 이름이 존재하지 않는 메소드를 의미한다. 따라서, 람다 및 무명 메소드를 활용하면
 * 재사용성이 떨어지는 일회성 메소드를 손쉽게 구현하는 것이 가능하다.
 * 또한, 람다 및 무명 메소드는 다른 메소드 내부에서 구현되는 내장 메소드이기 때문에 해당 메소드가 선언 된
 * 영역에 존재하는 지역 변수에 접근하는 것이 가능하다. (즉, 지역 변수에 접근하기 위해서 별도의 참조 또는 
 * 값 형식으로 데이터를 전달 할 필요가 없다.)
 * 
 * C# 델리게이트 선언법
 * - delegate + 반환형 + 델리게이트 이름 + 매개변수
 * 
 * Ex)
 * delegate void SomeDelegate(int, int)
 * 위의 경우 정수 2개를 입력으로 받고, 출력은 존재하지 않는 메소드에 대한 델리게이트 선언
 * 
 * 
 * 
 * >> C# 람다 구현 방법
 * - 매개변수 + 람다 몸체
 * EX)      
 * (int a_nLhs, int a_nRhs) => a_nLhs + a_nRhs;                     << 람다 식(식 형식)
 * (int a_nLhs, int a_nRhs) => { return a_nLhs + a_nRhs);           << 람다 문(문 형식)
 * C# 람다는 식 형식, 문 형식 두가지의 형태를 제공한다.
 * 식 형식은 주로 한 줄로 처리되는 간단한 람다 메소드를 구현할 때 활용되며, 
 * 문 형식은 여러 라인을 지니는 복잡한 명령문을 지니는 람다 메소드를 구현할 때 활용된다.
 * 
 * 또한, C# 람다는 입력으로 전달되는 매개변수의 자료형을 생략하는 것이 가능하다.
 * 따라서, (a_nLhs, a_nRhs) 와 같이 매개 변수의 이름만 명시하는 것이 가능하다.
 * 
 * 
 * >> C# 무명 메소드 구현 방법
 * - delegate + 매개변수 + 메소드 몸체
 * Ex)
 * delegate (int a_nLhs, int a_nRhs) {
 *      // Do something
 * }
 * 
 * 무명 메소드는 C# 이 람다를 지원하기 이전에 사용하던 일회성 메소드이기 때문에 현재는 잘 활용되지 않음.
 * 무명 메소드는 C# 과거 버전과의 호환성을 위해서 존재할 뿐 현재는 대부분 람다를 사용함.
 * 
 * 
 * 
 * >> C# 이 지원하는 델리게이트 종류
 * - Action     << 반환값이 없는 메소드에 대한 델리게이트
 * - Func       << 반환값이 존재하는 메소드에 대한 델리게이트
 * 
 * Ex)
 * Action<int, float>       << 정수 1개, 실수 1개를 입력으로 받는 메소드에 대한 델리게이트
 * Func<int, float>         << 정수 1개를 입력으로 받고 실수를 출력하는 메소드에 대한 델리게이트 
 * 
 * 
 */


/*
 * >> partial 키워드란?
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
        /*
         * PS)
         * C# 과거 버전 사용시 주의 사항
         * - 제네릭이 아닌 델리게이트는 일반 메소드를 제어하는 것이 가능하며, 제네릭 델리게이트는
         * 제네릭 메소드를 제어할 수 있다. (제네릭과 제네릭이 아닌 델리게이트를 구분해서 메소드를 제어
         * 해야 한다.)
         */
        // 값 비교 델리게이트
        public delegate int Compare(int a_nLhs, int a_nRhs);

        // 계산 델리게이트
        public delegate decimal Calculator(int a_nLhs, int a_nRhs);

        // 값을 비교하는 함수
        public static int CompareInt(int a_nLhs, int a_nRhs) {
            return a_nLhs - a_nRhs;
        }

        // 덧셈 결과 반환
        public static decimal GetSumVal(int a_nLhs, int a_nRhs) {
            return a_nLhs + (decimal)a_nRhs;
        }
        // 뺄셈 결과 반환
        public static decimal GetSubVal(int a_nLhs, int a_nRhs) {
            return a_nLhs - (decimal)a_nRhs;
        }
        // 곱셈 결과 반환
        public static decimal GetMultiplyVal(int a_nLhs, int a_nRhs) {
            return a_nLhs * (decimal)a_nRhs;
        }

        // 나눗셈 결과 반환
        public static decimal GetDivideVal(int a_nLhs, int a_nRhs) {
            return a_nLhs / (decimal)a_nRhs;
        }
        // 계산 메소드 반환
        public static Calculator GetCalc(char a_chOperator) {
            switch (a_chOperator) {
                case '+': return GetSumVal;
                case '-': return GetSubVal;
                case '*': return GetMultiplyVal;
                case '/': return GetDivideVal;
            }
            return null;
        }
#elif E03_03
        /*
         * 일반적인 메소드는 람다와 달리 다른 지역에 존재하는 지역변수에 접근하는 것이 불가능하다.
         * 따라서, 특정 메소드가 동작하기 위해 필요한 데이터가 있다면 해당 데이터를 일반적으로
         * 매개변수를 통해서 전달해주는 것이 기본적인 구조이다.
         */

        // 값을 비교한다.
        //public static bool IsEquals(int a_nVal) {
        //    return a_nVal == nVal;
        //}

        // 람다를 반환한다.
        public static Action GetAction(int a_nVal) {
            /*
             * 람다 메소드는 해당 메소드가 구현되어있는 지역 변수에 접근하는 것이 가능하며, 만약 해당
             * 지역이 더이상 유효하지 않더라도, 람다 메소드 내부에서는 여전히 필요에 따라 해당 지역에
             * 존재했던 지역 변수를 사용하는 것이 가능하다.
             * 
             * 즉, 개념적으로 람다 메소드가 외부에 존재하는 지역 변수의 사본을 가지고 있는 개념과 비슷한
             * 의미이다.
             * 특정 고수준 언어에서는, 람다를 클로저라고도 부른다. 클로저라는 단어는, 외부에서는 닫혀 있는
             * 영역이지만, 내부에선 여전히 열려 있는 영역이라는 의미이다.
             */
            return () => {
                a_nVal *= 10;
                Console.WriteLine("람다 메소드 호출: {0}", a_nVal);
            };
        }
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
            int nLhs = 0;
            int nRhs = 0;

            Console.Write("정수 (2개) 입력: ");
            var oTokens = Console.ReadLine().Split();

            nLhs = int.Parse(oTokens[0]);
            nRhs = int.Parse(oTokens[1]);

            Compare oCompare = CompareInt;

            Console.WriteLine("\n>> 비교 결과");
            Console.WriteLine("{0} Compare {1} = {2}", nLhs, nRhs, oCompare(nLhs, nRhs));

            Console.Write("\n수식 입력(+, -, *, /) : ");
            oTokens = Console.ReadLine().Split();

            nLhs = int.Parse(oTokens[0]);
            nRhs = int.Parse(oTokens[2]);

            char chOperator = char.Parse(oTokens[1]);
            Calculator oCalc = GetCalc(chOperator);

            // 수식이 올바를 경우
            if(oCalc != null) {
                decimal dmResult = oCalc(nLhs, nRhs);
                Console.WriteLine("{0} {1} {2} = {3}", nLhs, chOperator, nRhs, dmResult);
            } else {
                Console.WriteLine("잘못된 수식을 입력했습니다.");
            }
#elif E03_03
            var oRandom = new Random();
            var oValList = new List<int>();

            for(int i = 0; i < 10; ++i) {
                oValList.Add(oRandom.Next(1, 100));
            }

            Console.WriteLine(">> 리스트 요소");

            for(int i = 0; i < oValList.Count; ++i) {
                Console.Write("{0}, ", oValList[i]);
            }

            Console.Write("\n\n정수 입력: ");
            int.TryParse(Console.ReadLine(), out int nVal);

            /*
             * 람다 메소드는 해당 메소드가 구현된 영역에 존재하는 지역 변수를 사용하는 것이 가능하다.
             * 즉, 람다 메소드 또한 특정 메소드의 일부로 인식한다.
             */

            int nIdx = oValList.FindIndex((int a_nVal) => {
                return a_nVal == nVal;
            });

            Action oAction01 = () => {
                Console.WriteLine("람다 메소드 호출");
            };

            Action oAction02 = GetAction(nVal);

            //int nIdx = oValList.FindIndex(delegate(int a_nVal) {
            //    return a_nVal == nVal;
            //});

            Console.WriteLine("\n결과: {0}\n", (nIdx >= 0) ? "탐색 성공" : "탐색 실패");

            oAction01();
            oAction02();
#endif  // E03_01
        }
    }
}
