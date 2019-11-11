using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ExamApp.Entities
{

    public class Exam
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ExamId { get; set; }
        public string ExamTitle { get; set; } //Makale Başlığı
        public string ExamContent { get; set; } //Makale İçeriği

        public DateTime CreatedDate { get; set; }
        public virtual List<Question> Questions { get; set; }  // Sınava ait sorular
    }
}
