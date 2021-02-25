using System;
using GeneticAlgorithms.Core.Entities;

namespace GeneticAlgorithms.Core.Methods
{
    public class Minimazer
    {
        #region Constructors
        public Minimazer(Population firstPopulation, Func<double, double> f)
        {
        }
        #endregion

        #region Properties

        #endregion

        public BitString Minimize() => default;

        #region Overrides
        public override string ToString() => base.ToString();
        #endregion
    }
}
