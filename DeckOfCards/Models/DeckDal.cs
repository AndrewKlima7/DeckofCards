using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace DeckOfCards.Models
{
    public class DeckDal
    {
        //Call Deck
        public string CallDeck()
        {
            string url = @$"https://deckofcardsapi.com/api/deck/new/";
            HttpWebRequest request = WebRequest.CreateHttp(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader rd = new StreamReader(response.GetResponseStream());

            string JSON = rd.ReadToEnd();
            rd.Close();

            return JSON;
        }

        public Deck GetModel()
        {
            string deckJson = CallDeck();
            Deck d = JsonConvert.DeserializeObject<Deck>(deckJson);
            return d;
        }

        //shuffles deck
        public string CallShuffle(string id)
        {
            string url = @$"https://deckofcardsapi.com/api/deck/{id}/shuffle/";
            HttpWebRequest request = WebRequest.CreateHttp(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader rd = new StreamReader(response.GetResponseStream());

            string JSON = rd.ReadToEnd();
            rd.Close();

            return JSON;
        }

        public Deck GetShuffle(string id)
        {
            string deckJson = CallShuffle(id);
            Deck d = JsonConvert.DeserializeObject<Deck>(deckJson);
            return d;
        }

        //draws card
        public string CallSet(string id, int amount)
        {
            string url = @$"https://deckofcardsapi.com/api/deck/{id}/draw/?count={amount}";
            HttpWebRequest request = WebRequest.CreateHttp(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader rd = new StreamReader(response.GetResponseStream());

            string JSON = rd.ReadToEnd();
            rd.Close();

            return JSON;
        }

        public Set GetSet(string id, int amount)
        {
            string deckJson = CallSet(id, amount);
            Set d = JsonConvert.DeserializeObject<Set>(deckJson);
            return d;
        }

        
    }
}
