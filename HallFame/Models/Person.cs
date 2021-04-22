
using System.Collections.Generic;

namespace HallOfFame.Models
{
    /// <summary>
    /// Класс описывает сущность "Сотрудник"
    /// </summary>
    public class Person
    {
        private long _id;
        private string _name;
        private string _displayName;
        private Skill _skills;

        public long Id { get; set; }
       

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
               Validator.AssertString(75,value,"Person Name");
               _name = value;
            }
        }


        public string DisplayName
        {
            get
            {
                return _displayName;
            }
            set
            {
               Validator.AssertString(50,value,"Display Name");
               _displayName = value;
            }
        }


        public virtual ICollection<Skill> Skills { get; set; }
    }
}
