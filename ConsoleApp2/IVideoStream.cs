using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ConsoleApp2
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IVideoStream" in both code and config file together.
    [ServiceContract]
    public interface IVideoStream
    {
        [OperationContract]
        void StartPreview(string number);
        [OperationContract]
        Stream GetStream();
        [OperationContract]
        List<string> GetList();
        [OperationContract]
        Stream StreamingVideo();
    }
}
