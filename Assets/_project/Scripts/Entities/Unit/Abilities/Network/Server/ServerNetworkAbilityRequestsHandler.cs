namespace _project.Scripts.Entities.Unit.Abilities.Network.Server
{
    public class ServerNetworkAbilityRequestsHandler
    {
        private readonly INetworkAbilitiesAdapter _networkAbilitiesAdapter;
        private readonly IServerToClientAbilityStateSender _sender;
        private readonly IAbilityManager _abilityManager;

        public ServerNetworkAbilityRequestsHandler(
            INetworkAbilitiesAdapter networkAbilitiesAdapter,
            IServerToClientAbilityStateSender sender,
            IAbilityManager abilityManager)
        {
            _networkAbilitiesAdapter = networkAbilitiesAdapter;
            _sender = sender;
            _abilityManager = abilityManager;
        }

        public void OnEnable()
        {
            _networkAbilitiesAdapter.ClientUseAbilityRequested += OnClientUseAbilityRequested;
            _networkAbilitiesAdapter.ClientAbilityStateUpdateRequested += UpdateAbilityState;
        }

        public void OnDisable()
        {
            _networkAbilitiesAdapter.ClientUseAbilityRequested -= OnClientUseAbilityRequested;
            _networkAbilitiesAdapter.ClientAbilityStateUpdateRequested -= UpdateAbilityState;
        }

        private void OnClientUseAbilityRequested(AbilityType type)
        {
            var ability = _abilityManager.GetAbility(type);

            ability.Use();
            _sender.SendAbilityStateToClient(ability);
        }

        private void UpdateAbilityState(AbilityType type)
        {
            var ability = _abilityManager.GetAbility(type);
            _sender.SendAbilityStateToClient(ability);
        }
    }
}