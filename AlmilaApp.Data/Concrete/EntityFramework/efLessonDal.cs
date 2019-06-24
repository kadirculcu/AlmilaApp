using AlmilaApp.Core.DataAccess.EntityFramework;
using AlmilaApp.DataAccess.Abstract;
using AlmilaApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlmilaApp.DataAccess.Concrete.EntityFramework
{
    public class efLessonDal : efEntityRepositoryBase<Lesson>, ILessonDal
    {
        public efLessonDal(DbContext dbContext) : base(dbContext)
        {

        }

    }
}
