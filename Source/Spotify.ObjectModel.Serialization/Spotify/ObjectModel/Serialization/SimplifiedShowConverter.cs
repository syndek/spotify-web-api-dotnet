﻿using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Spotify.ObjectModel.Serialization
{
    using CopyrightArray = IReadOnlyList<Copyright>;
    using CountryCodeArray = IReadOnlyList<CountryCode>;
    using ExternalUrls = IReadOnlyDictionary<String, Uri>;
    using ImageArray = IReadOnlyList<Image>;
    using StringArray = IReadOnlyList<String>;

    public sealed class SimplifiedShowConverter : JsonConverter<SimplifiedShow>
    {
        public override SimplifiedShow? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType is not JsonTokenType.StartObject)
            {
                throw new JsonException();
            }

            var copyrightArrayConverter = options.GetConverter<CopyrightArray>();
            var countryCodeArrayConverter = options.GetConverter<CountryCodeArray>();
            var externalUrlsConverter = options.GetConverter<ExternalUrls>();
            var imageArrayConverter = options.GetConverter<ImageArray>();
            var stringArrayConverter = options.GetConverter<StringArray>();
            var uriConverter = options.GetConverter<Uri>();

            String id = String.Empty;
            Uri uri = null!;
            Uri href = null!;
            String name = String.Empty;
            String description = String.Empty;
            ImageArray images = Array.Empty<Image>();
            Boolean isExplicit = default;
            StringArray languages = Array.Empty<String>();
            CountryCodeArray availableMarkets = Array.Empty<CountryCode>();
            String mediaType = String.Empty;
            String publisher = String.Empty;
            CopyrightArray copyrights = Array.Empty<Copyright>();
            Boolean? isExternallyHosted = null;
            ExternalUrls externalUrls = null!;

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
                    case "href":
                        href = uriConverter.Read(ref reader, typeof(Uri), options)!;
                        break;
                    case "name":
                        name = reader.GetString()!;
                        break;
                    case "description":
                        description = reader.GetString()!;
                        break;
                    case "images":
                        images = imageArrayConverter.Read(ref reader, typeof(ImageArray), options)!;
                        break;
                    case "explicit":
                        isExplicit = reader.GetBoolean();
                        break;
                    case "languages":
                        languages = stringArrayConverter.Read(ref reader, typeof(StringArray), options)!;
                        break;
                    case "available_markets":
                        availableMarkets = countryCodeArrayConverter.Read(ref reader, typeof(CountryCodeArray), options)!;
                        break;
                    case "media_type":
                        mediaType = reader.GetString()!;
                        break;
                    case "publisher":
                        publisher = reader.GetString()!;
                        break;
                    case "copyrights":
                        copyrights = copyrightArrayConverter.Read(ref reader, typeof(CopyrightArray), options)!;
                        break;
                    case "is_externally_hosted":
                        reader.Read();
                        isExternallyHosted = reader.TokenType switch
                        {
                            JsonTokenType.Null => null,
                            JsonTokenType.True => true,
                            JsonTokenType.False => false,
                            _ => throw new JsonException()
                        };
                        break;
                    case "external_urls":
                        externalUrls = externalUrlsConverter.Read(ref reader, typeof(ExternalUrls), options)!;
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            return new(
                id,
                uri,
                href,
                name,
                description,
                images,
                isExplicit,
                isExternallyHosted,
                languages,
                availableMarkets,
                mediaType,
                publisher,
                copyrights,
                externalUrls);
        }

        public override void Write(Utf8JsonWriter writer, SimplifiedShow value, JsonSerializerOptions options) => throw new NotImplementedException();
    }
}