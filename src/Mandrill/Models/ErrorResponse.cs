// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ErrorResponse.cs" company="">
//   
// </copyright>
// <summary>
//   The error response.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Newtonsoft.Json;

namespace Mandrill.Models
{
  /// <summary>
  ///   The error response.
  /// </summary>
  public class ErrorResponse
  {
    #region Fields

    /// <summary>
    ///   The code.
    /// </summary>
    public int Code { get; set; }

    /// <summary>
    ///   The message.
    /// </summary>
    public string Message { get; set; }

    /// <summary>
    ///   The name.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    ///   The status.
    /// </summary>
    public string Status { get; set; }

    #endregion
  }
}