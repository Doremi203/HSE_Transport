using System.Runtime.Serialization;

namespace EKRLib;

/// <summary>
/// Исключение для транспорта
/// </summary>

[Serializable]
public class TransportException : Exception {
    public TransportException(string? message) : base(message) { }

    public TransportException() { }

    public TransportException(SerializationInfo info, StreamingContext context) : base(info, context) { }

    public TransportException(string? message, Exception? innerException) : base(message, innerException) { }
}