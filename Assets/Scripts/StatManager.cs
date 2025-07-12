using System.Collections.Generic;
using UnityEngine;

public class StatManager
{
    private StatData mData;
    private Dictionary<EStatType, uint> mStats = new Dictionary<EStatType, uint>();

    public uint HP => mStats[EStatType.HP];
    public uint MP => mStats[EStatType.MP];
    public uint AP => mStats[EStatType.AP];
    public uint ATK => mStats[EStatType.ATK];
    public uint DEF => mStats[EStatType.DEF];

    public StatManager(StatData data)
    {
        mData = data;
        Reset();
    }

    public void Reset()
    {
        mStats.Clear();
        mStats[EStatType.HP] = mData.HP;
        mStats[EStatType.MP] = mData.MP;
        mStats[EStatType.AP] = mData.AP;
        mStats[EStatType.ATK] = mData.ATK;
        mStats[EStatType.DEF] = mData.DEF;
    }

    public void IncreaseStat(EStatType type, uint value)
    {
        mStats[type] += value;
    }

    public void DecreaseStat(EStatType type, uint value)
    {
        if (mStats[type] - value > 0)
        {
            mStats[type] -= value;
        }
    }
}
