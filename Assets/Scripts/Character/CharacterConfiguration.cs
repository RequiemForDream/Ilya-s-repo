using UnityEngine;

namespace Character
{
    [CreateAssetMenu(fileName = "Character Configuration", menuName = "SO / Character SO", order = 0)]
    public class CharacterConfiguration : ScriptableObject
    {
        [SerializeField] private CharacterView _characterView;
        [SerializeField] private CharacterModel _characterModel;

        public CharacterView CharacterView => _characterView;
        public CharacterModel CharacterModel => _characterModel;
    }
}
