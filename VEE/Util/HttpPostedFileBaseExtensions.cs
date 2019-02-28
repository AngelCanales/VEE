using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VEE.Util; 
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;

namespace VEE.Util
{
    public static class HttpPostedFileBaseExtensions
    {
        public static byte[] ToByteArray(this HttpPostedFileBase file)
        {
            var img = Image.FromStream(file.InputStream, true, true);
            var imgType = file.GetImageType();
            return img.ToByteArray(imgType);
        }

        public const int ImageMinimumBytes = 512;

        public static bool IsImage(this HttpPostedFileBase file)
        {
            //-------------------------------------------
            //  Check the image mime types
            //-------------------------------------------
            if (file.ContentType.ToLower() != "image/jpg" &&
                        file.ContentType.ToLower() != "image/jpeg" &&
                        file.ContentType.ToLower() != "image/pjpeg" &&
                        file.ContentType.ToLower() != "image/gif" &&
                        file.ContentType.ToLower() != "image/x-png" &&
                        file.ContentType.ToLower() != "image/png")
            {
                return false;
            }

            //-------------------------------------------
            //  Check the image extension
            //-------------------------------------------
            if (Path.GetExtension(file.FileName).ToLower() != ".jpg"
                && Path.GetExtension(file.FileName).ToLower() != ".png"
                && Path.GetExtension(file.FileName).ToLower() != ".gif"
                && Path.GetExtension(file.FileName).ToLower() != ".jpeg")
            {
                return false;
            }

            //-------------------------------------------
            //  Attempt to read the file and check the first bytes
            //-------------------------------------------
            try
            {
                if (!file.InputStream.CanRead)
                {
                    return false;
                }

                if (file.ContentLength < ImageMinimumBytes)
                {
                    return false;
                }

                byte[] buffer = new byte[512];
                file.InputStream.Read(buffer, 0, 512);
                string content = System.Text.Encoding.UTF8.GetString(buffer);
                if (Regex.IsMatch(content, @"<script|<html|<head|<title|<body|<pre|<table|<a\s+href|<img|<plaintext|<cross\-domain\-policy",
                    RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Multiline))
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }

            //-------------------------------------------
            //  Try to instantiate new Bitmap, if .NET will throw exception
            //  we can assume that it's not a valid image
            //-------------------------------------------

            try
            {
                using (var bitmap = new System.Drawing.Bitmap(file.InputStream))
                {
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }


        public static VEE.Util.ImageUtil.ImageType GetImageType(this HttpPostedFileBase file)
        {
            var extension = Path.GetExtension(file.FileName).ToLower();
            if (ImageUtil.ImageTypes.ContainsKey(extension))
            {
                return ImageUtil.ImageTypes[extension];
            }
            return VEE.Util.ImageUtil.ImageType.None;
        }
    }
}