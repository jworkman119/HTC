﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.296
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace htcHealthCenter_TPDates {
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
    internal class StaticValues {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal StaticValues() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("htcHealthCenter_TPDates.StaticValues", typeof(StaticValues).Assembly);
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
        ///   Looks up a localized string similar to C:\Program Files\HTC\fop.
        /// </summary>
        internal static string FopDirectory {
            get {
                return ResourceManager.GetString("FopDirectory", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to C:\Users\jeremyp.HTC\Documents\Development\HealthCenter\Database\dbHealthCenter_TP.sqlite.
        /// </summary>
        internal static string LocalDB {
            get {
                return ResourceManager.GetString("LocalDB", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to \\iomega-nas.htc.local\Public1\IT Department\MentalHealthCenter\TP_Dates\dbHealthCenter_TP.sqlite.
        /// </summary>
        internal static string RemoteDB {
            get {
                return ResourceManager.GetString("RemoteDB", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to c:\progra~1\HTC\htcTreatmentPlanDates\.
        /// </summary>
        internal static string xslDirectory_Live {
            get {
                return ResourceManager.GetString("xslDirectory_Live", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to C:\Users\jeremyp.HTC\Documents\Development\HealthCenter\Report\TPDates.xsl.
        /// </summary>
        internal static string xslDirectory_Test {
            get {
                return ResourceManager.GetString("xslDirectory_Test", resourceCulture);
            }
        }
    }
}