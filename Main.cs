using System;
using System.Windows.Forms;
using System.Drawing;
using MyPhotoshop.Data;
using MyPhotoshop.Filters;
using MyPhotoshop.Filters.Parameters;
using MyPhotoshop.Filters.Transformers;

namespace MyPhotoshop
{
	class MainClass
	{
		[STAThread]
		public static void Main(string[] args)
		{
			var window = new MainWindow();
			window.AddFilter(new PixelFilter<LighteningParameters>(
				"Осветление/затемнение", 
				(pixel, parameters) => pixel * parameters.Coefficient));
			window.AddFilter(new PixelFilter<EmptyParameters>(
				"Оттенки серого", 
				(pixel, parameters) =>
			{
				var lighteness = (pixel.R + pixel.G + pixel.B) / 3;
				return new Pixel(lighteness, lighteness, lighteness);
			}));
			window.AddFilter(new TransformFilter(
				"Отражение по горизонтали", 
				(size) => size, 
				(point, size) => new Point(size.Width - point.X - 1, point.Y)));
            window.AddFilter(new TransformFilter(
	            "Поворот на 90 градусов", 
	            (size) => new Size(size.Height, size.Width), 
	            (point, size) => new Point(point.Y, point.X)));
            window.AddFilter(new TransformFilter<RotationParameters>("Свободное вращение", new RotationTransformer()));
            Application.Run (window);		
		}	
	}
}
