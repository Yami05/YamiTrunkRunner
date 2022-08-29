using UnityEngine;


public enum PoolItems
{
    diamond,
    stone,
    GoldParticle
}


public class Utilities : MonoBehaviour
{
    public const string isRun = "isRun";
    public const string isOver = "isOver";
    public const string isFinished = "isFinished";

    public const string LevelIndex = "LevelIndex";
    public static void SetLevelPref(int levelCount = 1)
    {
        PlayerPrefs.SetInt(LevelIndex, PlayerPrefs.GetInt(LevelIndex, 0) + levelCount);
    }
}
