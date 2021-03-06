﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsoleApp3.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IVideoStream")]
    public interface IVideoStream {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVideoStream/StartPreview", ReplyAction="http://tempuri.org/IVideoStream/StartPreviewResponse")]
        void StartPreview(string number);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVideoStream/StartPreview", ReplyAction="http://tempuri.org/IVideoStream/StartPreviewResponse")]
        System.Threading.Tasks.Task StartPreviewAsync(string number);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVideoStream/GetStream", ReplyAction="http://tempuri.org/IVideoStream/GetStreamResponse")]
        System.IO.Stream GetStream();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVideoStream/GetStream", ReplyAction="http://tempuri.org/IVideoStream/GetStreamResponse")]
        System.Threading.Tasks.Task<System.IO.Stream> GetStreamAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVideoStream/GetList", ReplyAction="http://tempuri.org/IVideoStream/GetListResponse")]
        string[] GetList();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVideoStream/GetList", ReplyAction="http://tempuri.org/IVideoStream/GetListResponse")]
        System.Threading.Tasks.Task<string[]> GetListAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IVideoStreamChannel : ConsoleApp3.ServiceReference1.IVideoStream, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class VideoStreamClient : System.ServiceModel.ClientBase<ConsoleApp3.ServiceReference1.IVideoStream>, ConsoleApp3.ServiceReference1.IVideoStream {
        
        public VideoStreamClient() {
        }
        
        public VideoStreamClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public VideoStreamClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public VideoStreamClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public VideoStreamClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void StartPreview(string number) {
            base.Channel.StartPreview(number);
        }
        
        public System.Threading.Tasks.Task StartPreviewAsync(string number) {
            return base.Channel.StartPreviewAsync(number);
        }
        
        public System.IO.Stream GetStream() {
            return base.Channel.GetStream();
        }
        
        public System.Threading.Tasks.Task<System.IO.Stream> GetStreamAsync() {
            return base.Channel.GetStreamAsync();
        }
        
        public string[] GetList() {
            return base.Channel.GetList();
        }
        
        public System.Threading.Tasks.Task<string[]> GetListAsync() {
            return base.Channel.GetListAsync();
        }
    }
}
