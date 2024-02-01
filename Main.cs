using MyPhotoshop;
using System;
using System.Windows.Forms;
using System.Drawing;

namespace MyPhotoshop
{
	class MainClass
	{
		[STAThread]
		public static void Main(string[] args)
		{
			var window = new MainWindow();
			window.AddFilter(new PixelFilter<LighteningParameters>("����������/����������", (pixel, parameters) => pixel * parameters.Coefficient));
			window.AddFilter(new PixelFilter<EmptyParameters>("�����-����� ������", (pixel, parameters) =>
			{
				var lighteness = (pixel.R + pixel.G + pixel.B) / 3;
				return new Pixel(lighteness, lighteness, lighteness);
			}));
			window.AddFilter(new TransformFilter("�������� �� �����������", (size) => size, (point, size) => new Point(size.Width - point.X - 1, point.Y)));
            window.AddFilter(new TransformFilter("��������� ������ ������� �������", (size) => new Size(size.Height, size.Width), (point, size) => new Point(point.Y, point.X)));
            Application.Run (window);		
		}	
	}
}
