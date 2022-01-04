using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace DeckOfCards.Models
{
    public class DeckDAL
    {
        public DeckDraw PopulateNewDeck(string card)
        {
            string url = $"https://deckofcardsapi.com/api/deck/new/shuffle/?deck_count=1" + card;

            HttpWebRequest request = WebRequest.CreateHttp(url);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader rd = new StreamReader(response.GetResponseStream());

            string JSON = rd.ReadToEnd();
            rd.Close();
            DeckDraw p = JsonConvert.DeserializeObject<DeckDraw>(JSON);
            return p;
        }
        public DeckDraw DrawCards(string deckID, int count)
        {
            string url = $"http://deckofcardsapi.com/api/deck/{deckID}/draw/?count={count}";
            HttpWebRequest request = WebRequest.CreateHttp(url);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader rd = new StreamReader(response.GetResponseStream());

            string result = rd.ReadToEnd();
            rd.Close();

            DeckDraw d = JsonConvert.DeserializeObject<DeckDraw>(result);
            return d;
        }
    }
}
