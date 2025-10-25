using System;

public class HumanPlayer : Player
{
    public string Name { get; set; }

    public HumanPlayer(string name, DiskColor disk)
    {
        this.Name = name;
        this.diskColor = disk;
    }


    public override void RequestMove()
    {

    }

