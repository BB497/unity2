#define E01_01
#define E01_02
#define E01_03

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day1.Classes.Day1
{
	class Class1
	{

		// 초기화
		public static void Start(string[] args)
		{
#if E01_01
			class Cplayer
		{
			public int m_nLV = 0;
			public string m_oName = string.Empty;

			public void ShowInfo()
			{
				Console.WriteLine("Name: {0}, Lv: {1}", m_oName, m_nLV);
			}
		}
#elif E01_02

#elif E01_03

#endif
		}
	}
}
