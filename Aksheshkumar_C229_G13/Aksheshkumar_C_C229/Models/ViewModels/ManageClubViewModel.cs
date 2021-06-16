using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aksheshkumar_C_C229.Models.ViewModels
{
    public class ManageClubViewModel
    {
        public Club Club { get; set; }
        public IEnumerable<Player> Players { get; set; }


        public ManageClubViewModel() { }

        public ManageClubViewModel(Club c,IEnumerable<Player> players,bool isEditable = false)
        {
            Club = c;
            Players = players;
        }


    }
}
