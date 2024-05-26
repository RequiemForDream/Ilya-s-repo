using Character;
using Core.Interfaces;
using Factories;
using UnityEngine;
using Utilities;

namespace Core
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private Updater _updater;

        [Header("Configurations")]
        [SerializeField] private CharacterConfiguration _characterConfiguration;

        private void Awake()
        {
            BindCursorHandler().LockCursor();
            var inputService = BindInputSetvice();
            var character = BindCharacter(inputService);

            var level = new Level(character);
            level.Start();
        }

        private MainCharacter BindCharacter(IInputService inputService)
        {
            var factory = new CharacterFactory(_characterConfiguration, _updater, inputService);
            return factory.Create();
        }

        private InputService BindInputSetvice()
        {
            return new InputService(_updater);
        }

        private CursorHandler BindCursorHandler()
        {
            return new CursorHandler();
        }
    }
}