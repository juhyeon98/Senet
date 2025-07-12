using UnityEngine;

using Stat;
using Effect;

public class Player : MonoBehaviour
{
    public StatData statData;
    private uint[] mStatManager = new uint[(int)EStatType.Size];
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

    public void RoleDice() => mDice.Role();

    public void Action() => mEffect.Active();
}
