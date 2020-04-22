namespace ExoMusicShopEvent
{
	public class NewAlbumEventArgs
	{
		public Album Album { get; set; }

		public NewAlbumEventArgs(Album album)
		{
			Album = album;
		}

	}
}