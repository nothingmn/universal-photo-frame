using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;
using PhotoFrame.Common;

namespace PhotoFrame
{
    public class SampleImageSource : IImageSource
    {
        public int current = 1;

        public async Task<BitmapImage> NextImage()
        {
            current++;
            if (current > 6) current = 1;
            var src = string.Format("ms-appx:///Assets/Samples/{0}.png", current);
            var uri = new Uri(src, UriKind.RelativeOrAbsolute);
            Debug.WriteLine(string.Format("new image loaded:{0}", src));
            var file = await Windows.Storage.StorageFile.GetFileFromApplicationUriAsync(uri);

            using (var fileStream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read))
            {
                // Set the image source to the selected bitmap
                BitmapImage bitmapImage = new BitmapImage();

                await bitmapImage.SetSourceAsync(fileStream);
                return bitmapImage;
            }

            //return await Task.FromResult(new BitmapImage(uri));

        }
    }
}