using System;

namespace NieRAutoIntelTracker
{
    public class BitCount
    {
        private static int[] _bitcounts; // Lookup table
        static BitCount()
        {
            _bitcounts = new int[256];
            int position1 = -1;
            int position2 = -1;

            for (int i = 1; i < 256; i++, position1++)
            {
                if (position1 == position2)
                {
                    position1 = 0;
                    position2 = i;
                }
                _bitcounts[i] = (_bitcounts[position1] + 1);
            }
        }

        public static int PrecomputedBitcount(byte value)
        {
            return _bitcounts[value];
        }

        public static int PrecomputedBitcount(int value)
        {
            return PrecomputedBitcount((byte)value);
        }
    }
}
