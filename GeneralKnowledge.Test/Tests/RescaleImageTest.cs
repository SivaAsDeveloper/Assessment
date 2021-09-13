using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Net;

namespace GeneralKnowledge.Test.App.Tests
{
    /// <summary>
    /// Image rescaling
    /// </summary>
    public class RescaleImageTest : ITest
    {
        public enum RescaleOptions
        {
            thumnail,
            preview
        }
        public void Run()
        {
            // TODO
            // Grab an image from a public URL and write a function that rescales the image to a desired format
            // The use of 3rd party plugins is permitted
            // For example: 100x80 (thumbnail) and 1200x1600 (preview)

            Image img = Image.FromFile(GetImageFromPublic("https://pluralsight.imgix.net/paths/path-icons/csharp-e7b8fcd4ce.png"));
            Bitmap bitmap = new Bitmap(img);
            Image previewimage = resizeImage(bitmap, RescaleOptions.preview);
            previewimage.Save("reziedimagepreview.jpg");
            Console.WriteLine($"After Resize - Preview Image Size : {previewimage.Width} X {previewimage.Height}");
            Image thumbnail = resizeImage(bitmap, RescaleOptions.thumnail);
            thumbnail.Save("reziedimagethumbnail.jpg");
            Console.WriteLine($"After Resize - Thumbnail Image Size : {thumbnail.Width} X {thumbnail.Height}");
        }
        private string GetImageFromPublic(string publicpath)
        {
            string downloadedImage = "image.png";
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    webClient.DownloadFile(publicpath, downloadedImage);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return downloadedImage;
        }
        private Image resizeImage(Image imgToResize, RescaleOptions rescaleOptions)
        {
            Size size = GetSize(rescaleOptions);
            int destWidth = (int)size.Width;
            int destHeight = (int)size.Height;
            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();
            return (Image)b;
        }
        private Size GetSize(RescaleOptions rescaleOptions)
        {
            switch (rescaleOptions)
            {
                case RescaleOptions.thumnail:
                    return new Size(80, 100);
                case RescaleOptions.preview:
                    return new Size(1600, 1200);
                default:
                    throw new Exception("Rescale Option is not defined");
            }
        }
    }
}
