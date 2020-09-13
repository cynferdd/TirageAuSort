using System.Collections.Generic;
using System;

namespace Domain
{
    public class Rng
    {
        private readonly IList<string> candidats;
        private readonly IList<string> lots;
        private readonly Random randomCandidate;
        private readonly Random randomLot;

        public Rng(IList<string> candidats, IList<string> lots)
        {
            this.candidats = candidats;
            this.lots = lots;
            randomCandidate = new Random();
            randomLot = new Random();
        }

        public string PickRandomCandidate()
        {
            int value = randomCandidate.Next(candidats.Count);
            string candidat = candidats[value];
            candidats.Remove(candidat);
            return candidat;
        }

        public string PickRandomLot()
        {
            int value = randomLot.Next(lots.Count);
            string lot = lots[value];
            lots.Remove(lot);
            return lot;
        }

        public Dictionary<string, string> TirageAuSort()
        {

            Dictionary<string, string> tirage = new Dictionary<string, string>();
            bool continuerTirage = true;
            while (continuerTirage)
            {
                string candidat = PickRandomCandidate();
                string lot = PickRandomLot();
                tirage.Add(candidat, lot);
                continuerTirage = (candidats.Count > 0 && lots.Count > 0);
            }
            return tirage;
        }

        public int GetCandidateCount()
        {
            return candidats.Count;
        }

        public int GetLotsCount()
        {
            return lots.Count;
        }
    }
}
