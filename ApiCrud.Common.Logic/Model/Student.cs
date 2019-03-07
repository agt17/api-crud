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
                        int age, DateTime dateBorn, DateTime dateRegistry)
        {
            this.Guid = guid;
            this.Id = id;
            this.Name = name;
            this.Surname = surname;
            this.Age = age;
            this.DateBorn = dateBorn;
            this.DateRegistry = dateRegistry;
        }

        public Student() { }

        public Student(Guid guid, string cardId, string name, string surname, int age, DateTime dateBorn, DateTime dateRegistry)
        {
            this.Guid = guid;
            this.CardId = cardId;
            this.Name = name;
            this.Surname = surname;
            this.Age = age;
            this.DateBorn = dateBorn;
            this.DateRegistry = dateRegistry;
        }
        #endregion

        public override bool Equals(object obj)
        {
            var student = obj as Student;
            return student != null &&
                   Guid.Equals(student.Guid) &&
                   CardId == student.CardId &&
                   Name == student.Name &&
                   Surname == student.Surname &&
                   Age == student.Age &&
                   DateBorn.ToString("yyyyMMddhhmmss") 
                        == student.DateBorn.ToString("yyyyMMddhhmmss") &&
                   DateRegistry.ToString("yyyyMMddhhmmss") 
                        == student.DateRegistry.ToString("yyyyMMddhhmmss");
        }

        public override int GetHashCode()
        {
            var hashCode = 1360516050;
            hashCode = hashCode * -1521134295 + EqualityComparer<Guid>.Default.GetHashCode(Guid);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CardId);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Surname);
            hashCode = hashCode * -1521134295 + Age.GetHashCode();
            hashCode = hashCode * -1521134295 + DateBorn.GetHashCode();
            hashCode = hashCode * -1521134295 + DateRegistry.GetHashCode();
            return hashCode;
        }
    }
}
