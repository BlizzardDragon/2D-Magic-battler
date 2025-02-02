using System;
using _project.Scripts.Entities.Unit.Abilities.Configs;

namespace _project.Scripts.Entities.Unit.Abilities
{
    public abstract class Ability
    {
        private readonly AbilityConfig _config;

        protected Ability(AbilityConfig config)
        {
            _config = config;
        }

        public bool IsAvailable => Cooldown <= 0;
        public int Cooldown { get; private set; }

        public event Action CooldownUpdated;

        public void TickCooldown()
        {
            Cooldown--;

            if (Cooldown < 0)
            {
                Cooldown = 0;
            }

            CooldownUpdated?.Invoke();
            OnTickCooldown();
        }

        protected virtual void OnTickCooldown()
        {
        }

        public void Use()
        {
            if (!IsAvailable) return;

            Cooldown = _config.Cooldown;
            CooldownUpdated?.Invoke();

            OnUse();
        }

        protected abstract void OnUse();
    }
}