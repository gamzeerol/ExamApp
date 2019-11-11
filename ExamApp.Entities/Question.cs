using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ExamApp.Entities
{
    public class Question
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuestionId { get; set; }
        public string QuestionContent{ get; set; }
        //ForeignKey
        public int ExamId { get; set; }
        public virtual Exam Exam { get; set; }

        public virtual List<Option> Options { get; set; }
    }
}
