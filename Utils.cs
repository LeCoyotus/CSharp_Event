using System;
using System.Collections.Generic;

namespace ExoMusicShopEvent
{
	public static class Utils
	{
		public static Random Rng = new Random();

		public static List<string> AlbumsNames = new List<string>(){"ToToTaTa", "Bad Liar", "Now u're go", "Yes I am", "Is A GiRoUd"};
		public static int Roll(int n)
		{
			return Rng.Next(0, n);
		}

		public static string RandomName()
		{
			return AlbumsNames[Roll(AlbumsNames.Count)];
		}

		public static bool IsAlbumWish()
		{
			return Roll(4) < 3;
		}

		public static int SetPrice()
		{
			return Rng.Next(10, 40);
		}
	}
}