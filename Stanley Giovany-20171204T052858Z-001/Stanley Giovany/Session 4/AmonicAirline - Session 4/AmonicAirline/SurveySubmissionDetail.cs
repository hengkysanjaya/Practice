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
    
    public partial class SurveySubmissionDetail
    {
        public int SurveySubmissionDetailId { get; set; }
        public int SurveySubmissionId { get; set; }
        public int QuestionId { get; set; }
        public int ChoiceId { get; set; }
    
        public virtual Choice Choice { get; set; }
        public virtual Question Question { get; set; }
        public virtual SurveySubmission SurveySubmission { get; set; }
    }
}
