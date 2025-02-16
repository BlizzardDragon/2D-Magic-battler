using System;

namespace _project.Scripts.Entities.Unit.Abilities.Network
{
    public interface INetworkAbilitiesAdapter
    {
        event Action<AbilityType> ClientUseAbilityRequested;
        event Action<AbilityType> ClientAbilityStateUpdateRequested;
        event Action<AbilityType, bool> ServerUpdatedAbilityEnable;
        event Action<AbilityType, int?> ServerUpdatedAbilityCooldown;

        void UseAbilityRequest_Client(AbilityType type);
        void RequestUpdateAbilityState_Client(AbilityType type);
        void UpdateAbilityEnable_Server(AbilityType type, bool enable);
        void UpdateAbilityCooldown_Server(AbilityType type, int? cooldown);
    }

    public class NetworkAbilitiesAdapter : INetworkAbilitiesAdapter
    {
        public event Action<AbilityType> ClientUseAbilityRequested;
        public event Action<AbilityType> ClientAbilityStateUpdateRequested;
        public event Action<AbilityType, bool> ServerUpdatedAbilityEnable;
        public event Action<AbilityType, int?> ServerUpdatedAbilityCooldown;

        public void UseAbilityRequest_Client(AbilityType type)
        {
            UseAbilityRequest_Server(type);
        }

        private void UseAbilityRequest_Server(AbilityType type)
        {
            ClientUseAbilityRequested?.Invoke(type);
        }

        public void RequestUpdateAbilityState_Client(AbilityType type)
        {
            RequestUpdateAbilityState_Server(type);
        }

        private void RequestUpdateAbilityState_Server(AbilityType type)
        {
            ClientAbilityStateUpdateRequested?.Invoke(type);
        }

        public void UpdateAbilityEnable_Server(AbilityType type, bool enable)
        {
            UpdateAbilityEnable_Client(type, enable);
        }

        private void UpdateAbilityEnable_Client(AbilityType type, bool enable)
        {
            ServerUpdatedAbilityEnable?.Invoke(type, enable);
        }

        public void UpdateAbilityCooldown_Server(AbilityType type, int? cooldown)
        {
            UpdateAbilityCooldown_Client(type, cooldown);
        }

        private void UpdateAbilityCooldown_Client(AbilityType type, int? cooldown)
        {
            ServerUpdatedAbilityCooldown?.Invoke(type, cooldown);
        }
    }
}