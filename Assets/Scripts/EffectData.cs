using UnityEngine;

namespace Effect
{
    [CreateAssetMenu(fileName = "EffectData", menuName = "Scriptable Objects/EffectData")]
    public class EffectData : ScriptableObject
    {
        [SerializeField] private uint hp;
        [SerializeField] private uint mp;
        [SerializeField] private uint ap;
        [SerializeField] private uint atk;
        [SerializeField] private uint def;
        [SerializeField] private EApplyType applyType;

        public uint HP => hp;
        public uint MP => mp;
        public uint AP => ap;
        public uint ATK => atk;
        public uint DEF => def;
        public EApplyType ApplyType => applyType;
    }

    public enum EApplyType
    {
        HP, MP, AP, ATK, DEF, Size
    };

    public enum EEffectType
    {
        HP, MP, AP, ATK, DEF
    };
}
