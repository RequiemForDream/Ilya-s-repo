using Character;
using Core;
using Core.Interfaces;
using Object = UnityEngine.Object;

namespace Factories
{
    public class CharacterFactory : IFactory<MainCharacter>
    {
        private readonly CharacterConfiguration _characterConfiguration;
        private readonly Updater _updater;
        private readonly IInputService _inputService;

        public CharacterFactory(CharacterConfiguration characterConfiguration, Updater updater, IInputService inputService)
        {
            _characterConfiguration = characterConfiguration;
            _updater = updater;
            _inputService = inputService;
        }

        public MainCharacter Create()
        {
            var characterView = Object.Instantiate(_characterConfiguration.CharacterView);

            var character = new MainCharacter(characterView, _characterConfiguration.CharacterModel, _updater, _inputService);

            return character;
        }
    }
}
