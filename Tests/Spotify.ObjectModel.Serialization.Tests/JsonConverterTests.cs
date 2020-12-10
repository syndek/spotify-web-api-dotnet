﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.Json;

namespace Spotify.ObjectModel.Serialization.Tests
{
    public abstract class JsonConverterTests<TObject>
    {
        public abstract string TestJson { get; }
        public abstract JsonSerializerOptions SerializerOptions { get; }

        [TestMethod]
        public void RoundTripSerialization()
        {
            var deserialized = JsonSerializer.Deserialize<TObject>(TestJson, SerializerOptions);
            var reserialized = JsonSerializer.Serialize(deserialized, SerializerOptions);

            Assert.AreEqual(
                expected: deserialized,
                actual: JsonSerializer.Deserialize<TObject>(reserialized, SerializerOptions));
        }
    }
}