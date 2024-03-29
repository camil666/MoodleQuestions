//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuestionsDAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Question
    {
        public Question()
        {
            this.QuestionAnswers = new HashSet<QuestionAnswer>();
        }
    
        public int Id { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public string Content { get; set; }
        public Nullable<int> Rating { get; set; }
        public string Name { get; set; }
        public System.Guid AuthorId { get; set; }
        public System.DateTime CreationDate { get; set; }
        public bool IsDeleted { get; set; }
        public Nullable<System.DateTime> ModificationDate { get; set; }
        public bool IsVisible { get; set; }
    
        public virtual ICollection<QuestionAnswer> QuestionAnswers { get; set; }
        public virtual QuestionCategory QuestionCategory { get; set; }
        public virtual Users Author { get; set; }
    }
}
