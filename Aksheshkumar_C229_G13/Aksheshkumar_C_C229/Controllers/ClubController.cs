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
    public class ClubController : Controller
    {
        private readonly IClubRepository clubRepo;
        private readonly IPlayerRepository playerRepo;

        public ClubController(IClubRepository repo, IPlayerRepository playerrepo)
        {
            clubRepo = repo;
            playerRepo = playerrepo;
        }

        public ViewResult ClubPage()
        {
            return View("ClubPage", clubRepo.GetAllClubs());
        }

        [Authorize]
        public ViewResult ClubEdit(int clubId)
        {
            return View(new ManageClubViewModel(
                clubRepo.GetClub(clubId),
                playerRepo.GetAllPlayers()
            ));
        }

        public ViewResult ClubDetails(int clubId)
        {
            return View(new ManageClubViewModel(
                clubRepo.GetClub(clubId),
                playerRepo.GetAllPlayers()
            ));
        }

        [HttpPost]
        [Authorize]
        public IActionResult ClubEdit(ManageClubViewModel editClub)
        {
            Club updatedClub = clubRepo.Save(editClub.Club);
            return RedirectToAction("ClubDetails", new { clubId = updatedClub.ClubId });
        }

        [Authorize]
        public ViewResult NewClub()
        {
            return View(new AddClubViewModel(playerRepo.GetAllPlayers()));
        }

        [HttpPost]
        [Authorize]
        public IActionResult NewClub(AddClubViewModel newClubModel)
        {

            Club newClub = clubRepo.Save(newClubModel.Club);
            return RedirectToAction("ClubDetails", new { clubId = newClub.ClubId });
        }

        [Authorize]
        public IActionResult ClubDelete(int clubId)
        {
            Club c = clubRepo.GetClub(clubId);
            
            foreach(Player p in c.Players.ToList())
            {
                Player player = playerRepo.GetPlayer(p.PlayerId);
                player.ClubId = null;
                playerRepo.Save(player);
            }
            clubRepo.Delete(clubId);
            return RedirectToAction("ClubPage");
        }

    }
}