using UnityEngine;

[CreateAssetMenu(fileName = "StatData", menuName = "Scriptable Objects/StatData")]
public class StatData : ScriptableObject
{
    [SerializeField] private uint hp;
    [SerializeField] private uint mp;
    [SerializeField] private uint ap;
    [SerializeField] private uint atk;
    [SerializeField] private uint def;

    public uint HP => hp;
    public uint MP => mp;
    public uint AP => ap;
    public uint ATK => atk;
    public uint DEF => def;
}

public enum EStatType
{
    HP,
    MP,
    AP,
    ATK,
    DEF,
    Size
};