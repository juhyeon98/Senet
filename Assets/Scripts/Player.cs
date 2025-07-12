using UnityEngine;
using System.Collections;
using System;

public class Player : MonoBehaviour
{
    public StatData statData;
    private uint[] mStatManager = new uint[EStatType.Size];
    private Dice mDice;
    private Effect mEffect = null;

    public void Initialize(StatData statData)
    {
        if (statData == null)
        {
            throw new System.Exception("Stat data is null");
        }
        this.statData = statData;

        mStatManager[0] = statData.HP;
        mStatManager[1] = statData.MP;
        mStatManager[2] = statData.AP;
        mStatManager[3] = statData.ATK;
        mStatManager[4] = statData.DEF;

        mDice = Dice.Create();
    }

    public RoleDice => mDice.Role();

    public Action => mEffect.Active();
}
