using System;
using System.Drawing;

// Shout out
// http://martin.ankerl.com/2009/12/09/how-to-create-random-colors-programmatically/

namespace CSChat
{
	public static class ColorGenerator
	{
		private static double GRC = 0.618033988749895;
		private static double H;
		private static bool once;
		public static Color GetColor()
		{
			if (!once)
			{
				var rand = new Random();
				H = rand.Next();
				once = true;
			}
			H += GRC;
			H %= 1;
			return HsvToRgb(H, 0.9, 0.95);
		}

		private static Color HsvToRgb(double h, double s, double v)
		{
			var hI = (int)(h * 6);
			var f = h * 6 - hI;
			var p = v * (1 - s);
			var q = v * (1 - f * s);
			var t = v * (1 - (1 - f) * s);
			switch (hI)
			{
			case 0:
				return Color.FromArgb((int)(v * 256), (int)(t * 256), (int)(p * 256));
			case 1:
				return Color.FromArgb((int)(q * 256), (int)(v * 256), (int)(p * 256));
			case 2:
				return Color.FromArgb((int)(p * 256), (int)(v * 256), (int)(t * 256));
			case 3:
				return Color.FromArgb((int)(p * 256), (int)(q * 256), (int)(v * 256));
			case 4:
				return Color.FromArgb((int)(t * 256), (int)(p * 256), (int)(v * 256));
			case 5:
				return Color.FromArgb((int)(v * 256), (int)(p * 256), (int)(q * 256));
			}
			return Color.Black;
		}
	}
}