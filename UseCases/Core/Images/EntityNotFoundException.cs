﻿using System;
using System.Runtime.Serialization;

namespace UseCases.Core.Images
{
    [Serializable]
    public class EntityNotFoundException : ApiException
    {
        public EntityNotFoundException()
        {
        }

        public EntityNotFoundException(string message) : base(message)
        {
        }

        public EntityNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EntityNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}