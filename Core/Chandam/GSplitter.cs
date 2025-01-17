//---------------------------------------------------------------------------------------------
// <copyright file="GSplitter.cs" company="Chandam-ఛందం">
//    Copyright © 2013 - 2018 'Chandam-ఛందం' : http://chandam.apphb.com
//    Original Author : Dileep Miriyala (m.dileep@gmail.com)
//    Last Updated    : 03-Feb-2018 21:28EST
//    Revisions:
//       Version    | Author                   | Email                     | Remarks
//       1.0        | Dileep Miriyala          | m.dileep@gmail.com        | Initial Commit
//       _._        | <TODO>                   |   <TODO>                  | <TODO>
// </copyright>
//---------------------------------------------------------------------------------------------

using Chandam.Indic;
using Chandam.Rules;
using Chandam.Util;
using System;
using System.Collections.Generic;



namespace Chandam.Core
{
	public class GanaVibhajana : IndicParser
	{
		/// <summary>
		/// ctor
		/// </summary>
		/// <param name="str">Input String</param>
		/// <param name="Lang">Rule Language to be Applied</param>
		public GanaVibhajana(string str, RuleLanguage Lang)
		{
			try
			{
				this.Language = Lang;
				this.CharSet = GetLangCharSet();

				Init();
				_RawString = str;

				if (str != null)
				{
					this.Analyse();
				}

			}
			catch (Exception ex)
			{
				throw new Exception("Analysis failed as .." + ex.Message);
			}
		}

		/// <summary>
		/// Gets the Language Charset
		/// </summary>
		/// <returns>Language Charset</returns>
		private iIndicCharSet GetLangCharSet()
		{
			switch (this.Language)
			{
				default:
				case RuleLanguage.Telugu:
					return new TeluguCharSet();
				case RuleLanguage.Kannada:
					return new KannadaCharSet();
			}

		}

		private IndicAkshar GetLangAkshar()
		{
			switch (this.Language)
			{
				default:
				case RuleLanguage.Telugu:
					return new TeluguAksharam();
				case RuleLanguage.Kannada:
					return new KannadaAksharam();
			}
		}


		private void Analyse()
		{
			InvarientVibhajana2(_RawString);
		}

		public string Accept
		{
			get
			{
				return "!?,;.'";
			}
		}

		private void InvarientVibhajana2(string s)
		{
			#region Null Check...
			IndicAkshar[] ICS = this.Split(s);
			if (ICS == null)
			{
				return;
			}
			#endregion

			#region Trim the Spaces at the begenning  Each Line
			ICS = this.LeftTrimLines(ICS);
			#endregion


			#region Prepare & White Listing
			List<IndicAkshar> L = new List<IndicAkshar>();
			int c = 0;
			string prev = "";
			foreach (IndicAkshar A2 in ICS)
			{

				string curr = A2.ToString2();
				bool bypass = false;
				if (A2.Chars.Length == 1)
				{
					if (StringPlus.Contains(Accept, curr))
					{
						Raw.Add(curr);
						curr = " ";
						bypass = true;
					}
					if (StringPlus.Contains("-", curr))
					{
						Raw.Add(curr);
						curr = "";//Samasam
						bypass = false;
					}
				}
				if (!bypass)
				{
					if (!A2.IsValid || A2.Length == 0)
					{
						continue;
					}
				}
				#region Remove Redundnat Spaces and New Lines
				if (curr == prev && (curr == Constants.Space || curr == Constants.NewLine))
				{
					continue;
				}
				#endregion

				IndicAkshar T = new IndicAkshar();
				T.SetChars(curr, this.CharSet);

				if (T.IsPolluEnder)
				{
					if (c - 1 >= 0)
					{
						Raw[Raw.Count - 1] = L[c - 1].ToString2() + curr;

						T = GetLangAkshar();
						T.SetChars(L[c - 1].ToString2() + curr, this.CharSet);
						L[c - 1] = T;
						continue;
					}
				}

				Raw.Add(curr);
				L.Add(T);
				prev = curr;
				c++;
			}
			#endregion

			bool NL = false;
			string lastSym = "";
			string lastChar = "";

			bool flg = false;
			foreach (IndicAkshar T in L)
			{
				string currSym = T.GetSymbol();
				if (currSym == Constants.NewLine)
				{
					NL = true;
					continue;
				}
				#region Manipulate Prev Item
				if (T.IsCompoundChar && !T.IsPolluEnder)
				{
					if (lastChar != Constants.Blank && lastChar != Constants.Space)
					{
						if (T.ChangePrev)
						{
							lastSym = Symbols.GURUVU;
						}
						if (!T.AlwaysGuruvu)
						{
							currSym = Symbols.LAGHUVU;
						}
					}
				}
				else if (T.IsPolluEnder)
				{
					if (T.IsCompoundChar && lastChar != Constants.Blank && lastChar != Constants.Space)
					{
						if (T.ChangePrev)
						{
							lastSym = Symbols.GURUVU;
						}
						if (!T.AlwaysGuruvu)
						{
							currSym = Symbols.LAGHUVU;
						}
					}
					currSym = Symbols.GURUVU;
				}
				#endregion

				_SymbStream = _SymbStream + lastSym;
				_StrStream = _StrStream + lastChar + (flg ? Constants.Space : Constants.Blank);
				_RawStrStream = _RawStrStream + lastChar;

				if (lastChar != "")
				{
					_GSplit.Add(lastChar);
				}
				if (NL)
				{
					_StrStream = _StrStream + Constants.NewLine;
					_SymbStream = _SymbStream + Constants.NewLine;
					_RawStrStream = _RawStrStream + lastChar + Constants.NewLine;
					_GSplit.Add(Constants.NewLine);
					NL = false;

					lastChar = T.ToString2();
					lastSym = currSym;
					continue;
				}

				lastSym = currSym;
				lastChar = T.ToString2();
				flg = T.IsPolluEnder;

			}

			if (lastSym != Constants.Blank || lastChar != Constants.Blank)
			{
				_SymbStream = _SymbStream + lastSym;
				_StrStream = _StrStream + lastChar + (flg ? Constants.Space : Constants.Blank);
				_RawStrStream = _RawStrStream + lastChar;
				_GSplit.Add(lastChar);
			}

			int _prel = 0;
			foreach (string l in _SymbStream.Replace(" ", "").Split('\n'))
			{
				if (l.Length > 1)
				{
					_prel++;
				}
			}
			PreLines = _prel;
		}

		private IndicAkshar[] LeftTrimLines(IndicAkshar[] input)
		{
			List<IndicAkshar> List = new List<IndicAkshar>();
			bool newLineFound = false;
			foreach (IndicAkshar ICS in input)
			{
				if (ICS.ToString2() == Constants.NewLine)
				{
					newLineFound = true;
					List.Add(ICS);
					continue;
				}
				if (newLineFound)
				{
					if (ICS.ToString2() == Constants.Space)
					{
						continue;
					}
				}
				newLineFound = false;
				List.Add(ICS);
			}
			IndicAkshar[] output = new IndicAkshar[List.Count];
			for (int i = 0; i < List.Count; i++)
			{
				output[i] = List[i];
			}
			return output;
		}

		private void Init()
		{
			_SymbStream = "";
			_StrStream = "";
			_RawStrStream = "";
			_GNamesString = "";
			_GSplit = new List<string>();
			_GNames = new List<string>();
			_GSymbols = new List<string>();
			_GString = new List<string>();
			_Yati = new List<string>();
			_Y1 = new List<Yati>();
			_Raw = new List<string>();
			_PrasaYati = new List<bool[]>();
			_PrevYati = new List<bool[]>();
			_APrasa = new List<string>();
			_PP = new List<Prasa>();
			_PP2 = new List<Prasa>();
			_preLines = 0;
		}
		public int PreLines
		{
			set
			{
				_preLines = value;
			}
			get
			{
				return _preLines;
			}
		}
		public string RawString
		{
			set
			{
				_RawString = value;
			}
			get
			{
				return _RawString;
			}
		}

		public List<bool[]> PrevYati
		{
			set
			{
				_PrevYati = value;
			}
			get
			{
				return _PrevYati;
			}
		}


		public List<bool[]> PrasaYati
		{
			set
			{
				_PrasaYati = value;
			}
			get
			{
				return _PrasaYati;
			}
		}


		public List<string> Raw
		{
			set
			{
				_Raw = value;
			}
			get
			{
				return _Raw;
			}
		}
		public string RawStrStream
		{
			get
			{
				return _RawStrStream;
			}
			set
			{
				_RawStrStream = value;
			}
		}

		public string SymbolsStream
		{
			get
			{
				return _SymbStream;
			}
			set
			{
				_SymbStream = value;
			}
		}

		public string StringStream
		{
			get
			{
				return _StrStream;
			}
			set
			{
				_StrStream = value;
			}
		}
		public string GNamesStream
		{
			get
			{
				return _GNamesString;
			}
			set
			{
				_GNamesString = value;
			}
		}
		public List<string> GWiseString
		{
			get
			{
				return _GSplit;
			}
			set
			{
				_GSplit = value;
			}
		}
		public List<Yati> Yati
		{
			get
			{
				return _Y1;
			}
			set
			{
				_Y1 = value;
			}
		}
		public List<Prasa> Prasa
		{
			get
			{
				return _PP;
			}
			set
			{
				_PP = value;
			}
		}


		public List<Prasa> AnthyaPrasa
		{
			get
			{
				return _PP2;
			}
			set
			{
				_PP2 = value;
			}
		}

		public List<string> GNames
		{
			get
			{
				return _GNames;
			}
			set
			{
				_GNames = value;
			}
		}
		public List<string> GSymbols
		{
			get
			{
				return _GSymbols;
			}
			set
			{
				_GSymbols = value;
			}
		}
		public List<string> GString
		{
			get
			{
				return _GString;
			}
			set
			{
				_GString = value;
			}
		}
		public int Lines
		{
			get
			{
				return lines;
			}
			set
			{
				lines = value;
			}
		}

		public int Min
		{
			get
			{
				string[] _LSymbols = this.SymbolsStream.Replace(" ", "").Split('\n');
				int min = 99999;
				foreach (string _LSymbol in _LSymbols)
				{
					if (_LSymbol.Length < min)
					{
						min = _LSymbol.Length;
					}
				}
				return min;
			}
		}

		public int Max
		{
			get
			{
				string[] _LSymbols = this.SymbolsStream.Replace(" ", "").Split('\n');
				int max = 0;
				foreach (string _LSymbol in _LSymbols)
				{
					if (_LSymbol.Length > max)
					{
						max = _LSymbol.Length;
					}
				}
				return max;
			}
		}

		public RuleLanguage Language
		{
			get { return _lang; }
			set { _lang = value; }
		}

		public GanaVibhajana Clone()
		{
			GanaVibhajana G = new GanaVibhajana(null, this.Language);
			G.GWiseString = Copy(this.GWiseString);
			G.RawString = RawString;
			G.GWiseString = GWiseString;
			G.Raw = Raw;
			G.StringStream = StringStream;
			G.SymbolsStream = SymbolsStream;
			G.PreLines = PreLines;
			return G;
		}

		private List<string> Copy(List<string> list)
		{
			List<string> L = new List<string>();

			foreach (string s in list)
			{
				L.Add(s);
			}
			return L;
		}


		string _SymbStream;
		string _StrStream;
		string _RawStrStream;
		string _GNamesString;
		string _RawString;

		List<string> _GSplit;
		List<Yati> _Y1;
		List<string> _Yati;
		List<string> _APrasa;
		List<string> _GNames;
		List<string> _GSymbols;
		List<string> _GString;
		List<Prasa> _PP;
		List<Prasa> _PP2;
		List<string> _Raw;
		List<bool[]> _PrasaYati;
		List<bool[]> _PrevYati;
		int lines = 0;
		int _preLines = 0;
		RuleLanguage _lang;


	}
}


//public List<string> Prasa
//{
//    get
//    {
//        return _Yati;
//    }
//    set
//    {
//        _Yati = value;
//    }
//}
//public List<string> AnthyaPrasa
//{
//    get
//    {
//        return _APrasa;
//    }
//    set
//    {
//        _APrasa = value;
//    }
//}
//public string RawStringStream
//{
//    get
//    {
//        return _rawStrStream;
//    }
//    set
//    {
//        _rawStrStream = value;
//    }
//}

//public string RawSymbolStream
//{
//    get
//    {
//        return _rawSymStream;
//    }
//}

/*
		 private void InvarientVibhajana (string s)
		{
			//int g = 0;
			//int gt = 0;

			bool NL = false;
			string lastSym = "";
			string lastChar = "";

			#region Null Check...
			IndicAkshar[] ICS = this.Split ( s );
			if ( ICS == null )
			{
				return;
			}
			#endregion

			#region Prepare & White Listing
			List<TeluguAksharam> L= new List<TeluguAksharam> ( );
			int c=0;
			foreach ( IndicAkshar A in ICS )
			{

				if ( !A.IsValid || A.Length == 0 )
				{
					continue;
				}

				{
					TeluguAksharam T= new TeluguAksharam ( );
					T.SetChars ( A.ToString2 ( ) );

					if ( T.IsPolluEnder )
					{
						if ( c - 1 >= 0 )
						{
							T = new TeluguAksharam ( );
							T.SetChars ( L[c - 1].ToString2 ( ) + A.ToString2 ( ) );
							L[c - 1] = T;
							continue;
						}

					}
					L.Add ( T );

				}

				c++;
			}
			#endregion

			foreach ( TeluguAksharam T in L )
			{

				#region BlackListing
				if ( T.ToString2 ( ) == Constants.NewLine )
				{
					NL = true;
					continue;
				}
				#endregion

				string currSym = T.GetSymbol ( );


				if ( T.IsCompoundChar && !T.IsPolluEnder )
				{
					if ( lastChar != Constants.Blank && lastChar != Constants.Space )
					{
						if ( T.ChangePrev )
						{
							lastSym = Symbols.GURUVU;
						}
						if ( !T.AlwaysGuruvu )
						{
							currSym = Symbols.LAGHUVU;
						}
					}
				}
				else if ( T.IsPolluEnder )
				{
					currSym = Symbols.GURUVU;
				}


				_rawStrStream = _rawStrStream + T.ToString2 ( ) + ( T.IsPolluEnder ? Constants.Space : Constants.Blank );
				_rawSymStream = _rawSymStream + lastSym;

				_SymbStream = _SymbStream + lastSym;
				_StrStream = _StrStream + lastChar;

				if ( lastChar != "" )
				{
					_GSplit.Add ( lastChar );
				}

				if ( NL )
				{
					_StrStream = _StrStream + Constants.NewLine;
					_SymbStream = _SymbStream + Constants.NewLine;
					_GSplit.Add ( Constants.NewLine );
					NL = false;
				}

				lastSym = currSym;
				lastChar = T.ToString2 ( );


			}

			if ( lastSym != "" || lastChar != "" )
			{
				_SymbStream = _SymbStream + lastSym;
				_StrStream = _StrStream + lastChar;
				_rawSymStream = _rawSymStream + lastSym;
				_GSplit.Add ( lastChar );

			}


			//Check...
			{
				//_rawSymStream = _rawSymStream + lastSym;
				//_rawStrStream = _rawStrStream + lastChar;
			}

		}
	}*/
