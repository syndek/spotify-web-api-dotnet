﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Spotify.ObjectModel.Serialization.Tests.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class TestData {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal TestData() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Spotify.ObjectModel.Serialization.Tests.Resources.TestData", typeof(TestData).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {&quot;external_urls&quot;:{&quot;spotify&quot;:&quot;https://open.spotify.com/artist/4pb4rqWSoGUgxm63xmJ8xc&quot;},&quot;followers&quot;:{&quot;href&quot;:null,&quot;total&quot;:542633},&quot;genres&quot;:[&quot;big room&quot;,&quot;complextro&quot;,&quot;edm&quot;,&quot;electro house&quot;,&quot;electropop&quot;,&quot;filter house&quot;,&quot;future bass&quot;,&quot;nantes indie&quot;],&quot;href&quot;:&quot;https://api.spotify.com/v1/artists/4pb4rqWSoGUgxm63xmJ8xc&quot;,&quot;id&quot;:&quot;4pb4rqWSoGUgxm63xmJ8xc&quot;,&quot;images&quot;:[{&quot;height&quot;:640,&quot;url&quot;:&quot;https://i.scdn.co/image/426e0d784cfc0dfe8f3275e32850223232835c14&quot;,&quot;width&quot;:640},{&quot;height&quot;:320,&quot;url&quot;:&quot;https://i.scdn.co/image/d12113789d3953523b7 [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string ArtistJson {
            get {
                return ResourceManager.GetString("ArtistJson", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {&quot;external_urls&quot;:{&quot;spotify&quot;:&quot;https://open.spotify.com/artist/4pb4rqWSoGUgxm63xmJ8xc&quot;},&quot;href&quot;:&quot;https://api.spotify.com/v1/artists/4pb4rqWSoGUgxm63xmJ8xc&quot;,&quot;id&quot;:&quot;4pb4rqWSoGUgxm63xmJ8xc&quot;,&quot;name&quot;:&quot;Madeon&quot;,&quot;type&quot;:&quot;artist&quot;,&quot;uri&quot;:&quot;spotify:artist:4pb4rqWSoGUgxm63xmJ8xc&quot;}.
        /// </summary>
        internal static string SimplifiedArtistJson {
            get {
                return ResourceManager.GetString("SimplifiedArtistJson", resourceCulture);
            }
        }
    }
}