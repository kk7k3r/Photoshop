﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyPhotoshop
{
    public struct Pixel
    {

        public Pixel(double r, double g, double b) : this()
        {
            R = r;
            G = g;
            B = b;
        }

        private double r;
        public double R
        {
            get
            {
                return r;
            }
            set
            {
                r = CheckValue(value);
            }
        }
        private double g;
        public double G
        {
            get
            {
                return g;
            }
            set
            {
                g = CheckValue(value);
            }
        }
        private double b;
        public double B
        {
            get
            {
                return b;
            }
            set
            {
                b = CheckValue(value);
            }
        }

        private double CheckValue(double value)
        {
            if (value > 1 || value < 0)
            {
                throw new ArgumentException();
            }

            else
            {
                return value;
            }
        }

        public static Pixel operator *(Pixel pixel, double c)
        {
            return new Pixel(Pixel.Trim(pixel.r * c), Pixel.Trim(pixel.g * c), Pixel.Trim(pixel.b * c));
        }
        public static Pixel operator *(double c, Pixel pixel)
        {
            return pixel * c;
        }

        public static double Trim(double value)
        {
            if (value < 0)
            {
                return 0;
            }
            if (value > 1)
            {
                return 1;
            }
            return value;
        }
    }
}
