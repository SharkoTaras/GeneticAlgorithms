using System.Runtime.CompilerServices;
using GeneticAlgorithms.Core.Extensions;

namespace GeneticAlgorithms.Core.Entities
{
    public class Bit
    {
        #region Constructors
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Bit() => Value = default;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Bit(int value) => Value = value.ToBool();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Bit(string value) => Value = value.ToBool();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Bit(bool value) => Value = value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Bit(char value) => Value = value.ToString().ToBool();
        #endregion

        public bool Value { get; set; }

        #region Casts
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int(Bit bit) => bit.Value.ToInt();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool(Bit bit) => bit.Value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Bit(bool value) => new Bit(value);
        #endregion

        #region Operators
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Bit operator !(Bit bit) => new Bit(!bit.Value);
        #endregion

        #region Overrides
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString() => Value.ToInt().ToString();
        #endregion
    }
}
