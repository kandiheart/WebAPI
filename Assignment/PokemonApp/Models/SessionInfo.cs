using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonApp.Models
{
    internal class SessionInfo
    {
        public static SessionInfo _instance;

        public static SessionInfo Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SessionInfo();
                return _instance;
            }
        }

        public SessionInfo()
        {

        }

        private IEnumerable<Pokemon> _pokemons;

        public List<Pokemon> Pokemons
        {
            get
            {
                if (_pokemons == null)
                    return new List<Pokemon>();
                return _pokemons.ToList();
            }
            set { _pokemons.ToList(); }
        }

        private bool _loggedIn;
        public bool LoggedIn { get { return _loggedIn; } set { _loggedIn = value; } }
    }
}
