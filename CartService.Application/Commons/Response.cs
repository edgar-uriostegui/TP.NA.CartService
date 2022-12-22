using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartService.Application.Commons
{
    #region Interfaces

    /// <summary>
    /// Interface by Response
    /// </summary>
    public interface IResponse
    {
        /// <summary>
        /// Indicate if has error
        /// </summary>
        bool IsError { get; set; }
        /// <summary>
        /// List of errors
        /// </summary>
        List<ValidationMessage> Errors { get; set; }
    }

    #endregion

    #region Response 
    public class Response<T> : IResponse
    {
        /// <summary>
        /// Data to return
        /// </summary>
        public T Payload { get; set; }

        /// <summary>
        /// Is error
        /// </summary>
        public bool IsError { get; set; } = false;

        /// <summary>
        /// List of errors
        /// </summary>
        public List<ValidationMessage> Errors { get; set; }

        /// <summary>
        /// Set a failure response
        /// </summary>
        /// <param name="property"></param>
        /// <param name="message"></param>
        public void SetFailureResponse(string property, string message)
        {
            IsError = true;
            Errors = new List<ValidationMessage>
            {
                new ValidationMessage
                {
                    Message = message,
                    Property = property
                }
            };
        }

        /// <summary>
        /// Set a failure response
        /// </summary>
        /// <param name="errors"></param>
        public void SetFailureResponse(List<ValidationMessage> errors)
        {
            IsError = true;
            Errors.AddRange(errors);
        }
    }

    #endregion

    #region Validation messages

    public class ValidationMessage
    {
        /// <summary>
        /// Property
        /// </summary>
        public string Property { get; set; }
        /// <summary>
        /// Message
        /// </summary>
        public string Message { get; set; }
    }

    #endregion
}
