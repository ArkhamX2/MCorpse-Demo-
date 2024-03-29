﻿using MegaCorps.Core.Model.Cards;
using MegaCorps.Core.Model.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaCorps.Core.Model.GameUtils
{
    public static class DeckBuilder
    {
        private const int MAX_DECK_SIZE = 100;
        private const int MAX_ATTACK_CARDS_COUNT = 35; //Всех типов атак по 5
        private const int MAX_DEFENCE_CARDS_COUNT = 35;
        static List<AttackType> attackTypes = new List<AttackType>() {
            AttackType.Trojan,
            AttackType.Worm,
            AttackType.DoS,
            AttackType.Scripting,
            AttackType.Botnet,
            AttackType.Fishing,
            AttackType.Spy };
        static List<CardDirection> directionList = new List<CardDirection>() {
            CardDirection.Left,CardDirection.Left,CardDirection.Left,CardDirection.Left,CardDirection.Left,CardDirection.Left,CardDirection.Right, CardDirection.Right,CardDirection.Right, CardDirection.Right,CardDirection.Right,CardDirection.Right,CardDirection.All,CardDirection.Allbutnotme };
        public static Deck GetDeck()
        {
            var deck = new List<GameCard>();

            for (int i = 0; i < MAX_DECK_SIZE; i++)
            {
                if (i < MAX_ATTACK_CARDS_COUNT)
                {
                    deck.Add(new AttackCard(
                        i,
                        directionList[i % directionList.Count()],
                        i >= MAX_ATTACK_CARDS_COUNT * 0.75 ? 2 : 1,
                        attackTypes[i % attackTypes.Count()]));
                }
                else if (i < MAX_ATTACK_CARDS_COUNT + MAX_DEFENCE_CARDS_COUNT)
                {
                    deck.Add(new DefenceCard(
                        i,
                        new List<AttackType> { attackTypes[
                            i % attackTypes.Count() > 0 ?
                                i % attackTypes.Count() - 1 :
                                attackTypes.Count() - 1
                            ],
                            attackTypes[i % attackTypes.Count()] }));
                }
                else
                {
                    deck.Add(new DeveloperCard(
                        i,
                        i - MAX_ATTACK_CARDS_COUNT - MAX_DEFENCE_CARDS_COUNT >= (MAX_DECK_SIZE - MAX_ATTACK_CARDS_COUNT - MAX_DEFENCE_CARDS_COUNT) * 0.75 ? 2 : 1
                        ));
                }
            }

            return new Deck(deck);
        }

    }
}
