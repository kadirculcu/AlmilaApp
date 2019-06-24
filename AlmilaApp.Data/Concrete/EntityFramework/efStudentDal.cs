
using AlmilaApp.Core.DataAccess.EntityFramework;
using AlmilaApp.DataAccess.Abstract;
using AlmilaApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlmilaApp.DataAccess.Concrete.EntityFramework
{
    public class efStudentDal: efEntityRepositoryBase<Student>, IStudentDal
    {
        public efStudentDal(DbContext dbContext) : base(dbContext)
        {

        }

    }
}
