using System;
using System.Drawing;

namespace CSChat
{
	public static class ColorExtensions
	{
		public static string ToHex(this Color c)
		{
			return "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
		}
	}
}

