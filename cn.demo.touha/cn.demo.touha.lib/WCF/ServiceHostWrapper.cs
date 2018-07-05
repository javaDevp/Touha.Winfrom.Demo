using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace cn.demo.touha.lib.WCF
{
    /// <summary>
    /// 宿主封装
    /// </summary>
    public class ServiceHostWrapper
    {
        #region Fields
        private ServiceHost serviceHost;

        private WCFConfiguration wcfConfiguration;

        private string releasePostfix = "/wsdl";
        #endregion

        public string ReleasePostfix
        {
            get { return releasePostfix; }
            set { releasePostfix = value; }
        }

        #region Events
        public event EventHandler Started;

        public event EventHandler Stopped;

        public event EventHandler Exceptioned;
        #endregion

        #region Constructors
        public ServiceHostWrapper()
            :this(null)
        {

        }

        public ServiceHostWrapper(WCFConfiguration wcfConfiguration)
        {
            this.wcfConfiguration = wcfConfiguration;
        }
        #endregion

        public void Start(Type t)
        {
            try
            {
                serviceHost = new ServiceHost(t);
                if (wcfConfiguration != null)
                {
                    serviceHost.AddServiceEndpoint(wcfConfiguration.ContractDescription.ContractType, wcfConfiguration.Binding, wcfConfiguration.EndpointAddress.Uri);
                }
                //发布元数据信息
                if(serviceHost.Description.Behaviors.Find<ServiceMetadataBehavior>() == null)
                {
                    var metadataBehavior = new ServiceMetadataBehavior();
                    metadataBehavior.HttpGetEnabled = true;
                    metadataBehavior.HttpGetUrl = new Uri(wcfConfiguration.EndpointAddress.Uri + ReleasePostfix);
                    serviceHost.Description.Behaviors.Add(metadataBehavior);
                }
                serviceHost.Opened += ServiceHost_Opened;
                serviceHost.Open();
            }catch(Exception ex)
            {
                if(Exceptioned != null)
                {
                    Exceptioned(ex, null);
                }
            }
        }

        private void ServiceHost_Opened(object sender, EventArgs e)
        {
            if(Started != null)
            {
                Started(sender, e);
            }
        }

        public void Stop()
        {
            try
            {
                serviceHost.Closed += ServiceHost_Closed;
                serviceHost.Close();
            }catch(Exception ex)
            {
                if(Exceptioned != null)
                {
                    Exceptioned(ex, null);
                }
            }
        }

        private void ServiceHost_Closed(object sender, EventArgs e)
        {
            //Closed?.Invoke(sender, e);
            if(Stopped != null)
            {
                Stopped(sender, e);
            }
        }
    }
}
