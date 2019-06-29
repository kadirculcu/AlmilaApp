using AlmilaApp.Business.Abstract;
using AlmilaApp.Business.ValidationRules.FluentValidation;
using AlmilaApp.Core.Aspect.ValidationAspect;
using AlmilaApp.DataAccess.Abstract;
using AlmilaApp.Entities.Concrete;
using AlmilaApp.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace AlmilaApp.Business.Concrete
{
    public class StudentManager : IStudentService
    {
        private IStudentDal _studentDal;
        public StudentManager(IStudentDal studentDal)
        {
            _studentDal = studentDal;
        }

       

        public void Add(StudentDto studentDto)
        {
          //  ValidationAspect.FluentValidate(new StudentValidatior(), studentDto);
            var student = new Student()
            {
                Name = studentDto.Name,
                Surname = studentDto.Surname,
               
            };
            _studentDal.Add(student);
            _studentDal.Save();
        }

        public void Delete(int id)
        {
            var entity = _studentDal.Get(p => p.Id == id);
            _studentDal.Delete(entity);
            _studentDal.Save();
        }

        public StudentDto Get(Expression<Func<Student, bool>> condition = null)
        {
            var student = _studentDal.Get(condition);
            var result = new StudentDto()
            {
               Id=student.Id,
               Name = student.Name,
               Surname = student.Surname,
               
            };
            return result;
        }

        public List<StudentDto> GetAll(Expression<Func<Student, bool>> condition=null)
        {
            var studentList = new List<StudentDto>();
            var students = _studentDal.GetList(condition);

            foreach (var item in students)
            {
                var student = new StudentDto()
                {   
                    Id=item.Id,
                    Name = item.Name,
                    Surname = item.Surname,
                    
                };

                studentList.Add(student);
            }
            return studentList;
        }

        public void Update(StudentDto studentDto)
        {
            var student = new Student()
            {
                Id =studentDto.Id,
                Name = studentDto.Name,
                Surname = studentDto.Surname,
            };
            _studentDal.Update(student);
            _studentDal.Save();
        }
    }
}
