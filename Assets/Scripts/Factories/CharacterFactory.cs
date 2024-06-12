using Character;
using Core;
using Core.Interfaces;
using UI;
using Object = UnityEngine.Object;

namespace Factories
{
    public class CharacterFactory : IFactory<MainCharacter>
    {
        private readonly CharacterConfiguration _characterConfiguration;
        private readonly Updater _updater;
        private readonly IInputService _inputService;
        private readonly GameCanvas _gameCanvas;

        public CharacterFactory(CharacterConfiguration characterConfiguration, Updater updater, IInputService inputService,
            GameCanvas gameCanvas)
        {
            _characterConfiguration = characterConfiguration;
            _updater = updater;
            _inputService = inputService;
            _gameCanvas = gameCanvas;
        }

        public MainCharacter Create()
        {
            var characterView = Object.Instantiate(_characterConfiguration.CharacterView);

            var character = new MainCharacter(characterView, _characterConfiguration.CharacterModel, _updater, _inputService,
                _gameCanvas);

            return character;
        }
    }
}
