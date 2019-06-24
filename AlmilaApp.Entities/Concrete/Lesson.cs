using AlmilaApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlmilaApp.Entities.Concrete
{
   public class Lesson:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
    }
}
