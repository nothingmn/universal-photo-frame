using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using PhotoFrame.Common;
using PhotoFrame.FlickrSource;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PhotoFrame
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            //_imageSource = new SampleImageSource();

            _imageSource = new FlickrImageSource();

            _timer = new Timer(Callback, null, TimeSpan.FromMilliseconds(5000), TimeSpan.FromMilliseconds(5000));

        }

        private async void Callback(object state)
        {
            await NextImage();
        }

        private System.Threading.Timer _timer;

        private IImageSource _imageSource = null;

        public async Task NextImage()
        {
            try
            {


                await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync( CoreDispatcherPriority.Normal, async () =>
                    {
                        var image = await _imageSource.NextImage();
                        this.MainImage.Source = image;
                    });


                //                await _imageSource.NextImage().ContinueWith(async t =>
                //                {
                //                    await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(
                //                                                CoreDispatcherPriority.Normal, () =>
                //                                                {
                //                                                    this.MainImage.Source = t.Result;
                //                                                });
                //
                //                }, TaskContinuationOptions.AttachedToParent);

                Debug.WriteLine("new image loaded");
            }
            catch (Exception e)
            {
            }
        }


    }
}