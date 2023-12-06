using System.Text.Json.Serialization;

namespace Mandrill.Requests.Senders
{
  public class SenderCheckDomainRequest : RequestBase
  {
    public SenderCheckDomainRequest(string domain)
    {
      Domain = domain;
    }

    [JsonPropertyName("domain")]
    public string Domain { get; set; }
  }
}