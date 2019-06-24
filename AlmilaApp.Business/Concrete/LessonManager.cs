using AlmilaApp.Business.Abstract;
using AlmilaApp.DataAccess.Abstract;
using AlmilaApp.Entities.Concrete;
using AlmilaApp.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace AlmilaApp.Business.Concrete
{
    public class LessonManager : ILessonService
    {
        private ILessonDal _lessonDal;
        public LessonManager(ILessonDal lessonDal)
        {
            _lessonDal = lessonDal;
        }

        public void Add(LessonDto lessonDto)
        {
            var lesson = new Lesson()
            {
                Name = lessonDto.Name,
            };
            _lessonDal.Add(lesson);
            _lessonDal.Save();
        }

        public List<LessonDto> GetList(Expression<Func<Lesson, bool>> condition= null)
        {
            var lessonList = new List<LessonDto>();
            var lessons = _lessonDal.GetList(condition);

            foreach (var item in lessons)
            {
                var lesson = new LessonDto()
                {
                    Id =item.Id,
                    Name = item.Name,
                };

                lessonList.Add(lesson);
            }
            return lessonList;
        }
    }
}
