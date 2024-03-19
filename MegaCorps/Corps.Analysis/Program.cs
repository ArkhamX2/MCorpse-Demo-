﻿using MegaCorps.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corps.Analysis
{
    internal class Program
    {
        private const string BEST_STRATEGY = "BestStrategy";
        private const string RANDOM_STRATEGY = "RandomStrategy";
        private const string ATTACK_STRATEGY = "AttackStrategy";
        private const string DEFENCE_STRATEGY = "DefenseStrategy";
        private const string DEVELOP_STRATEGY = "DeveloperStrategy";
        private static Dictionary<string, ISelectionStrategy> possibleStrategy = new Dictionary<string, ISelectionStrategy>() {

            {BEST_STRATEGY ,new BestSelectStrategy() },
            {RANDOM_STRATEGY ,new RandomSelectStrategy() },
            {ATTACK_STRATEGY ,new AgressiveSelectStrategy() },
            {DEFENCE_STRATEGY ,new DefenciveSelectStrategy() },
            {DEVELOP_STRATEGY ,new DevelopSelectStrategy() }
        };

        static void Main(string[] args)
        {
            TestBestStrategy();
        }

        private static void TestBestStrategy()
        {
            AnalizeGame(new List<ISelectionStrategy> {
                possibleStrategy[ATTACK_STRATEGY],
                possibleStrategy[RANDOM_STRATEGY]
            });
            AnalizeGame(new List<ISelectionStrategy> {
                possibleStrategy[ATTACK_STRATEGY],
                possibleStrategy[RANDOM_STRATEGY],
                possibleStrategy[RANDOM_STRATEGY]
            });
            AnalizeGame(new List<ISelectionStrategy> {
                possibleStrategy[ATTACK_STRATEGY],
                possibleStrategy[RANDOM_STRATEGY],
                possibleStrategy[RANDOM_STRATEGY],
                possibleStrategy[RANDOM_STRATEGY]
            });
            AnalizeGame(new List<ISelectionStrategy> {
                possibleStrategy[ATTACK_STRATEGY],
                possibleStrategy[RANDOM_STRATEGY],
                possibleStrategy[RANDOM_STRATEGY],
                possibleStrategy[RANDOM_STRATEGY],
                possibleStrategy[RANDOM_STRATEGY]
            });
            AnalizeGame(new List<ISelectionStrategy> {
                possibleStrategy[ATTACK_STRATEGY],
                possibleStrategy[RANDOM_STRATEGY],
                possibleStrategy[RANDOM_STRATEGY],
                possibleStrategy[RANDOM_STRATEGY],
                possibleStrategy[RANDOM_STRATEGY],
                possibleStrategy[RANDOM_STRATEGY]
            });
        }

        private static void AnalizeGame(List<ISelectionStrategy> strategyList)
        {
            Analizer analizer = new Analizer(strategyList);

            Console.WriteLine(analizer.Run(50));
            Console.WriteLine(analizer.Run(100));
            Console.WriteLine(analizer.Run(250));
            Console.WriteLine(analizer.Run(500));
            Console.WriteLine(analizer.Run(1000));

        }
    }
}