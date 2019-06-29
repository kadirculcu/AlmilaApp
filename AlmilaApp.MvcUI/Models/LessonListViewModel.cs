using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlmilaApp.Entities.Dto;

namespace AlmilaApp.MvcUI.Models
{
    public class LessonListViewModel
    {
        public List<LessonDto> Lessons { get; internal set; }
    }
}
