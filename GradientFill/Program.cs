using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradientFill
{
    struct RGBColor
    {
        public static readonly RGBColor EMPTY = new RGBColor(0x00);
        public static readonly RGBColor FULL = new RGBColor(0xFF);

        int colorValue;
        public int ColorValue
        {
            get { return colorValue; }
        }

        public RGBColor(int color)
        {
            colorValue = color;
        }

        public static RGBColor operator ++(RGBColor color)
        {
            if (color.colorValue != 0xFF)
                color.colorValue++;

            return color;
        }

        public static RGBColor operator --(RGBColor color)
        {
            if (color.colorValue != 0x00)
                color.colorValue--;

            return color;
        }

        public static bool operator <(RGBColor color1, RGBColor color2)
        {
            return color1.colorValue < color2.colorValue;
        }

        public static bool operator >(RGBColor color1, RGBColor color2)
        {
            return color1.colorValue > color2.colorValue;
        }

        public static RGBColor operator+(RGBColor color, int inc)
        {
            if (0xFF >= (color.colorValue + inc))
                color.colorValue += inc;
            else
                color.colorValue = 0xFF;
                
            return color;
        }

        public static RGBColor operator -(RGBColor color, int dec)
        {
            if (0 < (color.colorValue - dec))
                color.colorValue -= dec;
            else
                color.colorValue = 0x00;

            return color;
        }

        public string ToString(string format)
        {
            return (colorValue.ToString(format));
        }
    }
    
    struct RGB
    {
        public RGBColor Red;
        public RGBColor Green;
        public RGBColor Blue;

        public RGB(RGBColor red, RGBColor green, RGBColor blue)
        {
            Red = red;
            Green = green;
            Blue = blue;
        }

        public static readonly RGB RED 
            = new RGB(RGBColor.FULL, RGBColor.EMPTY, RGBColor.EMPTY);

        public static readonly RGB DARKED
            = new RGB(new RGBColor(128), RGBColor.FULL, RGBColor.EMPTY);

        public static readonly RGB BLUE
            = new RGB(RGBColor.EMPTY, RGBColor.EMPTY, RGBColor.FULL);

        public static readonly RGB WHITE
            = new RGB(RGBColor.FULL, RGBColor.FULL, RGBColor.FULL);

        public static readonly RGB BLACK
            = new RGB(RGBColor.EMPTY, RGBColor.EMPTY, RGBColor.EMPTY);

        public override string ToString()
        {
            return (Red.ToString("X2") + Green.ToString("X2") 
                + Blue.ToString("X2"));
        }
    }

    class Program
    {
        static void PrintRGBValue(RGB rgb)
        {
            Console.Write("{0}", rgb);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Getting RGB values for gradient fill (dark red -> red)\n");

            for (RGB rgb = RGB.DARKED; rgb.Red < RGBColor.FULL; rgb.Red+=5)
            {
                PrintRGBValue(rgb);
            }

            Console.ReadLine();
        }
    }
}
