namespace MyPhotoshop.Data
{
	public class Photo
	{
		public readonly int Width;
		public readonly int Height;
		private readonly Pixel[,] data;

		public Photo(int width, int height)
		{
			this.Width = width;
			this.Height = height;
			data = new Pixel[width, height];
		}

        public Pixel this[int x, int y]
		{
			get => data[x, y];
			set => data[x, y] = value;
		}
    }
}

