using System;

public class BlockUpdateArgs : EventArgs
{
    public int X;
    public int Y;
    public BlockState BlockState;
    public BlockUpdateArgs(int x, int y, BlockState blockState)
    {
        X = x;
        Y = y;
        BlockState = blockState;
    }
}