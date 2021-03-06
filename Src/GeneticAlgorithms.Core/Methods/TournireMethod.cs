﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using GeneticAlgorithms.Core.Entities;

namespace GeneticAlgorithms.Core.Methods
{
    public class TournireMethod<T> : ISelector
    {
        #region Private fields
        private Random random;
        #endregion

        #region Constructors
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TournireMethod(Population<T> population, uint individualsCount)
        {
            random = new Random();
            Population = population;
            IndividualsCount = individualsCount;
        }
        #endregion

        #region Properties
        public Population<T> Population { get; }

        public uint IndividualsCount { get; }
        #endregion

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T Select(Evaluator evaluator)
        {
            var list = new List<T>();
            var count = Population.Count;
            for (var i = 0; i < IndividualsCount; i++)
            {
                var ind = random.Next(0, count);
                list.Add(Population[ind]);
            }
            return list.OrderBy(s => evaluator.Eval(s).Item1).First();
        }

        #region Overrides
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString() => base.ToString();
        #endregion
    }
}
