using System.Net.Mime;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace FacesApiTest
{
    public class ImageUtility
    {
        public byte[] ConvertToBytes(string imagePath)
        {
            MemoryStream memoryStream = new MemoryStream();
            using(FileStream stream = new FileStream(imagePath, FileMode.Open))
            {
                stream.CopyTo(memoryStream);
            }

            var bytes = memoryStream.ToArray();
            return bytes;
        }

        public void FromBytesToImage(byte[] imageBytes, string fileName)
        {
            using(var ms = new MemoryStream(imageBytes))
            {
                Image img = Image.FromStream(ms);
                img.Save(fileName + ".jpg", ImageFormat.Jpeg);
            }
        }
    }
}