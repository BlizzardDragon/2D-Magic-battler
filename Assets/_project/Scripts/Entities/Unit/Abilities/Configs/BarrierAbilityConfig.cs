using _project.Scripts.Entities.Unit.Abilities.Effects.Configs;
using UnityEngine;

namespace _project.Scripts.Entities.Unit.Abilities.Configs
{
    [CreateAssetMenu(
        fileName = "BarrierAbilityConfig",
        menuName = "Config/Abilities/BarrierAbilityConfig",
        order = 0)]
    public class BarrierAbilityConfig : AbilityConfig
    {
        [field: SerializeField] public BarrierEffectConfig EffectConfig { get; private set; }
    }
}