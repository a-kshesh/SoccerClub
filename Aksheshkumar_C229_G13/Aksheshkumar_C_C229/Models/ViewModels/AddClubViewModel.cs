using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aksheshkumar_C_C229.Models.ViewModels
{
    public class AddClubViewModel
    {
        public Club Club { get; set; }
        public IEnumerable<Player> Players { get; set; }
        public AddClubViewModel() { }

        public AddClubViewModel(IEnumerable<Player> players)
        {
            Players = players;
        }


    }
}
