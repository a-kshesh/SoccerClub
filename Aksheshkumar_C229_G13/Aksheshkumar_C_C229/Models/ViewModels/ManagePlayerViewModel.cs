using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aksheshkumar_C_C229.Models.ViewModels
{
    public class ManagePlayerViewModel
    {
        public Club Club { get; set; }
        public IEnumerable<Player> UnRegisteredPlayer { get; set; }
        public IEnumerable<Player> Players { get; set; }

        public ManagePlayerViewModel() { }

        public ManagePlayerViewModel(Club c,IEnumerable<Player> unregisteredplayer, IEnumerable<Player> players)
        {
            Club = c;
            UnRegisteredPlayer = unregisteredplayer;
            Players = players;
        }

    }
}
