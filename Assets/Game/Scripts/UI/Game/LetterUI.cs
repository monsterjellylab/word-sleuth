using UnityEngine;

namespace Game.Scripts.UI.Game
{
    public class LetterUI : MonoBehaviour
    {
        public void SetLetter(char originalLetter, char randomLetter)
        {
            Debug.Log($"{name} original letter {originalLetter} ---- random letter {randomLetter}");
        }
    }
}