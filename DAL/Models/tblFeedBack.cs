//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblFeedBack
    {
        public int FeedBack_ID { get; set; }
        public Nullable<int> User_ID { get; set; }
        public Nullable<int> Product_ID { get; set; }
        public System.DateTime Feedback_Time { get; set; }
        public int Feedback_Score { get; set; }
        public string Feedback_Content { get; set; }
    
        public virtual tblProduct tblProduct { get; set; }
        public virtual tblUser tblUser { get; set; }
    }
}
