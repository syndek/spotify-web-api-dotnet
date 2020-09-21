﻿using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Spotify.ObjectModel.Serialization
{
    public sealed class AudioFeaturesConverter : JsonConverter<AudioFeatures>
    {
        public override AudioFeatures? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType is not JsonTokenType.StartObject)
            {
                throw new JsonException();
            }

            var uriConverter = options.GetConverter<Uri>();

            String id = String.Empty;
            Uri uri = null!;
            Uri trackHref = null!;
            Uri analysisUrl = null!;
            Int32 duration = default;
            Int32 timeSignature = default;
            Int32 key = default;
            Int32 mode = default;
            Single acousticness = default;
            Single danceability = default;
            Single energy = default;
            Single instrumentalness = default;
            Single liveness = default;
            Single loudness = default;
            Single speechiness = default;
            Single tempo = default;
            Single valence = default;

            while (reader.Read())
            {
                if (reader.TokenType is JsonTokenType.EndObject)
                {
                    break;
                }

                if (reader.TokenType is not JsonTokenType.PropertyName)
                {
                    throw new JsonException();
                }

                var propertyName = reader.GetString();

                reader.Read(); // Read to next token.

                switch (propertyName)
                {
                    case "id":
                        id = reader.GetString()!;
                        break;
                    case "uri":
                        uri = uriConverter.Read(ref reader, typeof(Uri), options)!;
                        break;
                    case "track_href":
                        trackHref = uriConverter.Read(ref reader, typeof(Uri), options)!;
                        break;
                    case "analysis_url":
                        analysisUrl = uriConverter.Read(ref reader, typeof(Uri), options)!;
                        break;
                    case "duration":
                        duration = reader.GetInt32();
                        break;
                    case "time_signature":
                        timeSignature = reader.GetInt32();
                        break;
                    case "key":
                        key = reader.GetInt32();
                        break;
                    case "mode":
                        mode = reader.GetInt32();
                        break;
                    case "acousticness":
                        acousticness = reader.GetSingle();
                        break;
                    case "danceability":
                        danceability = reader.GetSingle();
                        break;
                    case "energy":
                        energy = reader.GetSingle();
                        break;
                    case "instrumentalness":
                        instrumentalness = reader.GetSingle();
                        break;
                    case "liveness":
                        liveness = reader.GetSingle();
                        break;
                    case "loudness":
                        loudness = reader.GetSingle();
                        break;
                    case "speechiness":
                        speechiness = reader.GetSingle();
                        break;
                    case "tempo":
                        tempo = reader.GetSingle();
                        break;
                    case "valence":
                        valence = reader.GetSingle();
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            return new(
                id,
                uri,
                trackHref,
                analysisUrl,
                duration,
                timeSignature,
                key,
                mode,
                acousticness,
                danceability,
                energy,
                instrumentalness,
                liveness,
                loudness,
                speechiness,
                tempo,
                valence);
        }

        public override void Write(Utf8JsonWriter writer, AudioFeatures value, JsonSerializerOptions options)
        {
            var uriConverter = options.GetConverter<Uri>();

            writer.WriteStartObject();
            writer.WriteString("id", value.Id);
            writer.WritePropertyName("uri");
            uriConverter.Write(writer, value.Uri, options);
            writer.WritePropertyName("track_href");
            uriConverter.Write(writer, value.TrackHref, options);
            writer.WritePropertyName("analysis_url");
            uriConverter.Write(writer, value.AnalysisUrl, options);
            writer.WriteNumber("duration", value.Duration);
            writer.WriteNumber("time_signature", value.TimeSignature);
            writer.WriteNumber("key", value.Key);
            writer.WriteNumber("mode", value.Mode);
            writer.WriteNumber("acousticness", value.Acousticness);
            writer.WriteNumber("danceability", value.Danceability);
            writer.WriteNumber("energy", value.Energy);
            writer.WriteNumber("instrumentalness", value.Instrumentalness);
            writer.WriteNumber("liveness", value.Liveness);
            writer.WriteNumber("loudness", value.Loudness);
            writer.WriteNumber("speechiness", value.Speechiness);
            writer.WriteNumber("tempo", value.Tempo);
            writer.WriteNumber("valence", value.Valence);
            writer.WriteEndObject();
        }
    }
}