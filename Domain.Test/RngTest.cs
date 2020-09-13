using System.Linq;
using System.Collections.Generic;
using Xunit;

namespace Domain.Test
{
    public class RngTest
    {
        [Fact]
        public void ShouldGetNoMoreCandidate_When1CandidateInitiallyAnd1CandidatePicked()
        {
            string expected = "candidat";
            Rng rng = new Rng(new List<string>() { "candidat" }, new List<string>());

            string candidat = rng.PickRandomCandidate();

            Assert.Equal(expected, candidat);
            Assert.Equal(0, rng.GetCandidateCount());
        }

        [Fact]
        public void ShouldGetTwoCandidates_When2CandidateInitially()
        {

            Rng rng = new Rng(new List<string>() { "candidat", "toto" }, new List<string>());

            int candidatesCount = rng.GetCandidateCount();

            Assert.Equal(2, candidatesCount);
        }

        [Fact]
        public void ShouldGetNoMoreLot_When1LotInitiallyAnd1LotPicked()
        {
            string expected = "chat";
            Rng rng = new Rng(new List<string>(), new List<string>() { "chat"});

            string lot = rng.PickRandomLot();

            Assert.Equal(expected, lot);
            Assert.Equal(0, rng.GetLotsCount());
        }

        [Fact]
        public void ShouldGetTwoLots_When2LotsInitially()
        {

            Rng rng = new Rng(new List<string>(), new List<string>() { "chat", "fraise" });

            int lotsCount = rng.GetLotsCount();

            Assert.Equal(2, lotsCount);
        }

        [Fact]
        public void ShouldGetTwoDifferentCandidatesList_WhenRngLaunchedTwoTimesWithSameList()
        {
            var candidates = new List<string>()
            {
                "Anne",
                "Baptiste",
                "Charles",
                "Damien",
                "Emmanuel",
                "François",
                "Géraldine",
                "Hubert"
            };
            var candidates2 = candidates.ToList();

            List<string> picker1 = new List<string>();
            Rng rng = new Rng(candidates, new List<string>());
            picker1.Add(rng.PickRandomCandidate());
            picker1.Add(rng.PickRandomCandidate());
            picker1.Add(rng.PickRandomCandidate());
            picker1.Add(rng.PickRandomCandidate());
            picker1.Add(rng.PickRandomCandidate());
            picker1.Add(rng.PickRandomCandidate());
            picker1.Add(rng.PickRandomCandidate());
            picker1.Add(rng.PickRandomCandidate());

            List<string> picker2 = new List<string>();
            Rng rng2 = new Rng(candidates2, new List<string>());
            picker2.Add(rng2.PickRandomCandidate());
            picker2.Add(rng2.PickRandomCandidate());
            picker2.Add(rng2.PickRandomCandidate());
            picker2.Add(rng2.PickRandomCandidate());
            picker2.Add(rng2.PickRandomCandidate());
            picker2.Add(rng2.PickRandomCandidate());
            picker2.Add(rng2.PickRandomCandidate());
            picker2.Add(rng2.PickRandomCandidate());
                           
            Assert.False(AreListsEqual(picker1, picker2));
        }

        [Fact]
        public void ShouldGetTwoDifferentGiftsList_WhenRngLaunchedTwoTimesWithSameList()
        {
            var lots = new List<string>()
            {
                "Avion",
                "Bonbon",
                "Cahier",
                "Dé",
                "Eponge",
                "Feuille",
                "Garage",
                "Haricot"
            };
            var lots2 = lots.ToList();

            List<string> picker1 = new List<string>();
            Rng rng = new Rng(new List<string>(), lots);
            picker1.Add(rng.PickRandomLot());
            picker1.Add(rng.PickRandomLot());
            picker1.Add(rng.PickRandomLot());
            picker1.Add(rng.PickRandomLot());
            picker1.Add(rng.PickRandomLot());
            picker1.Add(rng.PickRandomLot());
            picker1.Add(rng.PickRandomLot());
            picker1.Add(rng.PickRandomLot());

            List<string> picker2 = new List<string>();
            Rng rng2 = new Rng(new List<string>(), lots2);
            picker2.Add(rng2.PickRandomLot());
            picker2.Add(rng2.PickRandomLot());
            picker2.Add(rng2.PickRandomLot());
            picker2.Add(rng2.PickRandomLot());
            picker2.Add(rng2.PickRandomLot());
            picker2.Add(rng2.PickRandomLot());
            picker2.Add(rng2.PickRandomLot());
            picker2.Add(rng2.PickRandomLot());

            Assert.False(AreListsEqual(picker1, picker2));
        }

        private bool AreListsEqual(IList<string> list1, IList<string> list2)
        {
            bool areListsEqual = true;

            for (int i = 0; i < list1.Count; i++)
            {
                if (!string.Equals(list1[i], list2[i]) )
                {
                    areListsEqual = false;
                }
            }

            return areListsEqual;
        }

        [Fact]
        public void ShouldGetTwoDifferentDictionaries_WhenTirageAuSortLaunchedTwoTimes()
        {
            var lots = new List<string>()
            {
                "Avion",
                "Bonbon",
                "Cahier",
                "Dé",
                "Eponge",
                "Feuille",
                "Garage",
                "Haricot"
            };
            var lots2 = lots.ToList();

            var candidates = new List<string>()
            {
                "Anne",
                "Baptiste",
                "Charles",
                "Damien",
                "Emmanuel",
                "François",
                "Géraldine",
                "Hubert"
            };
            var candidates2 = candidates.ToList();

            var rng = new Rng(candidates, lots);
            var tirageAuSort1 = rng.TirageAuSort();

            var rng2 = new Rng(candidates2, lots2);
            var tirageAuSort2 = rng2.TirageAuSort();

            Assert.False(AreDictionariesEqual(tirageAuSort1, tirageAuSort2));


        }

        private bool AreDictionariesEqual(Dictionary<string, string> dico1, Dictionary<string, string> dico2)
        {
            bool areDictionariesEqual = true;

            for (int i = 0; i < dico1.Count; i++)
            {
                if (
                    !string.Equals(dico1.ElementAt(i).Key, dico2.ElementAt(i).Key) || 
                    !string.Equals(dico1.ElementAt(i).Value, dico2.ElementAt(i).Value)
                )
                {
                    areDictionariesEqual = false;
                }
            }

            return areDictionariesEqual;
        }
    }
}
