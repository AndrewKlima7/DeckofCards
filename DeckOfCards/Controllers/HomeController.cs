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
        DeckDal dd = new DeckDal();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(); //Ask the user if they want to make a new deck
        }

        public IActionResult NewDeck()
        {
             //creates a new deck
            Deck d = dd.GetModel();
            return View(d); // this view will just pass on that id
        }

        public IActionResult Shuffle(string id)
        {
            //This will shuffle the deck
            Deck d = dd.GetShuffle(id);
            return View(d); //this view will once again pass on that id
            //i could have put this inside of Draw card but i wanted more practice
            //with this
        }

        public IActionResult DrawCard(string id, int amount) //draw a card from the deck
        {
            Set d = dd.GetSet(id, amount);
            return View(d); //then display the cards in the list of cards
            // and then ask if they want to draw again or get a new deck
            //the again will link back to the draw card action
            //the new deck will link back to the new deck action
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
