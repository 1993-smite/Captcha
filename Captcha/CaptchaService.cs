﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Captcha
{
    public class CaptchaService
    {
        public CaptchaService()
        {

        }

        public string Generate(string fileName) { 
            string captcha = GenerateRandomString(); 
            int height = 50;
            int width = 180;

            Random random = new Random();
            using (Bitmap bmp = new Bitmap(width, height)) { 
                using (Graphics g = Graphics.FromImage(bmp)) { 
                    g.Clear(Color.LightSlateGray); 
                    g.SmoothingMode = SmoothingMode.AntiAlias; 
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic; 
                    g.PixelOffsetMode = PixelOffsetMode.HighQuality;

                    for (int i = 0; i < random.Next(2, 9); i++)
                    {
                        g.DrawLine(new Pen(GetColor(random.Next(0, 5)), 1),
                              new Point(0, random.Next(0, height)),
                              new Point(width - 1, random.Next(0, height)));
                    }

                    for (int i = 0; i < random.Next(25, 40); i++)
                    {
                        g.DrawEllipse(new Pen(GetColor(random.Next(0, 5)), 1), 
                            random.Next(0, width), 
                            random.Next(0, height), 2, 2);
                    }

                    g.RotateTransform(random.Next(-6,6));

                    var fontArt = new Font("Arial", 18, FontStyle.Italic);
                    float leftMrgn = 15;
                    for (int index = 0; index < captcha.Length; index++)
                    {
                        var art = captcha[index].ToString();
                        var sizeF = g.MeasureString(art, fontArt);
                        g.DrawString(art, fontArt, GetBrushes(random.Next(0, 9)), new PointF(leftMrgn, 9));
                        leftMrgn += sizeF.Width;
                    }

                    //g.DrawRectangle(new Pen(Color.LightGray), 1, 1, width - 2, height - 2); 
                    g.Flush();


                    bmp.Save(fileName, ImageFormat.Jpeg);
                } 
            } 
            return captcha; 
        }

        private Color GetColor(int clr)
        {

            switch (clr)
            {
                case 0: return Color.FromArgb(33, 169, 219);
                case 1: return Color.FromArgb(241, 189, 67);
                case 2: return Color.FromArgb(154, 35, 122);
                case 3: return Color.FromArgb(240, 83, 74); //37,58,146
                case 4: return Color.FromArgb(37, 58, 146);
                case 5: return Color.FromArgb(37, 146, 42);
                default: return Color.White;
            }
        }

        private Brush GetBrushes(int clr)
        {
            switch (clr)
            {
                case 0: return Brushes.Red;
                case 1: return Brushes.Blue;
                case 2: return Brushes.Black;
                case 3: return Brushes.Green;
                case 4: return Brushes.Indigo;
                case 5: return Brushes.DarkKhaki;
                case 6: return Brushes.DarkGoldenrod;
                case 7: return Brushes.YellowGreen;
                case 8: return Brushes.DarkSlateGray;
                case 9: return Brushes.DarkOrange;
                default: return Brushes.Black;
            }
        }

        private StringFormat GetStringFormat(int clr)
        {
            var sf = new StringFormat();
            switch (clr)
            {
                case 0:
                    sf.FormatFlags = StringFormatFlags.NoFontFallback;
                    break;
                case 1:
                    sf.FormatFlags = StringFormatFlags.DirectionVertical;
                    break;
                case 2:
                    sf.FormatFlags = StringFormatFlags.NoWrap;
                    break;
                case 3:
                    sf.FormatFlags = StringFormatFlags.NoWrap;
                    break;
                case 4:
                    sf.FormatFlags = StringFormatFlags.NoWrap;
                    break;
                case 5:
                    sf.FormatFlags = StringFormatFlags.NoWrap;
                    break;
                default:
                    sf.FormatFlags = StringFormatFlags.NoWrap;
                    break;
            }

            return sf;
        }

        private string GenerateRandomString() 
        { 
            Random random = new Random(); 
            string combination = "0123456789АБВГДЖИКЛМНПРСТУФХЧЮЯабвгдежиклмнпрстуфхчюя"; 
            StringBuilder sb = new StringBuilder(); 
            for (int i = 0; i < 6; i++) 
                sb.Append(combination[random.Next(combination.Length)]); 
            return sb.ToString(); 
        }


    }
}