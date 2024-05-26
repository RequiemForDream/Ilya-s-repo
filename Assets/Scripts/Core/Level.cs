using Character;

namespace Core
{
    public class Level
    {
        private readonly MainCharacter _character;

        public Level(MainCharacter character)
        {
            _character = character;
        }

        public void Start()
        {
            _character.Initialize();
        }
    }
}