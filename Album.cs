namespace ExoMusicShopEvent
{
	public class Album
	{
		public string Name { get; set; }
		public int Cost { get; set; }

		public Artist Owner { get; set; }
		public Album(string name, int cost, Artist owner)
		{
			Name = name;
			Cost = cost;
			Owner = owner;
		}

		public override string ToString()
		{
			string str = $" Album's name : {Name} // Cost : {Cost} // Artist's Name : {Owner.Name}";
			return str;
		}
	}
}