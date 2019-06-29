using AlmilaApp.Entities.Concrete;
using AlmilaApp.Entities.Dto;
using AlmilaApp.Entities.ViewModel;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlmilaApp.Business.ValidationRules.FluentValidation
{
    public class NoteValidatior:AbstractValidator<NoteViewModel>
    {
        public NoteValidatior()
        {
            RuleFor(p => p.Note.Vize).NotEmpty().WithMessage("Vize notunu giriniz");
            RuleFor(p => p.Note.Final).NotEmpty().WithMessage("Final adını giriniz");
            RuleFor(p => p.Note.LessonId).NotEmpty().WithMessage("Dersin ID giriniz");
            RuleFor(p => p.Note.StudentId).NotEmpty().WithMessage("Öğrenci ID giriniz");

        }
    }
}
