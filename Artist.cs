using System;
using System.Collections.Generic;

namespace ExoMusicShopEvent
{
	public class Artist
	{
		public string Name { get; set; }
		public List<Album> Discography { get; set; }

		public event EventHandler<NewAlbumEventArgs> NewAlbumEventHandler;
		public event EventHandler<NewAlbumEventArgs> PreviewAlbumEventHandler;

		public Artist(string name)
		{
			Name = name;
			Discography = new List<Album>();
		}

		public void Preview()
		{
			Console.WriteLine("A new album is coming...");

			int cost = Utils.SetPrice();
			Album album = new Album(Utils.RandomName(), cost, this);
			Console.WriteLine($"[EXCLUSIV NEW] => { album } at only { cost }");
			NewAlbumEventArgs albumArgs = new NewAlbumEventArgs(album);

			OnPreviewEvent(albumArgs);
			Discography.Add(album);
		}

		public void ReleaseAlbum()
		{
			if (Discography.Count > 0)
			{
				int albumIndex = Discography.Count - 1;
				Album album = Discography[albumIndex];
				NewAlbumEventArgs albumArgs = new NewAlbumEventArgs(album);
				OnNewAlbumEvent(albumArgs);
			}
		}
		public void OnNewAlbumEvent(NewAlbumEventArgs args)
		{
			NewAlbumEventHandler?.Invoke(this, args);
		}

		public void OnPreviewEvent(NewAlbumEventArgs args)
		{
			PreviewAlbumEventHandler?.Invoke(this, args);
		}
	}
}