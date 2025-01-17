﻿//---------------------------------------------------------------------------------------------
// <copyright file="StyleSheet.cs" company="Chandam-ఛందం">
//    Copyright © 2013 - 2018 'Chandam-ఛందం' : http://chandam.apphb.com
//    Original Author : Dileep Miriyala (m.dileep@gmail.com)
//    Last Updated    : 03-Feb-2018 21:37EST
//    Revisions:
//       Version    | Author                   | Email                     | Remarks
//       1.0        | Dileep Miriyala          | m.dileep@gmail.com        | Initial Commit
//       _._        | <TODO>                   |   <TODO>                  | <TODO>
// </copyright>
//---------------------------------------------------------------------------------------------

namespace Chandam
{
	class StyleSheet
	{
		public const string Value = @"@font-face
{
	font-family: 'RaviPrakash';
	font-style: normal;
}
@font-face
{
	font-family: 'RamaneeyaRegular';
	font-style: normal;
}
.err, .menuItems
{
	font-family: RaviPrakash, Timmana,Ponnala, Vani, potana;
}
.title,.footer,.header
{
	font-family: Timmana,RaviPrakash, Ponnala, Vani,potana;
	text-align:center;
}
body, select, textarea
{
	font-family: 'RamaneeyaWin';
	font-size: 16px;
}
.Err22
{
	font-size: 22px;
	color: #000000;
	border-left: 10px solid #EEEEEE;
	padding-left: 10px;
	border-style: solid;
	border-width: 1px 1px 1px 10px;
	border-color: #0099FF;
}
.Err22 u
{
	color: Red;
}
.Err22 b
{
	color: Green;
}
.ol li
{
	margin:10px;
	color:Red;
}
ol.rules li
{
	font-size:16px;
}
.menuItems,.menuItems li
{
	font-size: 20px;
	color: #111111;
	line-height: 50px;
}
input
{
	font-family: 'Vani';
}
.err
{
	font-size: 48px;
	line-height: 50px;
	color: Blue;
}
.err10
{
	font-size: 24px;
	line-height: 28px;
	color: Blue;
}
li
{
	 font-size:24px;
}
.copyright
{
	font-size: 20px;
	color: #666666;
}
.gErr
{
	background-color: gray !important;
	color: Red;
}
.gOk
{
	background-color: white;
}
.ok
{
	color: Green;
	font-size: 32px;
}
.gName
{
	color: Red;
	font-weight: bold;
}
.yati
{
	color: #FF8000;
}
.y1
{
	font-style: italic;
}
.res
{
	width: 98%;
}
.Z
{
	background-color: #FFFFFF;
	width: 2px;
}
.Y
{
	border-color: Green;
	height: 2px;
}
.stamper
{
	color: Black;
	width: 25px;
	background-color: #DDDDDD;
	border-right: solid 1px red;
	border-left: solid 1px #CCCCCC;
}
.X3
{
	background-color: #FFFFFF;
	border-right: solid 1px #eebbee;
	border-bottom: solid 1px #CCCCCC;
	text-align: center;
}
.X
{
	background-color: #FFFFFF;
	border-right: solid 1px #eebbee;
	text-align: center;
}
.ga
{
	color: Green;
	font-size: 16px;
	background-color: #FFFFFF;
}
.up
{
	font-size: 16px;
	color: Red;
	background-color: #FFFFFF;
}
.dw
{
	color: Black;
	font-size: 16px;
	border: solid 1px Green;
	background-color: #FFFFFF;
}
.tab
{
	border-top: solid 1px #CCCCCC;
	border-right: solid 1px #CCCCCC;
	border-bottom: solid 1px #CCCCCC;
	border-collapse:collapse;
	text-align: center;
	width: 100%;
}
.errTab
{
	text-align: left;
	border-collapse: collapse;
	width: 100%;
	margin-left: 10px;
	color: Black;
	font-size:18px;
}

.credits
{
	font-size: 36px;
	text-align: right;
	top: 10px;
	position: static;
}
textarea.src
{
	height: 120px;
	font-size: 18px;
	background-color: #FFFFFF;
	text-align: left;
	padding: 10px;
	margin: 2px;
	border: dotted 1px green;
	line-height: 30px;
	width: 90%;
	color: #000000;
}
div.src
{
	margin-top: 10px;
	margin-bottom: 10px;
}
.debugger
{
	width: 200px;
	height: 200px;
	overflow: auto;
	text-align: left;
	border: 1px solid #EEEEEE;
	position: absolute;
	top: 20px;
	left: 20px;
	font-family: Tahoma;
	font-size: 12px;
	color: Black;
	display: none;
}
.info
{
	color: #101010;
	font-family: Tahoma;
	font-size: 9px;
}
select
{
	font-size: 18px;
	margin-left: 5px;
	margin-right: 5px;
	width: 1uto;
}
ol.poems li
{
	cursor: pointer;
	color:Black;
}
.number
{
	text-align: right;
}
em
{
	font-size: 10px;
}

.high
{
	font-size: 16px;
	color: blue;
}

div.horizontal
{
	height: 63px;
	width: 100%;
}
div.horizontal ul
{
	list-style-type: none;
	margin: 0;
	padding: 0;
}
div.horizontal li
{
	float: left;
}
div.horizontal a
{
	display: block;
}
div.horizontal a:link, div.horizontal a:visited
{
	font-weight: bold;
	color: black;
	text-align: center;
	padding: 4px;
	text-decoration: none;
	background-color: #EEEEEE;
	border: 1px solid #CCCCCC;
}
div.horizontal a:hover, div.horizontal a:active
{
	background-color: #CCCCCC;
	border: 1px solid #EEEEEE;
}
.not
{
	color: #DDDDDD !important;
	text-transform: uppercase;
}
.button
{
	color: #FFFFFF !important;
	font-size: 18px;
	text-align: center;
	text-transform: uppercase;
	padding: 2px;
	cursor: pointer;
}
.button:hover
{
	background: #74A599 !important;
}

a.Teal:link, a.Teal:visited, input.Teal
{
	color: #FFFFFF !important;
	background-color: #008299 !important;
	border: 1px solid #00A0B1 !important;
}
a.Teal:hover, a.Teal:active
{
	color: #FFFFFF !important;
	background-color: #00A0B1 !important;
	border: 1px solid #008299 !important;
}

a.Blue:link, a.Blue:visited, input.Blue
{
	color: #FFFFFF !important;
	background-color: #2672EC !important;
	border: 1px solid #2E8DEF !important;
}
a.Blue:hover, a.Blue:active
{
	color: #FFFFFF !important;
	background-color: #2E8DEF !important;
	border: 1px solid #2672EC !important;
}

a.Purple:link, a.Purple:visited, input.Purple
{
	color: #FFFFFF !important;
	background-color: #8C0095 !important;
	border: 1px solid #A700AE !important;
}
a.Purple:hover, a.Purple:active
{
	color: #FFFFFF !important;
	background-color: #A700AE !important;
	border: 1px solid #8C0095 !important;
}

a.Red:link, a.Red:visited, input.Red
{
	color: #FFFFFF !important;
	background-color: #AC193D !important;
	border: 1px solid #BF1E4B !important;
}
a.Red:hover, a.Red:active
{
	color: #FFFFFF !important;
	background-color: #BF1E4B !important;
	border: 1px solid #AC193D !important;
}

a.Orange:link, a.Orange:visited, input.Orange
{
	color: #FFFFFF !important;
	background-color: #D24726 !important;
	border: 1px solid #DC572E !important;
}
a.Orange:hover, a.Orange:active
{
	color: #FFFFFF !important;
	background-color: #DC572E !important;
	border: 1px solid #D24726 !important;
}

a.Green:link, a.Green:visited, input.Green
{
	color: #FFFFFF !important;
	background-color: #008A00 !important;
	border: 1px solid #00A600 !important;
}
a.Green:hover, a.Green:active
{
	color: #FFFFFF !important;
	background-color: #00A600 !important;
	border: 1px solid #008A00 !important;
}

a.SkyBlue:link, a.SkyBlue:visited, input.SkyBlue
{
	color: #FFFFFF !important;
	background-color: #094AB2 !important;
	border: 1px solid #0A5BC4 !important;
}
a.SkyBlue:hover, a.SkyBlue:active
{
	color: #FFFFFF !important;
	background-color: #0A5BC4 !important;
	border: 1px solid #094AB2 !important;
}
.Black
{
	color: #000000 !important;
}
div.power
{
	clear: both;
	font-weight: bold;
	color: Red;
	text-align: right;
}
div.Green
{
	color: Green;
}
.title,.footer
{
 font-size:48px;
}
.footer,.header
{
	clear:left;
	text-align:center;
	font-size:24px;
}
.header
{
	float:right;
}
.debug  b
{
	color:Red;
}
.yIn
{
	margin-top:5px;
	padding:10px;
	width:30px;
	text-align:right;
}
";
	}
}
