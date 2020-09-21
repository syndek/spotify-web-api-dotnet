﻿using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Spotify.ObjectModel.Serialization
{
    public sealed class SectionConverter : JsonConverter<Section>
    {
        public override Section? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType is not JsonTokenType.StartObject)
            {
                throw new JsonException();
            }

            Single start = default;
            Single duration = default;
            Single confidence = default;
            Single loudness = default;
            Single tempo = default;
            Single tempoConfidence = default;
            Int32 key = default;
            Single keyConfidence = default;
            Modality? mode = null;
            Single modeConfidence = default;
            Int32 timeSignature = default;
            Single timeSignatureConfidence = default;

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
                    case "start":
                        start = reader.GetSingle();
                        break;
                    case "duration":
                        duration = reader.GetSingle();
                        break;
                    case "confidence":
                        confidence = reader.GetSingle();
                        break;
                    case "loudness":
                        loudness = reader.GetSingle();
                        break;
                    case "tempo":
                        tempo = reader.GetSingle();
                        break;
                    case "tempo_confidence":
                        tempoConfidence = reader.GetSingle();
                        break;
                    case "key":
                        key = reader.GetInt32();
                        break;
                    case "key_confidence":
                        keyConfidence = reader.GetSingle();
                        break;
                    case "mode":
                        var modeValue = reader.GetInt32();
                        if (modeValue != -1)
                        {
                            mode = (Modality) modeValue;
                        }
                        break;
                    case "mode_confidence":
                        modeConfidence = reader.GetSingle();
                        break;
                    case "time_signature":
                        timeSignature = reader.GetInt32();
                        break;
                    case "time_signature_confidence":
                        timeSignatureConfidence = reader.GetSingle();
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            return new(
                start,
                duration,
                confidence,
                loudness,
                tempo,
                tempoConfidence,
                key,
                keyConfidence,
                mode,
                modeConfidence,
                timeSignature,
                timeSignatureConfidence);
        }

        public override void Write(Utf8JsonWriter writer, Section value, JsonSerializerOptions options) => throw new NotSupportedException();
    }
}