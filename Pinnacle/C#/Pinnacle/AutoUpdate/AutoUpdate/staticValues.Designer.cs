﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.296
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AutoUpdate {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class staticValues {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal staticValues() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("AutoUpdate.staticValues", typeof(staticValues).Assembly);
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
        ///   Looks up a localized string similar to c:\Program Files\HTC\Pinnacle.
        /// </summary>
        internal static string LocalPath {
            get {
                return ResourceManager.GetString("LocalPath", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to frmPinnacle.exe.
        /// </summary>
        internal static string LocalProcess {
            get {
                return ResourceManager.GetString("LocalProcess", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &quot;\\iomega-nas\Public1\IT Department\Pinnacle\Deploy\PinnacleSetup.msi&quot;.
        /// </summary>
        internal static string NetworkPath {
            get {
                return ResourceManager.GetString("NetworkPath", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to PinnacleSetup.msi.
        /// </summary>
        internal static string NetworkProcess {
            get {
                return ResourceManager.GetString("NetworkProcess", resourceCulture);
            }
        }
    }
}