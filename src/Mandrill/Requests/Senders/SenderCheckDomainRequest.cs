using Newtonsoft.Json;

namespace Mandrill.Requests.Senders
{
  public class SenderCheckDomainRequest : RequestBase
  {
    public SenderCheckDomainRequest(string domain)
    {
      Domain = domain;
    }

    [JsonProperty("domain")]
    public string Domain { get; set; }
  }
}