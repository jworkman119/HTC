﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.269
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace frmPinnacle {
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
    internal class resPinnacle {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal resPinnacle() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("frmPinnacle.resPinnacle", typeof(resPinnacle).Assembly);
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
        ///   Looks up a localized string similar to Pinacle@htcorp.net.
        /// </summary>
        internal static string EmailFrom {
            get {
                return ResourceManager.GetString("EmailFrom", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to KristenL@htcorp.net.
        /// </summary>
        internal static string EmailTo {
            get {
                return ResourceManager.GetString("EmailTo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to C:\Program Files\HTC\fop.
        /// </summary>
        internal static string fopDirectory {
            get {
                return ResourceManager.GetString("fopDirectory", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &quot;\\iomega-nas\Public1\IT Department\Pinnacle\Database\Pinnacle.sqlite&quot;.
        /// </summary>
        internal static string liveDB {
            get {
                return ResourceManager.GetString("liveDB", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &quot;C:\Users\jeremyp.HTC\Documents\Development\Pinnacle\Database\Pinnacle.sqlite&quot;.
        /// </summary>
        internal static string testDB {
            get {
                return ResourceManager.GetString("testDB", resourceCulture);
            }
        }
    }
}