﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Demokrata.SystemSettings.Application.Common.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class CommonMessages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal CommonMessages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Demokrata.SystemSettings.Application.Common.Resources.CommonMessages", typeof(CommonMessages).Assembly);
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
        ///   Looks up a localized string similar to El campo KeyWord no puede superar los 200 caracteres.
        /// </summary>
        internal static string KeyWordLength {
            get {
                return ResourceManager.GetString("KeyWordLength", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to El campo KeyWord es requerido.
        /// </summary>
        internal static string KeyWordRequired {
            get {
                return ResourceManager.GetString("KeyWordRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to El identificador del campo es requerido.
        /// </summary>
        internal static string SystemSettingIDRequired {
            get {
                return ResourceManager.GetString("SystemSettingIDRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to El campo Value no puede superar los 4000 caracteres.
        /// </summary>
        internal static string ValueLength {
            get {
                return ResourceManager.GetString("ValueLength", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to El campo Value es requerido.
        /// </summary>
        internal static string ValueRequired {
            get {
                return ResourceManager.GetString("ValueRequired", resourceCulture);
            }
        }
    }
}