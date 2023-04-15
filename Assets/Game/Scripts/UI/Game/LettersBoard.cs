using System.Linq;
using System.Text;
using Game.Scripts.Helpers;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Game.Scripts.UI.Game
{
    public class LettersBoard : MonoBehaviour
    {
        [Space] [Title("Refs")] [PropertyOrder(1)] [SerializeField, ReadOnly]
        private WordUI[] wordUIElements;

        [PropertyOrder(1)]
        [Button]
        private void SetRefs()
        {
            wordUIElements = GetComponentsInChildren<WordUI>(true);
        }

        // Creates a letter board and fills them with proper word letters
        
        // TODO: Apply SRP
        public void InitializeBoard(string selectedWord)
        {
            /*
             * Word can be multiple sub-words separated by space.
             * That's why it should split by space.
             */
            var subWords = selectedWord.Split(" ");

            // Initialize count variable that store number of words
            int wordCount = subWords.Length;

            /*
             * Combine words as a single word.
             * Ex: Let's say word is "The Last Of Us". In that case, our `combinedLetters` must be "thelastofus".
             */
            StringBuilder combinedLettersBuilder = new StringBuilder();

            foreach (var subWord in subWords)
            {
                combinedLettersBuilder.Append(subWord);
            }

            // Make all letters lowercase and assign to string variable

            string combinedLetters = combinedLettersBuilder.ToString().ToLower();

            // Initialize list of combined letters
            var combinedLettersList = combinedLetters.ToList();

            // Shuffle original combinedLetters and assign to a variable
            string shuffledLetters = combinedLetters.ShuffleWord();

            // Initialize list of shuffled letters
            var shuffledLettersList = shuffledLetters.ToList();

            int letterIndex = 0;

            for (int i = 0; i < wordCount; i++)
            {
                var currentWordLength = subWords[i].Length;
                var originalLetterArr = new char[currentWordLength];
                var randomLetterArr = new char[currentWordLength];

                for (var j = 0; j < currentWordLength; j++)
                {
                    var originalLetter = combinedLettersList[letterIndex];
                    originalLetterArr[j] = originalLetter;

                    char randomLetter = default;

                    for (int k = 0; k < shuffledLettersList.Count; k++)
                    {
                        randomLetter = shuffledLettersList[k];
                        
                        if (k == shuffledLettersList.Count - 1)
                            break;
                        
                        if (!randomLetter.Equals(originalLetter))
                            break;
                    }

                    randomLetterArr[j] = randomLetter;

                    shuffledLettersList.Remove(randomLetter);

                    letterIndex++;
                }

                wordUIElements[i].gameObject.SetActive(true);
                wordUIElements[i].ConstructWord(originalLetterArr, randomLetterArr);
            }
        }
    }
}