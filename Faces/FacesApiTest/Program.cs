using System.Net.Http;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace FacesApiTest
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var imagePath = @"oscars-2017.jpg";
            var urlAddress = "http://localhost:5001/api/faces";
            ImageUtility imgUtil = new ImageUtility();
            var bytes = imgUtil.ConvertToBytes(imagePath);
            List<byte[]> faceList = null;
            var byteContent = new ByteArrayContent(bytes);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            using(var httpCliente = new HttpClient())
            {
                using(var response = await httpCliente.PostAsync(urlAddress, byteContent))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    faceList = JsonConvert.DeserializeObject<List<byte[]>>(apiResponse);
                }
            }
            if(faceList.Count > 0)
            {
                for(int i=0; i<faceList.Count; i++)
                {
                    imgUtil.FromBytesToImage(faceList[i], "face"+i);
                }
            }

        }
    }
}
