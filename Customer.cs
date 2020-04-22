using System;
using System.Collections.Generic;

namespace ExoMusicShopEvent
{
	public class Customer
	{
		public string Name { get; set; }
		public int Budget { get; set; }

		public List<Album> AlbumOwned { get; set; }

		public List<Album> WishList { get; set; }

		public Customer(string name, int budget)
		{
			Name = name;
			Budget = budget;
			AlbumOwned = new List<Album>();
			WishList = new List<Album>();
		}

		public void OnAlbumRelease(object sender, NewAlbumEventArgs args)
		{
			Album album = args.Album;
			int cost = album.Cost;

			if (WishList.Contains(album))
			{
				Console.WriteLine($"L'album { album.Name } est contenu dans la liste de souhait, voyons si { this.Name } a le budget (budget : { this.Budget }) !");
				if (Budget > cost)
				{
					AlbumOwned.Add(album);
					Budget -= cost;
					WishList.Remove(album);
					Console.WriteLine($"Nouveau budget : { this.Budget }");
				}
				else
				{
					Console.WriteLine("Pas le budget...snif... snif...");
				}
			}
		}

		public void OnAlbumPreview(object sender, NewAlbumEventArgs args)
		{
			Album album = args.Album;
			if (Utils.IsAlbumWish())
			{
				WishList.Add(album);
			}
		}

		public void DisplayHisAlbums()
		{
			Console.WriteLine($"{ this.Name } possède : ");
			foreach (var album in AlbumOwned)
			{
				Console.WriteLine(album);
			}
		}

		public void DisplayHisWish()
		{
			Console.WriteLine($"{ this.Name } désirait encore... ");
			if (WishList.Count > 0)
			{
				foreach (var album in WishList)
				{
					Console.WriteLine(album);
				}
			}
		}
	}
}