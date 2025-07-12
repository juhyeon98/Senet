using UnityEngine;

using Effect;

public class Dice : MonoBehaviour
{
    public EffectData[] effectDatats = new EffectData[6];
    private uint mValue;
    private EEffectType mEffectType;
    private EApplyType mApplyType;

    public void Role()
    {
    }

    public static Dice Create()
    {
        return new Dice();
    }
}
