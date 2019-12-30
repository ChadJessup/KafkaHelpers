using System;

namespace KafkaHelpers.Web.App.Models
{
    /// <summary>
    /// ViewModel for Error.
    /// </summary>
    public class ErrorViewModel
    {
        /// <summary>
        /// The RequestId.
        /// </summary>
        public string RequestId { get; set; } = "";

        /// <summary>
        /// Gets whether or not the <see cref="RequestId"/> should be shown.
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
