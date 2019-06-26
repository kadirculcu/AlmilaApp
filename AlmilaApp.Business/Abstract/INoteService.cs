using AlmilaApp.Entities.Concrete;
using AlmilaApp.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace AlmilaApp.Business.Abstract
{
    public interface INoteService
    {
        List<NoteDto> GetAll(Expression<Func<Note, bool>> condition=null);
        void Add(NoteDto note);
        void Delete(int id);
        void Update(NoteDto note);
        List<NoteDto> GetNotesAllInformations();
        NoteDto Get(Expression<Func<Note, bool>> condition = null);

    }
}
