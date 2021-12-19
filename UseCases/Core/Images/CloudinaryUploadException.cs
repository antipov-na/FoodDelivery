using System;
using System.Runtime.Serialization;

namespace UseCases.Core.Images
{
    [Serializable]
    public class CloudinaryUploadException : ApiException
    {
        public CloudinaryUploadException()
        {
        }

        public CloudinaryUploadException(string message) : base(message)
        {
        }

        public CloudinaryUploadException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CloudinaryUploadException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}