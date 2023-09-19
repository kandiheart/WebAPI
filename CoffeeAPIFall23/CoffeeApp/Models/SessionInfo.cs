using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeApp.Models
{
    internal class SessionInfo
    {
        public static SessionInfo _instance;

        public static SessionInfo Instance
        {
            get
            {
                if(_instance == null)
                    _instance = new SessionInfo();
                return _instance;
            }
        }

        public SessionInfo()
        {

        }

        private IEnumerable<Coffee> _coffees;

        public List<Coffee> Coffees
        {
            get
            {
                if (_coffees == null)
                    return new List<Coffee>();
                return _coffees.ToList();
            }
            set { _coffees.ToList(); }
        }

        private bool _loggedIn;
        public bool LoggedIn { get { return _loggedIn; } set { _loggedIn = value; } }
    }
}
