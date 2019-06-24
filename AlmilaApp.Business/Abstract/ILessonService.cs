using AlmilaApp.Entities.Concrete;
using AlmilaApp.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace AlmilaApp.Business.Abstract
{
   public interface ILessonService
    {
        void Add(LessonDto lesson);
        List<LessonDto> GetList(Expression<Func<Lesson, bool>> condition=null);
    }
}
