namespace GeneticAlgorithms.Core.Extensions
{
    public class AlgorithmContext
    {
        #region Constructors
        public AlgorithmContext(uint individesCount,
                                uint tournireMethodIndividesCount,
                                double mutateProbability,
                                double crossProbability,
                                uint maxIterations,
                                double step)
        {
            IndividesCount = individesCount;
            TournireMethodIndividesCount = tournireMethodIndividesCount;
            MutateProbability = mutateProbability;
            CrossProbability = crossProbability;
            MaxIterations = maxIterations;
            Step = step;
        }
        #endregion

        #region Properties
        public uint IndividesCount { get; }
        public uint TournireMethodIndividesCount { get; }
        public double MutateProbability { get; }
        public double CrossProbability { get; }
        public uint MaxIterations { get; }
        public double Step { get; }
        #endregion

        #region Overrides
        public override string ToString() => base.ToString();
        #endregion
    }
}
