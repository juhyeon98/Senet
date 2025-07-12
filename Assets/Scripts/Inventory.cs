using UnityEngine;
using System.Collections.Generic;

public class Inventory
{
    private List<Dice> mDice = new List<Dice>();
    private uint mMaxNDice = 3;

    public List<Dice> Dice() => mDice;

    public Inventory()
    {
        mDice.Clear();
    }

    public void AddDice(Dice dice)
    {
        if (mDice.Count + 1 < mMaxNDice)
        {
            mDice.Add(dice);
        }
    }

    public void RoleAll()
    {
    }
}
