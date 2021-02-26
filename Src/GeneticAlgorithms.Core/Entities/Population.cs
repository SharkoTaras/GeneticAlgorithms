using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace GeneticAlgorithms.Core.Entities
{
    public class Population<TIndividual> : List<TIndividual>
    {
        #region Constructors
        public Population()
        {
        }
        #endregion

        #region Properties
        public uint Number { get; set; }
        #endregion

        #region Overrides
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString() => base.ToString();
        #endregion
    }
}
