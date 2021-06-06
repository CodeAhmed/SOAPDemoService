using SOAPDemoService;
using System;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Security;
using System.Threading.Tasks;
using WebServiceDemo.Server.Service.Interfaces;

namespace WebServiceDemo.Server.Service
{
    public class SoapDemoApi : ISoapDemoApi
    {
        public readonly string serviceUrl = "https://www.crcind.com:443/csp/samples/SOAP.Demo.cls";
        public readonly EndpointAddress endpointAddress;
        public readonly BasicHttpBinding basicHttpBinding;

        public SoapDemoApi()
        {
            endpointAddress = new EndpointAddress(serviceUrl);

            basicHttpBinding =
                new BasicHttpBinding(endpointAddress.Uri.Scheme.ToLower() == "http" ?
                            BasicHttpSecurityMode.None : BasicHttpSecurityMode.Transport);
        }
        public async Task<Address> GetCityDetails(string zipCode)
        {
            var client = new SOAPDemoSoapClient(basicHttpBinding, endpointAddress);

            //Bypass Certificate Validation in Soap
            //client.ChannelFactory.Credentials.ServiceCertificate.SslCertificateAuthentication =
            //    new X509ServiceCertificateAuthentication
            //    {
            //        CertificateValidationMode = X509CertificateValidationMode.None,
            //        RevocationMode = X509RevocationMode.NoCheck,
            //        TrustedStoreLocation = StoreLocation.LocalMachine
            //    };

            var response = await client.LookupCityAsync(zipCode);
            return response;
        }
    }
}
