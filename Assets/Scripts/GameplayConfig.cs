public class GameplayConfig
{
    public int GridWidght;
    public int GridHeight;
    public int LineCleanReward;
    public float StartFallSpeedMultiplier;
    public float SpeedMultiplierOnCleanLine;
    public string BlockPrefabPath;

    public GameplayConfig()
    {
        GridWidght = 8;
        GridHeight = 16;
        LineCleanReward = 5;
        StartFallSpeedMultiplier = 1;
        SpeedMultiplierOnCleanLine = 1.2f;
        BlockPrefabPath = "Block";

}
}
