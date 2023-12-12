
static Tuple<T2, T1> SwapTupleItems<T1, T2>(Tuple<T1, T2> sourceTuple)
{
    return new Tuple<T2, T1>(sourceTuple.Item2, sourceTuple.Item1);
}