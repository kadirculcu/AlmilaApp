using AlmilaApp.Core.DataAccess;
using AlmilaApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlmilaApp.DataAccess.Abstract
{
    public interface ILessonDal : IEntityRepository<Lesson>
    {
    }
}
