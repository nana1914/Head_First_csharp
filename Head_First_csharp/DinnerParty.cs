﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Head_First_csharp
{
    class DinnerParty
    {
        public const int CostOfFoodPerPerson = 25;      // 1인당 식비
        private int NumberOfPeople = 5;                      // 사람의 수
        public decimal CostOfBeveragesPerPerson;        // 1인당 음료 비용
        public decimal CostOfDecorations;               // 장식 비용

        public void SetPartyOptions(int people, bool fancy)
        {
            NumberOfPeople = people;
            CalculateCostOfDecorations(fancy);
        }

        public int GetNumberOfPeople()
        {
            return NumberOfPeople;
        }

        public void SetHealthyOption(bool healthyOption)
        {
            if (healthyOption)
                CostOfBeveragesPerPerson = 5.0M;
            else
                CostOfBeveragesPerPerson = 20.0M;
        }

        public void CalculateCostOfDecorations(bool fancyOption)
        {
            if (fancyOption)
                CostOfDecorations = (NumberOfPeople * 15.0M) + 50.0M;      // 1인당 15달러 + 기본 장식비 50달러
            else
                CostOfDecorations = (NumberOfPeople * 7.0M) + 30.0M;       // 1인당 7달러 + 기본 장식비 30달러
        }

        public decimal CalculateCost(bool healthyOption)  // 총 비용 계산 후 할인율을 적용한 값을 반환
        {
            decimal totalCost;
            totalCost = CostOfDecorations + ((CostOfBeveragesPerPerson + CostOfFoodPerPerson) * NumberOfPeople);

            if (healthyOption)
                return totalCost * .95M;
            else
                return totalCost;
        }
    }
}
