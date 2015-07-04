using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace APG.GDIHelpers
{
    public static class GDIHelper
    {
        public static PointF GetPointForCenterString(Graphics graphics, Rectangle rectangle, string Message, Font font, int margin, string spacer, out string formatedMessage)
        {
            SizeF size = graphics.MeasureString(Message, font);

            if (size.Width > rectangle.Width - margin)
            {                
                StringBuilder resultStr = new StringBuilder(Message.Length + spacer.Length);
                resultStr.Append(Message);
                while ((resultStr.Length > 0) && (size.Width > rectangle.Width - margin))
                {
                    resultStr = resultStr.Remove(resultStr.Length - 1, 1);
                    size = graphics.MeasureString(resultStr.ToString() + spacer, font);
                }

                if (resultStr.Length > 0)
                {
                    formatedMessage = resultStr.ToString() + spacer;
                    return new PointF(margin, rectangle.Height / 2);
                }
                else
                {
                    formatedMessage = string.Empty;
                    return PointF.Empty;
                }
            }
            else
            {
                formatedMessage = Message;
                return new PointF((rectangle.Width / 2) - (size.Width / 2), (rectangle.Height / 2) - (font.SizeInPoints / 2));
            }
        }
       
        public static PointF GetPointForCenterString(Graphics graphics, Rectangle rectangle, string Message, Font font)
        {
            SizeF size = graphics.MeasureString(Message, font);
            return new PointF((rectangle.Width / 2) - (size.Width / 2), (rectangle.Height / 2) - (font.SizeInPoints / 2));
        }

        public static PointF GetPointForCenterString(Graphics graphics, int x, int y, int width, int height, string Message, Font font)
        {
            return GetPointForCenterString(graphics, new Rectangle(x, y, width, height), Message, font);
        }
    }
}
