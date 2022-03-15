using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoDevTeamsConsoleApp
{
    public class Developer
    {
        private string _firstName;
        private string _lastName;

        public Developer() { }
        public Developer(string firstName, string lastName)
        {
            SetFirstName(firstName);
            SetLastName(lastName);
        }


        public string Name
        {
            get
            {
                string fullName = $"{_firstName} {_lastName}"; // " "
                return (!string.IsNullOrWhiteSpace(fullName)) ? fullName : "Unnamed";
            }
        }

        public void SetFirstName(string name)
        {
            _firstName = name;
        }
        public void SetLastName(string name)
        {
            _lastName = name;
        }



        public Guid guid
        {
            get
            {
                return DevGuid;
            }
            set
            {
                Guid.NewGuid();
            }

        }
        public bool HasPluralSight { get; private set; }


        protected Guid DevGuid;

    }
}
