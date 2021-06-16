using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aksheshkumar_C_C229.Models
{
    public class EFPlayerRepository : IPlayerRepository
    {
        ApplicationDbContext context;
        public EFPlayerRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public void Delete(int playerId)
        {
            Player playerEntry = context.Players.Include(p => p.Club).FirstOrDefault(p => p.PlayerId == playerId);
            if (playerEntry != null)
            {
                context.Players.Remove(playerEntry);
                context.SaveChanges();
            }
        }

        public IQueryable<Player> GetAllPlayers()
        {
            return context.Players.Include(p => p.Club);
        }

        public Player GetPlayer(int playerId)
        {
            Player playerEntry = context.Players.Include(p => p.Club).FirstOrDefault(p => p.PlayerId == playerId);
            return playerEntry;
        }

        public Player Save(Player player)
        {
            if(player.PlayerId == 0)
            {
                context.Players.Add(player);
            }
            else
            {
                Player playerEntry = context.Players.Include(p => p.Club).FirstOrDefault(p => p.PlayerId == player.PlayerId);
                if(playerEntry != null)
                {
                    playerEntry.Name = player.Name;
                    playerEntry.Goals = player.Goals;
                    playerEntry.Dob = player.Dob;
                    playerEntry.Country = player.Country;
                    playerEntry.Salary = player.Salary;
                    playerEntry.ClubId = player.ClubId;
                    playerEntry.Club = player.Club;
                }
            }
            context.SaveChanges();
            return player;
        }
    }
}
