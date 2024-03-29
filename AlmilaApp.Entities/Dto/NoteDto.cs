﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AlmilaApp.Entities.Dto
{
    public class NoteDto
    {
        public int Id { get; set; }
        public int Vize { get; set; }
        public int Final { get; set; }
        public int LessonId { get; set; }
        public int StudentId { get; set; }
        public double Ort { get; set; }

        public LessonDto Lesson { get; set; }
        public StudentDto Student { get; set; }
    }
}
