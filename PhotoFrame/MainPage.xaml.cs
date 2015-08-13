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
using PhotoFrame.Forecastio;

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

            _imageSource = new SampleImageSource();
            //_imageSource = new FlickrImageSource();

            _weatherProvder = new ForecastIOWeatherProvider("e00f670f07d9d46cb17b239cfb178bf1");

            _timer = new Timer(Callback, null, TimeSpan.FromSeconds(5), TimeSpan.FromMinutes(10));
            _timeTimer = new Timer(UpdateTime, null, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1));
            _weatherTimer = new Timer(UpdateWeather, null, TimeSpan.FromSeconds(5), TimeSpan.FromMinutes(61));

        }

        private IWeatherProvider _weatherProvder;
        private static string _weatherLocation = "49.2622727,-122.9945667";


        private async void UpdateWeather(object state)
        {
            var report = await _weatherProvder.GetWeatherReport(_weatherLocation);
            if (report != null)
            {
                await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
                    delegate
                    {
                        Current.Text = string.Format("{0}°C", Math.Round(report.CurrentTemperature, 1));
                        Summary.Text = report.Summary;
                    });

            }
        }

        private async void UpdateTime(object state)
        {
            await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
                delegate
                {
                    TimeText.Text = DateTime.Now.ToString("F");
                });
        }

        private async void Callback(object state)
        {
            await NextImage();
        }

        private System.Threading.Timer _timer;
        private System.Threading.Timer _weatherTimer;
        private System.Threading.Timer _timeTimer;

        private IImageSource _imageSource = null;

        public async Task NextImage()
        {
            try
            {

                await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync( CoreDispatcherPriority.Normal, async () =>
                    {
                        ImageFadeOut.Begin();
                        var image = await _imageSource.NextImage();
                        this.MainImage.Source = image;
                        ImageFadeIn.Begin();
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