using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
namespace VEE.Util
{
    public static class ImageUtil
    {
        public enum ImageType
        {
            Png,
            Xpng,
            Gif,
            Jpg,
            Jpeg,
            None,
        }

        public static Dictionary<string, ImageType> ImageTypes = new Dictionary<string, ImageType>
        {
            {".jpg", ImageType.Jpg},
            {".jpeg",ImageType.Jpeg},
            {".png",ImageType.Png},
            {".x-png",ImageType.Xpng},
            {".gif",ImageType.Gif}
        };

        public static Dictionary<ImageType, ImageFormat> ImageFormats = new Dictionary<ImageType, ImageFormat>
        {
            {ImageType.Jpg, ImageFormat.Jpeg},
            {ImageType.Jpeg, ImageFormat.Jpeg},
            {ImageType.Png, ImageFormat.Png},
            {ImageType.Xpng, ImageFormat.Png},
            {ImageType.Gif, ImageFormat.Gif}
        };

        public static byte[] ToByteArray(this Image image, ImageType type)
        {
            MemoryStream ms = new MemoryStream();
            image.Save(ms, ImageFormats[type]);
            return ms.ToArray();
        }

        public static Image ToImage(this byte[] byteArrayIn)
        {
            if (byteArrayIn == null || byteArrayIn.Length == 0)
            {
                return null;
            }
            ImageConverter converter = new ImageConverter();
            return (Image)converter.ConvertFrom(byteArrayIn);
        }

        public static Image ScaleImage(this Image image, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);

            using (var graphics = Graphics.FromImage(newImage))
                graphics.DrawImage(image, 0, 0, newWidth, newHeight);

            return newImage;
        }

    }
}