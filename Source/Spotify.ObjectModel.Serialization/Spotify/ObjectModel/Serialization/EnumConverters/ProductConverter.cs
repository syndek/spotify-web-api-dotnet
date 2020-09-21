﻿using System;

namespace Spotify.ObjectModel.Serialization.EnumConverters
{
    public static class ProductConverter : Object
    {
        public static Product FromSpotifyString(String product) => product switch
        {
            "free" => Product.Free,
            "premium" => Product.Premium,
            _ => throw new ArgumentException($"Invalid {nameof(Product)} string value: {product}", nameof(product))
        };

        public static String ToSpotifyString(this Product product) => product switch
        {
            Product.Free => "free",
            Product.Premium => "premium",
            _ => throw new ArgumentException($"Invalid {nameof(Product)} value: {product}", nameof(product))
        };
    }
}