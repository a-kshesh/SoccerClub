using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aksheshkumar_C_C229.Models
{
    public interface IPlayerRepository
    {
        Player GetPlayer(int playerId);
        IQueryable<Player> GetAllPlayers();
        Player Save(Player p);

        void Delete(int playerId);
    }
}
