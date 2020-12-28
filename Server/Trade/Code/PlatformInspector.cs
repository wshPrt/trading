﻿using System;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Channels;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using System.ServiceModel.Web;
using Model.Enum;

namespace Trade.Code
{
    public class PlatformDispatchMessageInspector : IDispatchMessageInspector
    {
        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            string platform = WebOperationContext.Current.IncomingRequest.Headers["platform"];
            if (string.IsNullOrWhiteSpace(platform))
            {
                throw new ApiException(ApiResultEnum.InvalidRequest, "Invalid Request");
            }
            return null;
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {
        }
    }

    public class PlatformEndpointBehavior : IEndpointBehavior
    {
        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            ChannelDispatcher channelDispatcher = endpointDispatcher.ChannelDispatcher;
            if (channelDispatcher != null)
            {
                foreach (EndpointDispatcher ed in channelDispatcher.Endpoints)
                {
                    ed.DispatchRuntime.MessageInspectors.Add(new PlatformDispatchMessageInspector());
                }
                channelDispatcher.ErrorHandlers.Add(new GlobalErrorHandle());
            }
        }

        public void Validate(ServiceEndpoint endpoint)
        {
        }
    }

    public class PlatformBehaviorExtensionElement : BehaviorExtensionElement
    {
        protected override object CreateBehavior()
        {
            return new PlatformEndpointBehavior();
        }

        public override Type BehaviorType
        {
            get
            {
                return typeof(PlatformEndpointBehavior);
            }
        }
    }
}