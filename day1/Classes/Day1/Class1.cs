//#define E01_01
//#define E01_02
#define E01_03

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
 * 프로퍼티란?
 * - C#에서 제공하는 접근자 메소드를 좀 더 쉽게 구현할 수 있는 기능을 의미.
 * 프로퍼티를 활용하면 일반적인 변수에 접근하듯이 객체에 존재하는 멤버를 제어하는 것이
 * 가능하다.
 * 
 * 또한, 프로퍼티는 Getter 와 Setter중 필요에 따라 모두 구현하거나 둘 중 하나를 생략하는 것이
 * 가능하다. (즉, Getter만 필요할 경우, Setter는 구현할 필요 없다.)
 * 
 * 자동 구현 프로퍼티란?
 * - 일반적인 프로퍼티는 특정 데이터를 보관하거나 읽어들일수 있는 멤버변수가 필요하지만,
 * 자동 구현 프로퍼티를 활용하면 멤버 변수 선언을 생략하는 것이 가능하다.(즉, 프로퍼티만으로 데이터를 저장하거나
 * 읽어 들일 수 있다.)
 * 
 * 단, 특정 데이터를 저장하기 위해서는 반드시 해당 데이터를 저장하기 위한 공간(변수)이 필요하기 때문에,
 * C# 컴파일러는 자동 구현 프로퍼티가 구현되면 해당 프로퍼티를 통해서 제어될 데이터를 저장하기 위한 변수를
 * 자동으로 생성하는 특징이 있다.
 */

namespace day1.Classes.Day1
{
	class Class1
	{
#if E01_01
	class CPlayer
	{
		private string m_oName = string.Empty;

		public int LV { get; set; } = 0;

		public string Name
		{
			get
			{
				return m_oName;
			}
			set
			{
				m_oName = value;
			}

		}
		/*
		 * 생성자란?
		 * - 객체가 생성되는 과정에서 호출되는 특별한 이름을 지니는 메소드를 의미한다.(즉, 생성자의 역할은
		 *  생성 된 객체를 초기화하는 것이다.)
		 *  
		 *  또한, 객체 생성이 완료되기 위해서는 반드시 생성자명이 호출 될 필요가 있다. 만약, 객체가 생성되는
		 *  과정에서 생성자가 별도로 호출되지 않았을 경우, 이는 곧 객체 생성이 완료되지 않았다는 것을 의미한다.
		 *  
		 *  따라서, 특정 클래스 내부에 생성자가 존재하지 않을 경우, C#컴파일러에 의해서 자동으로 아무런 매개변수도
		 *  전달받지 않는 기본 생성자가 추가된다. 단, 클래스 내부에 생성자가 1개라도 존재할 경우, C#컴파일러는 기본
		 *  생성자가 필요하지 않다고 판단하여, 더이상 기본 생성자를 자동으로 추가하지 않는다.
		 *  
		 *  위임 생성자란?
		 *  - 생성자가 같은 클래스 내부에 있는 다른 생성자를 호출할 수 있는 기능을 의미한다.
		 *  따라서, 위임 생성자를 활용하면, 객체를 초기화시키는 구문의 중복을 최소화시킬수 있다.
		 *  
		 *  PS)
		 *  C++언어는 특정 메모리를 동적으로 할당할 수 있는 방법으로 크게 malloc함수와 new키워드를 제공한다.
		 *  
		 *  malloc함수는 C부터 존재하던 함수로써, 해당 함수를 활용하면 동적으로 데이터를 할당하는 것이
		 *  가능하지만, 객체는 동적으로 생성할 수 없다. 이는, C 에는 클래스의 개념이 없기 때문에, malloc함수 또한
		 *  클래스에 대응되는 기능이 별도로 구현되어 있지 않기 때문이다.
		 *  
		 *  따라서, C++에서 객체를 동적으로 생성하기 위해서는 반드시 new키워드를 사용해야 한다.
		 *  new키워드를 통해서 객체를 동적으로 생성하면, 컴파일러에 의해서 해당 객체의 생성자가 호출되며,
		 *  이는 곧 정상적으로 객체가 생성되었음을 의미한다.
		 */



		// 기본 생성자
		public CPlayer(): this(string.Empty, 0)			// 위임 생성자
		{
		}

		// 생성자
		/* 생성자가 호출되어야만 객체가 생성된 것임.
		 * 기본 생성자: 매개변수가 없는 것. ex) CPlayer()
		 */
		public CPlayer(string a_oName, int a_nLV)
		{
			this.LV = a_nLV;
			m_oName = a_oName;
		}

		public void ShowInfo()
		{
			Console.WriteLine("Name: {0} LV: {1}", m_oName, this.LV);
		}
	}


#elif E01_02
		/*
		 * 
		 * >> 상속이란?
		 * - 부모 클래스가 지니고 있는 멤버(변수, 메소드, 프로퍼티 등등) 를 자식 클래스가 물려받는
		 *  것을 의미한다. (즉, 상속을 활용하면 특정 클래스 간에 부모/자식 관계를 형성하는 것이 가능하며, 
		 *  자식 클래스에서는 부모 클래스가 지니고 있는 멤버를 활용하는 것이 가능하다.)
		 *  
		 *  따라서, 상속을 활용하면 클래스 간에 중복적으로 명시되는 구문을 최소화시키는 것이 가능하다.
		 *  (클래스 간에 공통적으로 존재하는 특징은 부모 클래스에 구현 후, 해당 클래스를 상속함으로써 요구사항 변경 등에
		 *  따르는 변화에 좀 더 수월하게 대응할 수 있다.)
		 *  
		 *  >> 올바른 상속 구조
		 *  - 기본적으로 C#을 포함한 모든 객체지향 프로그래밍 언어는 특정 클래스 간에 상속을 제한하는 규약이 별도로
		 *  존재하지 않기 때문에, 상속을 무분별하게 활용하면 오히려 프로그램의 구조가 복잡해지는 단점이 있다.
		 *  
		 *  따라서, 특정 클래스를 올바른 구조로 상속을 하기 위해서는, 크게 2가지의 규칙이 있으며, 해당 규칙을
		 *  만족한다면, 일반적으로 바람직한 방향으로 상속이 진행되고 있다고 보아도 좋다.
		 *  
		 *  올바른 상속 구조에는, is a 의 관계와, has a 의 관계가 있으며, 이 중 has a 는 상속으로 이루어진
		 *  포함 관계가 변하지 않는 단점이 있기 때문에, is a의 관계만을 가지고 상속 구조를 잡아가는 것을 추천.
		 *  has a 관계는 클래스의 멤버를 통해서도 충분히 유연하게 표현할 수 있기 때문에 굳이 has a 의 관계를 상속에
		 *  적용하지 않아도 된다.
		 */


		// 부모 클래스
		public class CBase {
			public int m_nVal = 0;
			public float m_fVal = 0.0f;
			// 기본 생성자
			public CBase() : this(0, 0.0f) {

			}

			//생성자 
			public CBase(int a_nVal, float a_fVal) {
				m_nVal = a_nVal;
				m_fVal = a_fVal;
			}

			public void ShowInfo() {
				Console.WriteLine("===> 부모 클래스 정보 <===");
				Console.WriteLine("정수: {0}, 실수: {1}", m_nVal, m_fVal);
			}
		}

		// 자식 클래스
		public class CDerived : CBase {
			public string m_oStr = string.Empty;


			// 기본 생성자
			public CDerived() : this(0, 0.0f, string.Empty) {

			}

			/*
			 * 자식 클래스를 통해 객체를 생성했을 경우, 자식 객체의 생성자는 컴파일러에 의해서 호출된다.
			 * 단, 자식 클래스의 객체가 생성 완료되기 위해서는, 반드시 부모 클래스의 생성자가 호출 될 필요가
			 * 있으며, 부모 클래스의 생성자는 자식 클래스의 생성자에서 호출해줘야 한다.
			 * 
			 * 만약, 자식 클래스의 생성자에서 부모 클래스의 생성자를 호출하는 구문이 존재하지 않을 경우, 컴파일러에
			 * 의해서 자동으로 부모 클래스의 기본 생성자를 호출하는 구문이 추가된다.
			 * 
			 * 따라서, 부모 클래스에 기본 생성자가 존재하지 않을 경우에는, 반드시 자식 클래스의 생성자에서 부모 클래스의
			 * 생성자를 호출하는 구문을 명시적으로 작성해 줄 필요가 있다.
			 * 
			 * 
			 */

			// 생성자 
			public CDerived(int a_nVal, float a_fVal, string a_oStr) : base(a_nVal, a_fVal) {
				m_oStr = a_oStr;
			}

			// 정보 출력
			public new void ShowInfo() {
				/*
				 * base 키워드는 부모 클래스를 지칭하는 키워드이다. 따라서, 부모 클래스가 지니고 있는
				 * 메소드 중에 자식 클래스의 메소드와 동일한 이름을 지닌 메소드를 호출하기 위해서는
				 * 반드시 base키워드를 명시함으로써 부모 클래스 메소드를 호출하겠다는 것을 컴파일러에게
				 * 알려야 한다.
				 */
				base.ShowInfo();

				Console.WriteLine("===> 자식 클래스 정보 <===");
				Console.WriteLine("문자열: {0}", m_oStr);
			}
		}

#elif E01_03
		/*
		 * >> 다형성이란?
		 * - 특정 대상을 바라보는 시야에 따라 서로 다른 대상으로 인지하는 것을 의미함.
		 *	 대상은 하나지만, 바라보는 시야에 따라 해당 대상이 여러 형태를 지닌다.
		 *	 
		 * 객체지향 프로그래밍에서는 클래스의 상속관계를 이용하여 다형성을 흉내내는 것이 가능하다.
		 * 자식 클래스로부터 생성된 객체를 부모 클래스의 자료형으로 참조하는 것이 가능하다.
		 * 
		 * 따라서, 자식 클래스의 객체를 부모 클래스의 시야로 바라봄에 따라 해당 객체를 부모 클래스의 객체로
		 * 인지하는 것이 가능하다.
		 * 
		 * >> 가상 메서드란?
		 * - 
		 */
#endif	// #if E01_01

		// 초기화
		public static void Start(string[] args)
		{
#if E01_01
			var oPlayer01 = new CPlayer();
			oPlayer01.LV = 1;
			oPlayer01.Name = "Player1";

			var oPlayer02 = new CPlayer();
			oPlayer02.LV = 50;
			oPlayer02.Name = "Player2";

#elif E01_02
			var oBase = new CBase();
			oBase.m_nVal = 10;
			oBase.m_fVal = 3.14f;

			var oDerived = new CDerived();
			oDerived.m_nVal = 20;
			oDerived.m_fVal = 2.14f;
			oDerived.m_oStr = "자식 클래스";

			oBase.ShowInfo();

			Console.WriteLine("\n");
			oDerived.ShowInfo();
#elif E01_03

#endif
		}

	}
}