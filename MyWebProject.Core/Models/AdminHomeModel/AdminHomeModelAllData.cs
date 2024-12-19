using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebProject.Core.Models.AdminHomeModel
{
    public class AdminHomeModelAllData
    {
        public int CountOfUsers { get; set; }
        public int NotActivUsers { get; set; }

        public int CountOfEvents { get; set; }
        public int NotActiveEvents { get; set; }

        public int CountOfFacts { get; set; }
        public int NotActiveFacts { get; set; }

        public int CountOfCategory { get; set; }
        public int NotActiveCategory { get; set; }

        public int CountOfJourney { get; set; }
        public int NotActiveJourney { get; set; }

        public int CountOfTown  { get; set; }
        public int NotActiveTown { get; set; }

        public int CountOfLandmarks  { get; set; }
        public int NotActivLandMark { get; set; }

        public int CountOfPictures  { get; set; }
        public int NotActivPictures { get;set; }
    }
}
