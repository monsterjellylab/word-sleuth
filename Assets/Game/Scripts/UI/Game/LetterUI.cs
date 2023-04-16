using TMPro;
using UnityEngine;

namespace Game.Scripts.UI.Game
{
    public class LetterUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text textField;

        public char OriginalLetter;

        public void SetLetter(char originalLetter, char randomLetter)
        {
            textField.text = randomLetter.ToString();
            OriginalLetter = originalLetter;

            Debug.Log(originalLetter);
        }

        public void Reset()
        {
            textField.text = "";
            OriginalLetter = default;
            
            Debug.LogWarning($"{name} RESET!");
        }
    }
}