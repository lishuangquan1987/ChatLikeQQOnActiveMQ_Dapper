using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace ChatLikeQQOnActiveMQ.Common
{
   public class PathHelper
    {
        public static string GetTextPath(string word, string fontFamily, int fontSize)
        {
            Typeface typeface = new Typeface(new FontFamily(fontFamily), FontStyles.Normal, FontWeights.Normal, FontStretches.Normal);
            return GetTextPath(word, typeface, fontSize);
        }

        private static string GetTextPath(string word, Typeface typeface, int fontSize)
        {
            FormattedText text = new FormattedText(word,
                new System.Globalization.CultureInfo("zh-cn"),
                FlowDirection.LeftToRight, typeface, fontSize,
                Brushes.Black);

            Geometry geo = text.BuildGeometry(new Point(0, 0));
            PathGeometry path = geo.GetFlattenedPathGeometry();

            return path.ToString();
        }
    }
}
