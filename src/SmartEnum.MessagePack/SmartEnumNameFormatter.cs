namespace Ardalis.SmartEnum.MessagePack
{
    using System;
    using global::MessagePack;
    using global::MessagePack.Formatters;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEnum"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public sealed class SmartEnumNameFormatter<TEnum, TValue> : IMessagePackFormatter<TEnum>
        where TEnum : SmartEnum<TEnum, TValue>
        where TValue : struct, IEquatable<TValue>, IComparable<TValue>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="options"></param>
        public void Serialize(ref MessagePackWriter writer, TEnum value, MessagePackSerializerOptions options)
        {
            if (value is null) return;

            writer.Write(value.Name);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public TEnum Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            var name = reader.ReadString();
            return SmartEnum<TEnum, TValue>.FromName(name);
        }
    }
}