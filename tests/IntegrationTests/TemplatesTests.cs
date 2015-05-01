using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Mandrill.Models;
using Mandrill.Models.Requests;
using NUnit.Framework;

namespace Mandrill.Tests.IntegrationTests
{
  [TestFixture]
  internal class TemplatesTests
  {
    public static bool Validator(object sender, X509Certificate certificate, X509Chain chain,
      SslPolicyErrors sslPolicyErrors)
    {
      return true;
    }

    [TestFixtureSetUp]
    public void Init()
    {
      if (ConfigurationManager.AppSettings["IgnoreInvalidSSLCertificate"] == "True")
        ServicePointManager.ServerCertificateValidationCallback = Validator;
    }

    




  }
}