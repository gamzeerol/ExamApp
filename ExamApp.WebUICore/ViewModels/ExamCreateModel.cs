using ExamApp.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamApp.WebUICore.ViewModels
{
    public class ExamCreateModel
    {
        public string Title { get; set; }
 
        public string Content { get; set; }
       
        public List<QuestionModel> Questions { get; set; }

    }
}
