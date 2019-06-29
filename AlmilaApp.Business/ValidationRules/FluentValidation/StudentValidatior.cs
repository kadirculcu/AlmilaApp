using AlmilaApp.Entities.Concrete;
using AlmilaApp.Entities.Dto;
using AlmilaApp.Entities.ViewModel;
using FluentValidation;
using FluentValidation.AspNetCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlmilaApp.Business.ValidationRules.FluentValidation
{
    public class StudentValidatior:AbstractValidator<StudentViewModel>
    {
        public StudentValidatior()
        {
            RuleFor(p => p.Student.Name).NotEmpty().WithMessage("Öğrenci adını giriniz");
            RuleFor(p => p.Student.Surname).NotEmpty().WithMessage("Öğrenci soyadını giriniz");

        }
    }
}
