#nullable enable

using System;
using System.IO;
using System.Runtime.Serialization;
using System.Text;

namespace RollingRess;

public static class Serializer
{
    /// <summary>
    /// Serializes data as string
    /// </summary>
    /// <param name="data">Data to serialize</param>
    /// <returns>Serialized data</returns>
    public static string Serialize<T>(in T data)
    {
        DataContractSerializer serializer = new(typeof(T));
        using MemoryStream stream = new();
        serializer.WriteObject(stream, data);
        stream.Position = 0;
        using StreamReader streamReader = new(stream);
        return streamReader.ReadToEnd();
    }

    /// <summary>
    /// Deserialize data from string
    /// </summary>
    /// <typeparam name="T">Type to deserialize</typeparam>
    /// <param name="xml">Serialized string</param>
    /// <returns>Deserialized data. If an error occured, default(T)</returns>
    public static T? Deserialize<T>(string? xml)
    {
        if (xml is null)
            return default;
        try
        {
            byte[] data = Encoding.UTF8.GetBytes(xml);
            using MemoryStream stream = new();
            stream.Write(data, 0, data.Length);
            stream.Position = 0;
            DataContractSerializer deserializer = new(typeof(T));

            T result = (T)Convert.ChangeType(deserializer.ReadObject(stream), typeof(T));
            return result;
        }
        catch
        {
            return default;
        }
    }

    public static T? Deserialize<T>(object? xml) => xml is null ? default : Deserialize<T>(xml.ToString());
}
