using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using RaiteRaju.ProxyService.InformationService;

namespace RaiteRaju.ProxyService
{
    public class InformationProxyService:InformationServiceInterfaceClient,IDisposable
    {

        public InformationProxyService GetRaiteRajuInformationServiceProxy()
        {
            InformationProxyService InformationProxyServiceHelper = new InformationProxyService();
            if (InformationProxyServiceHelper.State != CommunicationState.Opened)
            {
                InformationProxyServiceHelper.Open();
               return InformationProxyServiceHelper;
            }
            else
            {
                return null;
            }
        }
        void IDisposable.Dispose()
        {
            if(this.State==CommunicationState.Faulted){
                this.Abort();
            }
            else if(this.State!=CommunicationState.Closed){
                this.Close();
            }
        }
        
    }
}
