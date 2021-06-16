using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aksheshkumar_C_C229.Models.ViewModels
{
    public class AddPlayerViewModel
    {
        public Player Player { get; set; }
        public IEnumerable<Club> Clubs { get; set; }

        public AddPlayerViewModel(){ }

        public AddPlayerViewModel(IEnumerable<Club> clubs)
        {
            Clubs = clubs;
        }
    }
}
