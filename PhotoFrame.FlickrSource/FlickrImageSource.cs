using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;
using PhotoFrame.Common;

namespace PhotoFrame.FlickrSource
{
    public class FlickrImageSource : IImageSource
    {
        private readonly string _source;

        public FlickrImageSource(string source = "https://api.flickr.com/services/feeds/photos_public.gne?format=json&nojsoncallback=1#")
        {
            _source = source;
        }

        private FlickrImages _images = null;
        private int counter = 0;
        private int max = 0;
        public async Task<BitmapImage> NextImage()
        {
            if (_images == null)
            {
                var client = new HttpClient();
                var json = await client.GetStringAsync(_source);
                _images = Newtonsoft.Json.JsonConvert.DeserializeObject<FlickrImages>(json);
                max = _images.items.Count();
            }

            var uri = new Uri(_images.items[counter].media.m, UriKind.RelativeOrAbsolute);
            counter++;
            if (counter >= max) counter = 0;

            return new BitmapImage(uri);
        }
    }
}
