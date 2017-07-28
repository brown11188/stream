using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;
using Basler.Pylon;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "VideoStream" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select VideoStream.svc or VideoStream.svc.cs at the Solution Explorer and start debugging.
    public class VideoStream : IVideoStream, IDisposable
    {
        private static IGrabResult result;
        private IGrabResult lastestResult;

        public void StartPreview(string cameraSerialNumber)
        {
            // The exit code of the sample application.
            int exitCode = 0;

            try
            {
                // Create a camera object that selects the first camera device found.
                // More constructors are available for selecting a specific camera device.
                using (Camera camera = new Camera(cameraSerialNumber))
                {
                    // Print the model name of the camera.
                    Console.WriteLine("Using camera {0}.", camera.CameraInfo[CameraInfoKey.ModelName]);

                    // Set the acquisition mode to free running continuous acquisition when the camera is opened.
                    camera.CameraOpened += Configuration.AcquireContinuous;

                    // Open the connection to the camera device.
                    camera.Open();

                    // The parameter MaxNumBuffer can be used to control the amount of buffers
                    // allocated for grabbing. The default value of this parameter is 10.
                    camera.Parameters[PLCameraInstance.MaxNumBuffer].SetValue(10);

                    // Start grabbing.
                    camera.StreamGrabber.Start();
                    //camera.StreamGrabber.ImageGrabbed += ImageCaptured;
                    while (true)
                    {
                        result = camera.StreamGrabber.RetrieveResult(5000, TimeoutHandling.ThrowException);
                    }

                    //// Stop grabbing.
                    //camera.StreamGrabber.Stop();

                    //// Close the connection to the camera device.
                    //camera.Close();
                }
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("Exception: {0}", e.Message);
                exitCode = 1;
            }
            //finally
            //{
            //    // Comment the following two lines to disable waiting on exit.
            //    Console.Error.WriteLine("\nPress enter to exit.");
            //    Console.ReadLine();
            //}
        }

        private void ImageCaptured(object sender, ImageGrabbedEventArgs e)
        {
            try
            {
                result = e.GrabResult.Clone();
                lastestResult = result.Clone();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public void Dispose()
        {

        }


        private static void CaptureImage(Camera camera)
        {
            IGrabResult grabResult = camera.StreamGrabber.RetrieveResult(5000, TimeoutHandling.ThrowException);
            using (grabResult)
            {
                while (true)
                {
                    // Image grabbed successfully?
                    if (grabResult.GrabSucceeded)
                    {
                        //// Access the image data.
                        Console.WriteLine("SizeX: {0}", grabResult.Width);
                        Console.WriteLine("SizeY: {0}", grabResult.Height);
                        byte[] buffer = grabResult.PixelData as byte[];
                        Console.WriteLine("Gray value of first pixel: {0}", buffer[0]);
                        Console.WriteLine("Gray value of first pixel: {0}", buffer[1]);
                        Console.WriteLine("Gray value of first pixel: {0}", buffer[2]);
                        Console.WriteLine("Gray value of first pixel: {0}", buffer[3]);
                        Console.WriteLine("Gray value of first pixel: {0}", buffer[4]);
                        Console.WriteLine("Gray value of first pixel: {0}", buffer[5]);
                        Console.WriteLine("Gray value of first pixel: {0}", buffer[6]);
                        Console.WriteLine("Gray value of first pixel: {0}", buffer[7]);
                        Console.WriteLine("Color format type: {0}", grabResult.PixelTypeValue);
                        Console.WriteLine("Length: {0}", buffer.Length);
                        Console.WriteLine("");
                        // Display the grabbed image.
                        ImageWindow.DisplayImage(0, grabResult);
                    }
                    else
                    {
                        Console.WriteLine("Error: {0} {1}", grabResult.ErrorCode, grabResult.ErrorDescription);
                    }
                }
            }
        }


        public Stream GetStream()
        {
            MemoryStream ms =new MemoryStream();
            if (result != null)
            {
                lock (result)
                {
                }
                ms.Position = 0;
                return ms;
            }
            else
            {
                return null;
            }
        }

        public List<string> GetList()
        {
            return new List<string>(){ "sssss", "sdsdsdsd" };
        }
    }
}
