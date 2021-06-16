using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Aksheshkumar_C_C229.Models
{
    public class Player
    {
        public int PlayerId { get; set; }
        [Required(ErrorMessage = "Please enter the player name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter the origin country of player")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Please enter date of birth")]
        public DateTime Dob { get; set; }

        public int? ClubId { get; set; }

        public Club Club { get; set; }

        [Required(ErrorMessage ="Please number of goals scored")]
        public int Goals { get; set; }

        [Required(ErrorMessage ="Please enter the salary of player")]
        public double Salary { get; set; }

        public override string ToString()
        {
            return $"PlayerId:{PlayerId}\nName:{Name}\nCountry:{Country}\nClub:{Club.Name}\nClubId:{ClubId}";
        }
    }
}
