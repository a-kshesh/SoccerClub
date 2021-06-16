using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Aksheshkumar_C_C229.Models;
using Aksheshkumar_C_C229.Models.ViewModels;

namespace Aksheshkumar_C_C229.Controllers
{
    public class PlayerController : Controller
    {
        private readonly IPlayerRepository playerRepo;
        private readonly IClubRepository clubRepo;

        public PlayerController(IPlayerRepository repo, IClubRepository clubrepo)
        {
            playerRepo = repo;
            clubRepo = clubrepo;
        }
        public ViewResult Players()
        {
            var players = playerRepo.GetAllPlayers();
            return View(playerRepo.GetAllPlayers());
        }

        [Authorize]
        public ViewResult ManagePlayer(int clubId)
        {
            return View(new ManagePlayerViewModel(
                clubRepo.GetClub(clubId),
                playerRepo.GetAllPlayers().Where(p=>p.ClubId == null),
                playerRepo.GetAllPlayers().Where(p => p.ClubId == clubId)
            ));
        }

        public ViewResult PlayerDetails(int playerId)
        {
            return View(new PlayerDetailsViewModel(
                playerRepo.GetPlayer(playerId),
                clubRepo.GetAllClubs()
            ));
        }

        [Authorize]
        public ViewResult PlayerEdit(int playerId)
        {
            return View(new PlayerDetailsViewModel(
                playerRepo.GetPlayer(playerId),
                clubRepo.GetAllClubs()
            ));
        }

        [Authorize]
        public ViewResult NewPlayer()
        {
            return View(new AddPlayerViewModel(clubRepo.GetAllClubs()));
        }

        [Authorize]
        public IActionResult PlayerDelete(int playerId)
        {
            playerRepo.Delete(playerId);
            return RedirectToAction("Players");
        }

        [HttpPost]
        [Authorize]
        public IActionResult DeRegisterClub(int clubId,int playerId)
        {
            Player p = playerRepo.GetPlayer(playerId);
            p.ClubId = null;
            playerRepo.Save(p);    
            return RedirectToAction("ManagePlayer", new {clubId = clubId });
        }

        [Authorize]
        public IActionResult RegisterClub(int clubId, int playerId)
        {
            Player p = playerRepo.GetPlayer(playerId);
            Club c = clubRepo.GetClub(clubId);
            p.ClubId = clubId;
            p.Club = c;
            playerRepo.Save(p);
            return RedirectToAction("ManagePlayer", new { clubId = clubId });
        }

        [HttpPost]
        [Authorize]
        public IActionResult PlayerEdit(PlayerDetailsViewModel editPlayer)  
        {
                if (editPlayer.Player.ClubId == null)
                {
                    editPlayer.Player.Club = null;
                }
                else
                {
                    editPlayer.Player.Club = clubRepo.GetClub(editPlayer.Player.ClubId ?? default(int));
                }
                Player updatedPlayer = playerRepo.Save(editPlayer.Player);
                    return RedirectToAction("PlayerDetails", new { playerId = updatedPlayer.PlayerId });
        }

        [HttpPost]
        [Authorize]
        public IActionResult NewPlayer(AddPlayerViewModel newPlayerModel)
        {
            if(newPlayerModel.Player.ClubId == null)
            {
                newPlayerModel.Player.Club = null;
            }
            else
            {
                newPlayerModel.Player.Club = clubRepo.GetClub(newPlayerModel.Player.ClubId ?? default(int));
            }
            Player newPlayer = playerRepo.Save(newPlayerModel.Player);
            return RedirectToAction("PlayerDetails", new { playerId = newPlayer.PlayerId });
            //if (ModelState.IsValid)
            //{
            //    Player newPlayer = playerRepo.Add(p);
            //    return RedirectToAction("PlayerDetails", new { playerId = newPlayer.PlayerId });
            //}
            //else
            //{
            //    return View();
            //}
        }
    }
}