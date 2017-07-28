using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = null;
            try
            {
                host = new ServiceHost(typeof(VideoStream));
                host.Open();
            }
            catch (CommunicationException e)
            {
                host.Abort();
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            Console.WriteLine("Server is running...");
            Console.ReadKey();
            host.Close();

        }
    }
}
