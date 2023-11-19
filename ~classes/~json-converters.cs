using System.Text.Json;
using System.Text.Json.Serialization;

namespace Ans.Net8.Common
{

	/*
     * class BoolConverter : JsonConverter<bool>
     * class AutoNumberToStringConverter : JsonConverter<object>
     * class AutoStringToNumberConverter : JsonConverter<object>
     */



	public class BoolConverter
		: JsonConverter<bool>
	{
		public override bool Read(
			ref Utf8JsonReader reader,
			Type typeToConvert,
			JsonSerializerOptions options)
		{
			return reader.TokenType switch
			{
				JsonTokenType.True => true,
				JsonTokenType.False => false,
				JsonTokenType.String => bool.TryParse(reader.GetString(), out var b1) && b1, //throw new JsonException(),
				JsonTokenType.Number => reader.TryGetInt64(out long l1)
					? Convert.ToBoolean(l1)
					: reader.TryGetDouble(out double d1) && Convert.ToBoolean(d1),
				_ => throw new JsonException(),
			};
		}

		public override void Write(
			Utf8JsonWriter writer,
			bool value,
			JsonSerializerOptions options)
		{
			writer.WriteBooleanValue(value);
		}
	}



	public class AutoNumberToStringConverter
		: JsonConverter<object>
	{
		public override bool CanConvert(
			Type typeToConvert)
		{
			return typeof(string) == typeToConvert;
		}

		public override object Read(
			ref Utf8JsonReader reader,
			Type typeToConvert,
			JsonSerializerOptions options)
		{
			if (reader.TokenType == JsonTokenType.Number)
				return reader.TryGetInt64(out long l1)
					? l1.ToString()
					: reader.GetDouble().ToString();
			if (reader.TokenType == JsonTokenType.String)
				return reader.GetString();
			using var document1 = JsonDocument.ParseValue(ref reader);
			return document1.RootElement.Clone().ToString();
		}

		public override void Write(
			Utf8JsonWriter writer,
			object value,
			JsonSerializerOptions options)
		{
			writer.WriteStringValue(value.ToString());
		}
	}



	public class AutoStringToNumberConverter
		: JsonConverter<object>
	{
		public override bool CanConvert(
			Type typeToConvert)
		{
			/*
			 * see https://stackoverflow.com/questions/1749966/c-sharp-how-to-determine-whether-a-type-is-a-number
			 */
			return Type.GetTypeCode(typeToConvert) switch
			{
				TypeCode.Byte or
				TypeCode.SByte or
				TypeCode.UInt16 or
				TypeCode.UInt32 or
				TypeCode.UInt64 or
				TypeCode.Int16 or
				TypeCode.Int32 or
				TypeCode.Int64 or
				TypeCode.Decimal or
				TypeCode.Double or
				TypeCode.Single => true,
				_ => false,
			};
		}

		public override object Read(
			ref Utf8JsonReader reader,
			Type typeToConvert,
			JsonSerializerOptions options)
		{
			if (reader.TokenType == JsonTokenType.String)
			{
				var s1 = reader.GetString();
				return int.TryParse(s1, out var i1)
					? i1
					: (double.TryParse(s1, out var d1)
						? d1
						: throw new Exception($"unable to parse {s1} to number"));
			}
			if (reader.TokenType == JsonTokenType.Number)
				return reader.TryGetInt64(out long l1)
					? l1 : reader.GetDouble();
			using var document1 = JsonDocument.ParseValue(ref reader);
			throw new Exception($"unable to parse {document1.RootElement} to number");
		}

		public override void Write(
			Utf8JsonWriter writer,
			object value,
			JsonSerializerOptions options)
		{
			var s1 = value.ToString();
			if (int.TryParse(s1, out var i1))
				writer.WriteNumberValue(i1);
			else if (double.TryParse(s1, out var d1))
				writer.WriteNumberValue(d1);
			else
				throw new Exception($"unable to parse {s1} to number");
		}
	}

}
