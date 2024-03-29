﻿using Corps.Core.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corps.Core.Model.Cards
{
    public class AttackCard:GameCard
    {
        public int Damage {  get; set; }
        public CardDirection Direction { get; set; }
        public AttackType AttackType { get; set; }
        public AttackCard(int id,AttackType attackType,CardDirection direction) : base(id)
        {
            AttackType = attackType;
            Direction = direction;
        }
        

    }
}
