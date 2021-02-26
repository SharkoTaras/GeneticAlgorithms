using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using GeneticAlgorithms.Core.Entities;
using GeneticAlgorithms.Core.Extensions;

namespace GeneticAlgorithms.Core.MultiDimention
{
    public class MDBitString : List<BitString>
    {
        #region Private Fields
        private bool IsChanged;
        #endregion

        #region Constructor

        public MDBitString()
        {
            Bits = new List<Bit>();
            RBits = new List<Bit>();
            IsChanged = false;
        }
        #endregion

        #region Properties
        public uint DimentionsCount => (uint)Count;

        public uint N
        {
            get
            {
                if (this.FirstOrDefault() != null)
                {
                    return (uint)(Count * this.First().Count);
                }
                return default;
            }
        }

        public List<Bit> Bits { get; private set; }

        public List<Bit> RBits { get; private set; }
        #endregion

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public new void Add(BitString bits)
        {
            base.Add(bits);
            IsChanged = true;
            GetBits();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Bit GetAt(uint n)
        {
            if (Count != 0 && Bits.Count() == 0)
            {
                GetBits();
            }
            var t = Bits;
            return t[(int)n];
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetAt(uint n, Bit bit) => ((IList<Bit>)Bits)[(int)n] = bit;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SyncInnerBits(bool useRBits = false)
        {
            var lenght = this.First().Count;
            var dCount = DimentionsCount;
            Clear();

            var bits = useRBits ? RBits : Bits;

            for (var i = 0; i < dCount; i++)
            {
                var str = new BitString(new string(bits.Take(lenght).Select(b => b.Value.ToInt().ToString().ToArray().First()).ToArray()));
                Add(str);
            }
            Reverse();
            IsChanged = true;
            GetBits();
        }

        #region Overrides
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString() => string.Join("|", this);
        #endregion

        #region Helper Methods
        private void GetBits()
        {
            Bits ??= new List<Bit>();

            if (IsChanged)
            {
                Bits.Clear();
            }

            IEnumerable<Bit> t = new List<Bit>();
            foreach (var bs in this)
            {
                t = t.Concat(bs);
            }

            RBits = t.ToList();
            t = t.Reverse();
            Bits = t.ToList();
            IsChanged = false;
        }
        #endregion
    }
}
