using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace PhotoFrame.Common
{
    public interface IImageSource
    {
        Task<BitmapImage> NextImage();

    }
}
