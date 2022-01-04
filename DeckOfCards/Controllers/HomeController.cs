using DeckOfCards.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DeckOfCards.Controllers
{
    public class HomeController : Controller
    {
        DeckDAL dc = new DeckDAL();
        public IActionResult Index()
        {
            return View();
        }
        //public IActionResult PlayGame()
        //{
        //    DeckDraw hand = dc.PopulateNewDeck();
        //    return RedirectToAction();
        //}
        public IActionResult Play(DeckDraw deck)
        {
            DeckDraw hand = dc.DrawCards(deck.deck_id, 5);
            return View(hand);
        }
        public IActionResult GetNewCards(DeckDraw deck)
        {
            DeckDraw hand = dc.DrawCards(deck.deck_id, 5);
            return RedirectToAction("Play", "Home", hand);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
