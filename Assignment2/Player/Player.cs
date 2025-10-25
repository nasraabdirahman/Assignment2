using System;

public abstract class Player
{
    public enum DiskColor { White, Black }

    public DiskColor diskColor { get; set; }

    public abstract void RequestMove();
}
