//#define E01_01
//#define E01_02
//#define E01_03
#define E01_04

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

namespace day1.Classes.Day1 {
	class Class1 {
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
		 * 
		 * >> 가상 메서드란?
		 * - 해당 메소드가 호출 될 때 실행되는 메소드를 동적으로 바인딩 할 수 있는 메소드를 의미한다.
		 *  즉, 가상 메소드를 다형성에 활용하면 특정 객체를 가리키는 참조형에 상관 없이 항상 동일한 결과를 만들어낼 수 있다.
		 *  
		 *  >> 순수 가상 메소드(추상 메소드)?
		 *  - 순수 가상 메소드(추상 메소드)는 구현부가 존재하지 않는 메소드를 의미한다.
		 *  즉, 메소드 선언부만 존재하기 때문에 해당 메소드를 특정 클래스가 하나라도 지니고 있을 경우 해당 클래스는 객체화시킬 수 없는
		 *  추상 클래스가 된다.
		 *  
		 *  따라서, 추상 클래스를 객체화시키기 위해서는 해당 클래스를 상속한 자식 클래스에서 추상 메소드를 구현함으로써 간접적으로
		 *  객체화시킬 수 있다.
		 *  
		 *  만약, 자식 클래스에서도 부모 클래스에 존재하는 추상 메소드를 구현하지 않았을 경우 해당 클래스 또한
		 *  객체화 시킬 수 없는 특징이 있다.
		 */


		// Class 이용하여 삼각형, 사각형 그리기


		// 색상
		private enum EColor {
			NONE = -1,
			RED,
			GREEN,
			BLUE,
			MAX_VAL
		}


		// 도형
		private abstract class CShape {
			protected EColor Color { get; private set; } = EColor.NONE;

			// 생성자
			public CShape(EColor a_eColor) {
				this.Color = a_eColor;
			}

			// 색상을 반환한다.
			public string GetColor() {
				var oColors = new List<string>() {
					"빨간색",
					"녹색",
					"파란색"
				};
				return oColors[(int)this.Color];
			}


			// 그린다
			public abstract void Draw();
		}

		// 상속: 삼각형
		private class CTriangle : CShape {
			// 생성자
			public CTriangle(EColor a_eColor) : base(a_eColor) {
				// do something
			}

			// 그린다
			public override void Draw() {
				// do something
				Console.WriteLine("{0} 삼각형을 그렸습니다.", this.GetColor());
			}

			// 상속: 사각형
			private class CRectangle : CShape {
				// 생성자
				public CRectangle(EColor a_eColor) : base(a_eColor) {
					Console.WriteLine("{0} 사각형을 그렸습니다.", this.GetColor());
					// do something
				}

				// 그린다
				public override void Draw() {
					Console.WriteLine("{0} 사각형을 그렸습니다.", this.GetColor());
				}
			}

			// 캔버스
			private class CCanvas {
				private List<CShape> m_oShapeList = new List<CShape>();

				// 도형 추가
				public void AddShape(CShape a_oShape) {
					m_oShapeList.Add(a_oShape);
				}

				// 모든 도형을 그린다.
				public void DrawAllShape() {
					for (int i = 0; i < m_oShapeList.Count; ++i) {
						m_oShapeList[i].Draw();
					}


				}
			}


			// 그림판 app
			private class CPaintApp {
				// 메뉴
				private enum EMenu {
					NONE = -1,
					ADD_TRIANGLE,
					ADD_RECTANGLE,
					DRAW_ALL_SHAPES,
					EXIT,
					MAX_VAL
				};

				private CCanvas m_oCanvas = new CCanvas();

				// 구동시킨다.
				public void Run() {
					EMenu eMenu = EMenu.NONE;

					do {
						this.PrintMenus();
						Console.Write("\n메뉴 선택: ");

						eMenu = (EMenu)(int.Parse(Console.ReadLine()) - 1);

						switch (eMenu) {
							case EMenu.ADD_TRIANGLE:
							case EMenu.ADD_RECTANGLE: {
									var oShape = this.CreateShape(eMenu);
									m_oCanvas.AddShape(oShape);
									break;
								}
							case EMenu.DRAW_ALL_SHAPES: m_oCanvas.DrawAllShape(); break;
						}

						Console.WriteLine();
					} while (eMenu != EMenu.EXIT);
				}

				// 메뉴를 출력한다.
				private void PrintMenus() {
					Console.WriteLine("=====메뉴=====");
					Console.WriteLine("1. 삼각형 추가");
					Console.WriteLine("2. 사각형 추가");
					Console.WriteLine("3. 모든 도형 그리기");
					Console.WriteLine("4. 종료");
				}

				/*
				 * 팩토리 메소드란?
				 *  - 특정 객체를 생성하는 역할을 담당하는 메소드를 의미한다.
				 *   즉, 팩토리 메소드를 활용하면 객체가 생성되는 과정에서 발생하는 초기화 등의 구문을 특정 메서드에서
				 *   작성함으로써, 중복을 줄이는 것이 가능하다.
				 */


				// 도형 생성
				private CShape CreateShape(EMenu a_eMenu) {
					var oRandom = new Random();
					var eColor = (EColor)oRandom.Next((int)EColor.RED, (int)EColor.MAX_VAL);

					switch (a_eMenu) {
						case EMenu.ADD_TRIANGLE: return new CTriangle(eColor);
						case EMenu.ADD_RECTANGLE: return new CRectangle(eColor);
					}
					return null;
				}
			}




#elif E01_04
		/*
		 * 인터페이스란?
		 * - 특정 사물 간에 상호작용을 일으킬 수 있는 요소 또는 수단
		 *  프로그래밍에서 인터페이스라는 것은 특정 클래스가 지니고 있는 메소드를 의미한다.
		 *  
		 *  객체 지향 프로그래밍은 사물간 상호작용을 통해서 프로그램의 목적을 달성하는 설계
		 *  방식이기 때문에, 특정 명령 구문을 단순히 프로그래밍 관점으로 해석하는 것이 아니라
		 *  특정 대상(의인화) 사람의 관점에 가깝게 끌어올려서 사물과 사물간의 요청과 해당 요청에
		 *  대한 결과를 처리하는 방향으로 프로그램을 작성할 필요가 있다.
		 *  
		 *  프로그래밍에서 인터페이스란 함수의 목록을 의미한다.
		 *  
		 *  C# 인터페이스 선언 방법
		 *  - interface + 인터페이스 이름 + 인터페이스 멤버(메소드)
		 *  Ex)
		 *  interface IOutput{
		 *		void OutputDatas();
		 *  }
		 *  
		 *  인터페이스는 단순한 함수(메소드)의 목록이기 때문에 해당 메소드의 구현부를 추가하는
		 *  것은 불가능하며, 선언만 추가할 수 있다.
		 *  
		 *  또한, 특정 클래스가 인터페이스를 따를 경우, 해당 클래스에서는 반드시 인터페이스에
		 *  존재하는 모든 메소드를 구현해줘야 한다.
		 *  
		 *  만약, 해당 클래스가 인터페이스에 존재하는 메소드 중 하나라도 구현하지 않았을 경우, 
		 *  해당 클래스는 객체화시키는 것이 불가능하다.(컴파일 에러 발생)
		 */
#endif // #if E01_01

		// 초기화
		public static void Start(string[] args) {
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
				var oPaintApp = new CPaintApp();
				oPaintApp.Run();
#elif E01_04
#endif
		}
	}
}