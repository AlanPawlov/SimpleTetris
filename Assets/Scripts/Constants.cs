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

    public class ResourcesMap
    {
        public static readonly string DefaultButton = "DefaultButtonWidget";
        public static readonly string PauseButton = "PauseButtonWidget";
        public static readonly string DefaultLabelWithBackGround = "DefaultLabelWidgetWithBackground";

        public static readonly string MainMenuWindow = "MainMenuWindow";
        public static readonly string PauseWindow = "PauseWindow";
        public static readonly string GameplayWindow = "GameplayWindow";
        public static readonly string LoseWindow = "LoseWindow";

        public static readonly string MainMenuScene = "";
        public static readonly string GameplayScene = "";
    }
}
