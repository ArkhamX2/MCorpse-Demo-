﻿using MegaCorps.Core.Model.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaCorps.Core.Model
{
    public static class SelectHelper
    {
        public static List<List<int>> SelectCards(List<List<GameCard>> hands, List<ISelectionStrategy> strategyList, int numberToSelect)
        {
            var selected = new List<List<int>>();
            for (int i = 0; i < hands.Count()-1; i++)
            {
                selected.Add(strategyList[i].Select(i, hands, numberToSelect, selected));
            }
            selected.Add(strategyList[hands.Count() - 1].Select(hands.Count() - 1, hands, numberToSelect, selected));
            return selected;
        }
    }
}
