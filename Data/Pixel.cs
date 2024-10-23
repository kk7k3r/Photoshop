using System;

namespace MyPhotoshop.Data
{
    public struct Pixel
    {
        private double r;
        private double g;
        private double b;
        public double R
        {
            get => r;
            private set
            {
                CheckChannel(value);
                r = value;
            }
        }
        
        public double G
        {
            get => g;
            private set
            {
                CheckChannel(value);
                g = value;
            }
        }
        
        public double B
        {
            get => b;
            private set
            {
                CheckChannel(value);
                b = value;
            }
        }
        public Pixel(double r, double g, double b)
        {
            this.r = this.g = this.b = 0;
            R = r;
            G = g;
            B = b;
        }

        private static void CheckChannel(double channel)
        {
            if (channel < 0 || channel > 1)
            {
                throw new ArgumentException();
            }
        }

        public static Pixel operator *(Pixel pixel, double parameter)
        {
            return new Pixel(Trim(pixel.R * parameter), Trim(pixel.G * parameter), 
                Trim(pixel.B * parameter));
        }
        
        public static Pixel operator /(Pixel pixel, double parameter)
        {
            return new Pixel(Trim(pixel.R / parameter), Trim(pixel.G / parameter), 
                Trim(pixel.B / parameter));
        }
        
        public static Pixel operator *(double c, Pixel pixel)
        {
            return pixel * c;
        }

        private static double Trim(double channel)
        {
            return (channel < 0) ? 0 : (channel > 1) ? 1 : channel;
        }
    }
}