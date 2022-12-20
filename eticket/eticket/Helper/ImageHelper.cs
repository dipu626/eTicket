using static System.Net.Mime.MediaTypeNames;
using System.Resources;

namespace eticket.Helper
{
    public class ImageHelper
    {
        public static string GetLogo()
        {
            string path = Directory.GetCurrentDirectory() + @"\Resources\images\logo\logo.jpg";
            if (File.Exists(path))
            {
                return path;
            }
            return "";
        }
    }
}
