// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MandrillException.cs" company="">
//   
// </copyright>
// <summary>
//   General Exception that is thrown by the Mandrill Api
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Net;
using System.Net.Http;
using Mandrill.Models;
using Mandrill.Requests;

namespace Mandrill.Utilities
{
  /// <summary>
  ///   General Exception that is thrown by the Mandrill Api
  /// </summary>
  public class MandrillException : Exception
  {
    #region Constructors and Destructors

    /// <summary>
    ///   Initializes a new instance of the <see cref="MandrillException" /> class.
    /// </summary>
    public MandrillException()
    {
    }

    /// <summary>
    ///   Initializes a new instance of the <see cref="MandrillException" /> class.
    /// </summary>
    /// <param name="message">
    ///   The message.
    /// </param>
    public MandrillException(string message)
      : base(message, new Exception(message))
    {
    }

    /// <summary>
    ///   Initializes a new instance of the <see cref="MandrillException" /> class.
    /// </summary>
    /// <param name="error">
    ///   The error.
    /// </param>
    /// <param name="message">
    ///   The message.
    /// </param>
    public MandrillException(ErrorResponse error, string message)
      : base(message, new Exception(error.Message))
    {
      Error = error;
    }

    /// <summary>
    ///   Initializes a new instance of the <see cref="MandrillException" /> class.
    /// </summary>
    /// <param name="message">
    ///   The message.
    /// </param>
    /// <param name="innerException">
    ///   The inner exception.
    /// </param>
    public MandrillException(string message, Exception innerException)
      : base(message, innerException)
    {
    }
    
    #endregion

    #region Public Properties

    /// <summary>
    ///   Gets the error.
    /// </summary>
    public ErrorResponse Error { get; private set; }


    /// <summary>
    ///   Gets the response message if any
    /// </summary>
    public HttpResponseMessage HttpResponseMessage { get; set; }

    /// <summary>
    ///   Gets the mandrill request used.
    /// </summary>
    public RequestBase MandrillRequest { get; set; }
    #endregion
  }
}