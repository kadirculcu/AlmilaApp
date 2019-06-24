using AlmilaApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlmilaApp.Entities.Concrete
{
   public class Student:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}