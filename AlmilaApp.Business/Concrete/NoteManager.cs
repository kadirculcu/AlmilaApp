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
    public class NoteManager : INoteService
    {
        private INoteDal _noteDal;
        public NoteManager(INoteDal noteDal)
        {
            _noteDal = noteDal;
        }

        public void Add(NoteDto noteDto)
        {
            var note = new Note()
            {
                Vize =noteDto.Vize,
                final=noteDto.Final,
                LessonId=noteDto.LessonId,
                StudentId=noteDto.StudentId,
            };
            _noteDal.Add(note);
            _noteDal.Save();
        }

        public void Delete(int id)
        {
            var entity = _noteDal.Get(p => p.Id == id);
            _noteDal.Delete(entity);
            _noteDal.Save();
        }

        public NoteDto Get(Expression<Func<Note, bool>> condition = null)
        {
          var note = _noteDal.Get(condition);
            var result = new NoteDto()
            {
               Id=note.Id,
               Vize = note.Vize,
               Final = note.final,
               LessonId=note.LessonId,
               StudentId=note.StudentId,
               
            };
            return result;
        }

        public List<NoteDto> GetAll(Expression<Func<Note, bool>> condition=null)
        {
            var noteList = new List<NoteDto>();
            var notes = _noteDal.GetList(condition);

            foreach (var item in notes)
            {
                var note = new NoteDto()
                {
                    Id = item.Id,
                    Vize = item.Vize,
                    Final = item.final,
                    LessonId=item.LessonId,
                    StudentId=item.StudentId,
                };

                noteList.Add(note);
            }
            return noteList;
        }

        public List<NoteDto> GetNotesAllInformations()
        {
            var result = new List<NoteDto>();
            
            var notes = _noteDal.GetNotesWithAllInformations();
            
            foreach (var item in notes)
            {
                var note = new NoteDto()
                {
                    Final = item.final,
                    Id = item.Id,
                    Lesson = new LessonDto()
                    {
                        Id = item.Lesson.Id,
                        Name = item.Lesson.Name
                    },
                    LessonId = item.LessonId,
                    Student = new StudentDto()
                    {
                        Id = item.Student.Id,
                        Name = item.Student.Name,
                        Surname = item.Student.Surname
                    },
                    StudentId = item.StudentId,
                    Vize   = item.Vize,
                    ort=(item.Vize*0.3)+(item.final*0.7)
                };

                result.Add(note);
            };


            return result;
        }

        public void Update(NoteDto noteDto)
        {
            var note = new Note()
            { 
                Id=noteDto.Id,
                Vize =noteDto.Vize,
                final=noteDto.Final,
                LessonId=noteDto.LessonId,
                StudentId=noteDto.StudentId,
            };
            _noteDal.Update(note);
            _noteDal.Save();
        }
    }
}
