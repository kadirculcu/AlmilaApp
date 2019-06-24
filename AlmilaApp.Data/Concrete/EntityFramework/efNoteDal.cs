using AlmilaApp.Core.DataAccess.EntityFramework;
using AlmilaApp.DataAccess.Abstract;
using AlmilaApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlmilaApp.DataAccess.Concrete.EntityFramework
{
   public class efNoteDal : efEntityRepositoryBase<Note>, INoteDal
    {
        public efNoteDal(DbContext dbContext) : base(dbContext)
        {

        }

    }
}
