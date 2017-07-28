using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Imaging;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using App5.ServiceReference1;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App5
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private VideoStreamClient _client;
        public MainPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _client = new VideoStreamClient();
            _client.StartPreviewAsync("21929310");
            base.OnNavigatedTo(e);
        }

        private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            await NewMethod();
        }

        private async Task NewMethod()
        {
            try
            {
                while (true)
                {
                    byte[] buffer = await _client.GetStreamAsync();
                    //Stream stream = await _client.GetStreamAsync();
                    //await stream.ReadAsync(buffer, 0, 1280 * 960);
                    SoftwareBitmap softwareBitmap = SoftwareBitmap.CreateCopyFromBuffer(buffer.AsBuffer(), BitmapPixelFormat.Gray8, 1280, 960);
                    if (softwareBitmap.BitmapPixelFormat != BitmapPixelFormat.Bgra8 ||
                        softwareBitmap.BitmapAlphaMode == BitmapAlphaMode.Straight)
                    {
                        softwareBitmap = SoftwareBitmap.Convert(softwareBitmap, BitmapPixelFormat.Bgra8, BitmapAlphaMode.Premultiplied);
                    }
                    var source = new SoftwareBitmapSource();
                    await source.SetBitmapAsync(softwareBitmap);

                    // Set the source of the Image control
                    Image.Source = source;
                    await Task.Delay(500);
                }

                //WriteableBitmap bitmap = new WriteableBitmap(softwareBitmap.PixelWidth, softwareBitmap.PixelHeight);
                //softwareBitmap.CopyFromBuffer(bitmap.PixelBuffer);
                //Image.Source = bitmap;
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
                throw;
            }
        }
    }
}
