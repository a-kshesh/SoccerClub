using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aksheshkumar_C_C229.Models
{
    public class EFClubRepository : IClubRepository
    {
        ApplicationDbContext context;

        public EFClubRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public Club Save(Club club)
        {
            if(club.ClubId == 0)
            {
                context.Clubs.Add(club);
            }
            else
            {
                Club clubEntry = context.Clubs.FirstOrDefault(c => c.ClubId == club.ClubId);
                if(clubEntry != null)
                {
                    clubEntry.About = club.About;
                    clubEntry.Country = club.Country;
                    clubEntry.CreatedOn = club.CreatedOn;
                    clubEntry.NumOfFans = club.NumOfFans;
                    clubEntry.NumOfTrofies = club.NumOfTrofies;
                    clubEntry.Revenue = club.Revenue;
                    clubEntry.Name = club.Name;
                }
            }
            context.SaveChanges();
            return club;
        }

        public IQueryable<Club> GetAllClubs()
        {
            return context.Clubs.Include(c=>c.Players);
        }

        public Club GetClub(int clubId)
        {
            Club clubEntry = context.Clubs.Include(c => c.Players).FirstOrDefault(c => c.ClubId == clubId);
            return clubEntry;
        }

        public void Delete(int clubId)
        {
            Club clubEntry = context.Clubs.FirstOrDefault(c => c.ClubId == clubId);
            if (clubEntry != null)
            {
                context.Clubs.Remove(clubEntry);
                context.SaveChanges();
            }
        }
    }
}
