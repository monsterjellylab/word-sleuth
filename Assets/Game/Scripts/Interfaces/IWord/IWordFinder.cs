namespace Game.Scripts.Interfaces.IWord
{
    public interface IWordFinder<T>
    {
        T[] FindWordsByTheme(string themeName, WordDifficulty difficulty);
    }
}