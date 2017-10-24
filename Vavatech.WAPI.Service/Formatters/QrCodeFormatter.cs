using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Web;
using Vavatech.WAPI.Models;

namespace Vavatech.WAPI.Service.Formatters
{
    public class QrCodeFormatter : MediaTypeFormatter
    {
        public QrCodeFormatter()
        {
            SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("image/png"));
        }

        public override bool CanReadType(Type type)
        {
            return false;
        }

        public override bool CanWriteType(Type type)
        {
            return type == typeof(User);
        }

        public override async Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content, TransportContext transportContext)
        {
            var user = value as User;
            var uri = $"https://chart.googleapis.com/chart?cht=qr&chs=300x300&chl={user.Pesel}";
            using (var client = new WebClient())
            {
                var imgBinary = await client.DownloadDataTaskAsync(uri);
                await writeStream.WriteAsync(imgBinary, 0, imgBinary.Length);
            }
        }
    }
}