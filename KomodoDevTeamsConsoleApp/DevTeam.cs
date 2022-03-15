using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoDevTeamsConsoleApp
{
    public class DevTeam
    {
        private string _name;
        protected List<Developer> _DevList = new List<Developer>();

        public DevTeam() { }
        public DevTeam(string name)
        {
            SetName(name);
        }


        public void SetName(string name)
        {
            _name = name;
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

        protected Guid DevGuid;




    }
}
