using System;
using System.Collections.Generic;
using System.Text;

namespace ExamApp.Entities
{
   public class Option
    {
        public int OptionId { get; set; }
        public string selection { get; set; }
        public string IsCorrect { get; set; }
        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }


    }
}
