using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;

namespace HallOfFame.Models
{
    public class Skill
    {
        private string _name;
        private byte _level;
        private long _personID;

        public string Name 
        {
            get
            {
                return _name;
            }
            set
            {
                Validator.AssertString(50,value, "Name");
                _name = value;
            }
        }

        public long PersonId { get; set; }

        public byte Level
        {
            get
            {
                return _level;
            }
            set
            {
               Validator.AssertByte(value,1,10,"Level");
            }
        }

    }
}
