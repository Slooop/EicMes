using System;
using System.Runtime.Serialization;

namespace Lm.App.Eic.Mes.EF.Business
{
    [Serializable]
    internal class RepoitoryException : Exception
    {
        public RepoitoryException()
        {
        }

        public RepoitoryException(string message) : base(message)
        {
        }

        public RepoitoryException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RepoitoryException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}