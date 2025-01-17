//---------------------------------------------------------------------------------------------
// <copyright file="TeluguCharSet.cs" company="Chandam-ఛందం">
//    Copyright © 2013 - 2018 'Chandam-ఛందం' : http://chandam.apphb.com
//    Original Author : Dileep Miriyala (m.dileep@gmail.com)
//    Last Updated    : 03-Feb-2018 21:36EST
//    Revisions:
//       Version    | Author                   | Email                     | Remarks
//       1.0        | Dileep Miriyala          | m.dileep@gmail.com        | Initial Commit
//       _._        | <TODO>                   |   <TODO>                  | <TODO>
// </copyright>
//---------------------------------------------------------------------------------------------

namespace Chandam.Indic
{
	public class TeluguCharSet : iIndicCharSet
	{
		public IndicChar NewChar
		{
			get
			{
				return new IndicChar(this);
			}
		}

		public string NewLineSet
		{
			get
			{
				return "\n";
			}
		}
		public string SapceSet
		{
			get
			{
				return " ";
			}
		}
		public string IgnoreSet
		{
			get
			{
				return " \n";
			}
		}
		public string AchchuSet
		{
			get
			{
				return "అఆఇఈఉఊఋఎఏఌఐఒఓఔౠ";
			}
		}
		public string HalluSet
		{
			get
			{
				return "కఖగఘ" +
			 "ఙచఛజఝఞ" +
			 "టఠడఢణ" +
			 "తథదధన" +
			 "పఫబభమ" +
			 "యరఱలళవ" +
			 "శషసహ";
			}
		}
		public string NumberSet
		{
			get
			{
				return "౦౧౨౩౪౫౬౭౮౯";
			}
		}
		public char PolluSet
		{
			get
			{
				return '్';
			}
		}
		public string SmallAchchuSet
		{
			get
			{
				return "అఇఉఋఎఌఒ";
			}
		}
		public char Reph
		{
			get
			{
				return 'ర';
			}
		}
		public string SpecialFinishSet
		{
			get
			{
				return "ంఃఽ";
			}
		}
		public string SpecialAkshar
		{
			get
			{
				return "న్,";
			}
		}
		public string SmallFinishingSet
		{
			get
			{
				return "ిుృెొౢ";
			}
		}
		public string FinishingSet
		{
			get
			{
				return "ాిీుూృౄెేైొోౌంఃౖఽౣ";
			}
		}
		public string NeutralSet
		{
			get
			{
				return "ఁ";
			}
		}

		public int UnicodeFrom
		{
			get
			{
				return 3071;
			}
		}

		public int UnicodeTo
		{
			get
			{
				//return 3071 + 128;
				return 3199;
			}
		}

		public char Special2
		{
			get
			{
				return 'ౖ';
			}
		}
	}
}