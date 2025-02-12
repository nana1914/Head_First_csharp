using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ch5_CowCalculator
{
    class Farmer
    {
        public int BagsOfFeed;
        public const int FeedMultiplier = 30;

        private int numberOfCows;
        public int NumerOfCows
        {
            get
            {
                return numberOfCows;
            }
            set
            {
                numberOfCows = value;   // 속성에 할당된 값
                BagsOfFeed = numberOfCows * FeedMultiplier;
            }
        }
    }
}
