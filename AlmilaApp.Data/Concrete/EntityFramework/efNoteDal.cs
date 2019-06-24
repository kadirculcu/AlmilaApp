using AlmilaApp.Core.DataAccess.EntityFramework;
using AlmilaApp.DataAccess.Abstract;
using AlmilaApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace AlmilaApp.DataAccess.Concrete.EntityFramework
{
   public class efNoteDal : efEntityRepositoryBase<Note>, INoteDal
    {
        public efNoteDal(DbContext dbContext) : base(dbContext)
        {

        }

        public List<Note> GetNotesWithAllInformations()
        {
            var result = new List<Note>();
            using (var context = new AlmilaContext())
            {
                result = context.Notes
                    .Include(x => x.Student)
                    .Include(x=>x.Lesson)
                    //.Where(expression)
                    .Select(item =>
                        new Note()
                        {
                            Id = item.Id,
                            Lesson=item.Lesson,
                            LessonId=item.LessonId,
                            Student=item.Student,
                            final=item.final,
                            StudentId=item.StudentId,
                            Vize=item.Vize
                            
                        }).ToList();
            }

            return result;
        }

    }
}
