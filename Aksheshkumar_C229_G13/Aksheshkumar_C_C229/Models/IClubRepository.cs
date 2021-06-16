using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aksheshkumar_C_C229.Models
{
    public interface IClubRepository
    {
        Club GetClub(int clubId);
        IQueryable<Club> GetAllClubs();
        Club Save(Club c);

        void Delete(int clubId);

    }
}
