﻿public class PairOfArrays<TLeft, TRight>
{
    private readonly TLeft[] _left;
    private readonly TRight[] _right;

    public PairOfArrays(
        TLeft[] left, TRight[] right)
    {
        _left = left;
        _right = right;
    }

    public object this[int leftIndex, int rightIndex]
    {
        get => (_left[leftIndex], _right[rightIndex]);
        set { /* set the specified index to value here */ }
    }
}