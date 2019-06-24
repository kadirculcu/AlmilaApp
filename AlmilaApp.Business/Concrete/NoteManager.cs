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
                final=noteDto.Vize,
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

        public List<NoteDto> GetAll(Expression<Func<Note, bool>> condition=null)
        {
            var notetList = new List<NoteDto>();
            var notes = _noteDal.GetList(condition);

            foreach (var item in notes)
            {
                var note = new NoteDto()
                {
                    Vize = item.Vize,
                    Final = item.final,
                    LessonId=item.LessonId,
                    StudentId=item.StudentId,
                };

                notetList.Add(note);
            }
            return notetList;
        }

        public void Update(NoteDto noteDto)
        {
            var note = new Note()
            {
                Vize =noteDto.Vize,
                final=noteDto.Vize,
                LessonId=noteDto.LessonId,
                StudentId=noteDto.StudentId,
            };
            _noteDal.Update(note);
            _noteDal.Save();
        }
    }
}
