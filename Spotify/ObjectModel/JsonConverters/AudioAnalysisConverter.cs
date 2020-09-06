﻿using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Spotify.ObjectModel.JsonConverters
{
    internal sealed class AudioAnalysisConverter : JsonConverter<AudioAnalysis>
    {
        internal static readonly AudioAnalysisConverter Instance = new();

        private AudioAnalysisConverter() : base() { }

        public override AudioAnalysis Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            reader.AssertTokenType(JsonTokenType.StartObject);

            IReadOnlyList<TimeInterval> bars = Array.Empty<TimeInterval>();
            IReadOnlyList<TimeInterval> beats = Array.Empty<TimeInterval>();
            IReadOnlyList<Section> sections = Array.Empty<Section>();
            IReadOnlyList<Segment> segments = Array.Empty<Segment>();
            IReadOnlyList<TimeInterval> tatums = Array.Empty<TimeInterval>();

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject)
                {
                    break;
                }

                if (reader.TokenType != JsonTokenType.PropertyName)
                {
                    throw new JsonException();
                }

                switch (reader.GetString())
                {
                    case "bars":
                        reader.Read(JsonTokenType.StartArray);
                        bars = ArrayConverter<TimeInterval>.Instance.Read(ref reader, typeof(IReadOnlyList<TimeInterval>), options);
                        break;
                    case "beats":
                        reader.Read(JsonTokenType.StartArray);
                        beats = ArrayConverter<TimeInterval>.Instance.Read(ref reader, typeof(IReadOnlyList<TimeInterval>), options);
                        break;
                    case "sections":
                        reader.Read(JsonTokenType.StartArray);
                        sections = ArrayConverter<Section>.Instance.Read(ref reader, typeof(IReadOnlyList<Section>), options);
                        break;
                    case "segments":
                        reader.Read(JsonTokenType.StartArray);
                        segments = ArrayConverter<Segment>.Instance.Read(ref reader, typeof(IReadOnlyList<Segment>), options);
                        break;
                    case "tatums":
                        reader.Read(JsonTokenType.StartArray);
                        tatums = ArrayConverter<TimeInterval>.Instance.Read(ref reader, typeof(IReadOnlyList<TimeInterval>), options);
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            return new(bars, beats, sections, segments, tatums);
        }

        public override void Write(Utf8JsonWriter writer, AudioAnalysis value, JsonSerializerOptions options) => throw new NotSupportedException();
    }
}