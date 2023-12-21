﻿// RemeaMiku(Wuhan University)
//  Email:2020302142257@whu.edu.cn

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using NaviSharp.SpatialReference;

namespace NaviSharp.Serialization.Json;

public class EcefCoordJsonConverter : JsonConverter<EcefCoord>
{
    public override EcefCoord Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var x = reader.GetDouble();
        var y = reader.GetDouble();
        var z = reader.GetDouble();
        return new(x, y, z);
    }

    public override void Write(Utf8JsonWriter writer, EcefCoord value, JsonSerializerOptions options)
    {
        var xPropertyName = options.PropertyNamingPolicy?.ConvertName(nameof(value.X)) ?? nameof(value.X);
        var yPropertyName = options.PropertyNamingPolicy?.ConvertName(nameof(value.Y)) ?? nameof(value.Y);
        var zPropertyName = options.PropertyNamingPolicy?.ConvertName(nameof(value.Z)) ?? nameof(value.Z);
        writer.WriteStartObject();
        writer.WriteNumber(xPropertyName, value.X);
        writer.WriteNumber(yPropertyName, value.Y);
        writer.WriteNumber(zPropertyName, value.Z);
        writer.WriteEndObject();
    }
}
