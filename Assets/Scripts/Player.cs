using UnityEngine;

public class Player : MonoBehaviour
{
    public StatData statData;
    private StatManager mStatManager;
    private Inventory mInventory;
    private Effect mEffect = null;

    public void Initialize(StatData statData)
    {
        mStatManager = new StatManager(statData);
        mInventory = new Inventory();

        if (statData == null)
        {
            throw new System.Exception("Stat data is null");
        }

        Debug.Log($"[HP  : {mStatManager.HP}]");
        Debug.Log($"[MP  : {mStatManager.MP}]");
        Debug.Log($"[AP  : {mStatManager.AP}]");
        Debug.Log($"[ATK : {mStatManager.ATK}]");
        Debug.Log($"[DEF : {mStatManager.DEF}]");
    }

    public void RoleDice() => mInventory.RoleAll();

    public void Action() => mEffect.Active();
}
