using ExamApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamApp.WebUICore.ViewModels
{
    public class QuestionModel
    {
        public string QuestionContent { get; set; }
        public char Answer { get; set; }
        public List<Option> Options { get; set; }
    }
}
