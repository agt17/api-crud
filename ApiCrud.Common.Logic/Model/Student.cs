using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCrud.Common.Logic.Model
{
    public class Student : IVuelingObject
    {
        #region Attributes
        public Guid Guid { get; set; }
        public int Id { get; set; }
        public string CardId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public DateTime DateBorn { get; set; }
        public DateTime DateRegistry { get; set; }
        #endregion

        #region Builders
        public Student(Guid guid, int id, string cardId, string name, string surname,
                        int age, DateTime dateborn, DateTime registry)
        {
            this.Guid = guid;
            this.Id = id;
            this.Name = name;
            this.Surname = surname;
            this.Age = age;
            this.DateBorn = dateborn;
            this.DateRegistry = registry;
        }

        public Student() { }
        #endregion
    }
}
