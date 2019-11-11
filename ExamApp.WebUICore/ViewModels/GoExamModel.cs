using ExamApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamApp.WebUICore.ViewModels
{
    public class GoExamModel
    {
        public Exam Exam { get; set; }
        public List<Question> Questions { get; set; }
        public List<Option> Options { get; set; }
    }
}
