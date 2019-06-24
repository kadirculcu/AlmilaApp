using AlmilaApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AlmilaApp.Entities.Concrete
{
   public class Note:IEntity
    {

        public int Id { get; set; }
        public int Vize { get; set; }
        public int  final { get; set; }
        [ForeignKey("Lesson")]
        public int LessonId { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }

        public virtual Lesson Lesson { get; set; }

        public virtual Student Student { get; set; }

    }
}
