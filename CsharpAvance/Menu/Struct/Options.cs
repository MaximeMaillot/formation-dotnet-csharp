using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Struct;
public struct Options
{
    public Options(int[] different = null, int min = int.MinValue, int max = int.MaxValue)
    {
        Different = different;
        Min = min;
        Max = max;
    }

    public int[] Different { get; }
    public int Min { get; }
    public int Max { get; }

    public bool DifferentIsNull()
    {
        return Different == null || Different.Length == 0;
    }

    public bool MinIsSet()
    {
        return Min != int.MinValue;
    }

    public bool MaxIsSet()
    {
        return Max != int.MaxValue;
    }
}
