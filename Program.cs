using System;
using System.Collections.Generic;

namespace ExoMusicShopEvent
{
	class Program
	{
		static void Main(string[] args)
		{
			Artist artistMika = new Artist("Mika");
			Artist artistPascal = new Artist("Pascal Obispo");

			List<Artist> Artists = new List<Artist>(){artistMika, artistPascal};

			Customer custJean = new Customer("Jean", 40);
			Customer custDidier = new Customer("Didier", 22);
			Customer custRaoul = new Customer("Raoul", 100);

			List<Customer> Customers = new List<Customer>(){custJean, custDidier, custRaoul};

			artistMika.PreviewAlbumEventHandler += custJean.OnAlbumPreview;
			artistMika.PreviewAlbumEventHandler += custDidier.OnAlbumPreview;

			artistPascal.PreviewAlbumEventHandler += custRaoul.OnAlbumPreview;

			artistMika.NewAlbumEventHandler += custJean.OnAlbumRelease;
			artistMika.NewAlbumEventHandler += custDidier.OnAlbumRelease;

			artistPascal.NewAlbumEventHandler += custRaoul.OnAlbumRelease;


			for (int i = 0; i < 5; i++)
			{
				foreach (var artist in Artists)
				{
					artist.Preview();
					artist.ReleaseAlbum();
				}
			}

			foreach (var customer in Customers)
			{
				customer.DisplayHisAlbums();
				customer.DisplayHisWish();
			}
		}
	}
}
