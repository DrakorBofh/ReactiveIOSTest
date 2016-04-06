using System;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;


namespace ReactiveIOSTest
{
	public static class ColorMixin
	{

		public static Color FromHexString(this Color color, string hexValue)
		{
			var colorString = hexValue.Replace("#", "");

			int red, green, blue;

			switch (colorString.Length)
			{
			case 3: // #RGB
				{
					red = Convert.ToInt32(string.Format("{0}{0}", colorString.Substring(0, 1)), 16);
					green = Convert.ToInt32(string.Format("{0}{0}", colorString.Substring(1, 1)), 16);
					blue = Convert.ToInt32(string.Format("{0}{0}", colorString.Substring(2, 1)), 16);
					return Color.FromArgb(255, red, green, blue);
				}

			case 6: // #RRGGBB
				{
					red = Convert.ToInt32(colorString.Substring(0, 2), 16);
					green = Convert.ToInt32(colorString.Substring(2, 2), 16);
					blue = Convert.ToInt32(colorString.Substring(4, 2), 16);
					return Color.FromArgb(255, red, green, blue);
				}

			default:
				return Color.Black;
			}
		}

		public static Color Bold(this Color color)
		{
			return Color.White.FromHexString ("#113F8C");
		}
		public static Color SMooth(this Color color)
		{
			return Color.White.FromHexString ("#01A4A4");
		}
		public static Color SundayMint(this Color color)
		{
			return Color.White.FromHexString ("#00A1CB");
		}
		public static Color FResh(this Color color)
		{
			return Color.White.FromHexString ("#61AE24");
		}
		public static Color YellowGreen(this Color color)
		{
			return Color.White.FromHexString ("#D0D102");
		}
		public static Color HEartfelt(this Color color)
		{
			return Color.White.FromHexString ("#32742C");
		}
		public static Color Micadormissador(this Color color)
		{
			return Color.White.FromHexString ("#D70060");
		}
		public static Color Love(this Color color)
		{
			return Color.White.FromHexString ("#E54028");
		}
		public static Color GIMME(this Color color)
		{
			return Color.White.FromHexString ("#F18D05");
		}

		public static Color MURAL(this Color color)
		{
			return Color.White.FromHexString ("#FB0651");
		}

		public static Color GetPalletteRandom(this Color color)
		{
			Random rnd = new Random();
			int val = rnd.Next(1, 10);
			switch (val)
			{
			case 1:
				return Color.White.SMooth();
			case 2:
				return Color.White.SundayMint();
			case 3:
				return Color.White.FResh();
			case 4:
				return Color.White.HEartfelt();
			case 5:
				return Color.White.HEartfelt();
			case 6:
				return Color.White.Micadormissador();
			case 7:
				return Color.White.Love();
			case 8:
				return Color.White.GIMME();
			default:
				return Color.White.Bold();
			}
		}
	}
}

