using Game.Scripts.Models.Theme;

namespace Game.Scripts.Interfaces.ITheme
{
    public interface IThemeLoader
    {
        Theme[] LoadThemes();
    }
}