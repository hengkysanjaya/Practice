//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AmonicAirline
{
    using System;
    using System.Collections.Generic;
    
    public partial class CrashReport
    {
        public int CrashReportID { get; set; }
        public int SessionLogID { get; set; }
        public Nullable<int> CrashTypeID { get; set; }
        public string CrashDescription { get; set; }
    
        public virtual CrashType CrashType { get; set; }
        public virtual SessionLog SessionLog { get; set; }
    }
}