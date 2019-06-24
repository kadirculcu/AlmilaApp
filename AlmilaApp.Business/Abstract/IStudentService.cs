using AlmilaApp.Entities.Concrete;
using AlmilaApp.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace AlmilaApp.Business.Abstract
{
    public interface IStudentService
    {
        List<StudentDto> GetAll(Expression<Func<Student, bool>> condition=null);
        void Add(StudentDto student);
        void Update(StudentDto student);
        void Delete(int id);
        StudentDto Get(Expression<Func<Student, bool>> condition = null);
    }
}
