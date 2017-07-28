using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Basler.Pylon;

namespace ConsoleApp2
{
    public class VideoStream 
    {
        private static byte[] buffer;
        private static IGrabResult lastestResult;

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
                    camera.Parameters[PLCameraInstance.MaxNumBuffer].SetValue(5);

                    // Start grabbing.
                    camera.StreamGrabber.Start();
                    //camera.StreamGrabber.ImageGrabbed += ImageCaptured;
                    while (true)
                    {
                        IGrabResult grabResult = camera.StreamGrabber.RetrieveResult(5000, TimeoutHandling.ThrowException);
                        using (grabResult)
                        {
                            if (grabResult.GrabSucceeded)
                            {
                                Console.WriteLine("SizeX: {0}", grabResult.Width);
                                Console.WriteLine("SizeY: {0}", grabResult.Height);
                                buffer = grabResult.PixelData as byte[];
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
                            }
                        }
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
            Environment.Exit(exitCode);
        }

        private void ImageCaptured(object sender, ImageGrabbedEventArgs e)
        {
            //try
            //{
            //    result = e.GrabResult.Clone();
            //    lastestResult = result.Clone();
            //}
            //catch (Exception ex)
            //{
            //    Debug.WriteLine(ex.Message);
            //}
        }

        public Stream GetStream()
        {
            MemoryStream ms;
            if ( buffer != null && buffer.Length>0)
            {
                ms = new MemoryStream(buffer);
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
            return new List<string>() { "sssss", "sdsdsdsd" };
        }

        public Stream StreamingVideo()
        {
            return new MemoryStream();
        }
    }
}

