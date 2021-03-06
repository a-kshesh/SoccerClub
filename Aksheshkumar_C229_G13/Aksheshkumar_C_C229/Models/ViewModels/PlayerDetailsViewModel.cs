using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aksheshkumar_C_C229.Models.ViewModels
{
    public class PlayerDetailsViewModel
    {
        public Player Player { get; set; }
        public IEnumerable<Club> Clubs { get; set; }
        public PlayerDetailsViewModel() { }

        public PlayerDetailsViewModel(Player p, IEnumerable<Club> clubs, bool isEditable = false)
        {
            Player = p;
            Clubs = clubs;
        }

    }
}
