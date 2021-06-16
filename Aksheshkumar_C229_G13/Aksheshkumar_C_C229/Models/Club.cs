using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Aksheshkumar_C_C229.Models
{
    public class Club
    {
        public int ClubId { get; set; }

        [Required(ErrorMessage ="Please enter the club name")]
        public string Name { get; set; }

        public string About { get; set; }

        [Required(ErrorMessage ="Please enter the origin country of club")]
        public string Country { get; set; }

        [Required(ErrorMessage ="Please enter created date of club")]
        public DateTime CreatedOn { get; set; }

        [Required(ErrorMessage = "Please enter number of trophies won")]
        public int NumOfTrofies { get; set; }
        [Required(ErrorMessage ="Please enter club revenue")]
        public double Revenue { get; set; }
       
        [Required(ErrorMessage ="Please enter number of fan following")]
        public long NumOfFans { get; set; }

        public ICollection<Player> Players { get; set;}
    }
}
