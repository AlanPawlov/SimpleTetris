using Newtonsoft.Json;
using UnityEngine;

public class Constants : MonoBehaviour
{
    public class Common
    {
        public static readonly string DictionariesPath = "Dictionaries";
        public static readonly JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Auto,
            Formatting = Formatting.Indented
        };

    }

    public class ColorCodes
    {
        public static readonly Color ColorWhite = new Color(1, 1, 1, 1);
        public static readonly Color ColorRed = new Color(1, 0, 0, 1);
        public static readonly Color FullAlpha = new Color(0, 0, 0, 0);
    }

    public class Scenes
    {
        public static readonly string MainMenuScene = "MainMenu";
        public static readonly string GameplayScene = "GameplayScene";
    }
}
