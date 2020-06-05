using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace FuhoCommerce.HttpUtility
{
    public class SelfSignedCertificateHandler : HttpClientHandler
    {
        public SelfSignedCertificateHandler()
        {
            ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
            {
                //Return `true` to allow certificates
                var result = cert.Subject.ToLower().Contains("localhost");
                return result;
            };
        }

        public static HttpClient CreateHttpClient()
        {
            return new HttpClient(new SelfSignedCertificateHandler());
        }
    }
}
