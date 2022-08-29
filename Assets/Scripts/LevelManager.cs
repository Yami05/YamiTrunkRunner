using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private LevelScriptableObject[] level;
    private void Awake()
    {
        level = Resources.LoadAll<LevelScriptableObject>("Levels");
        Instantiate(level[PlayerPrefs.GetInt(Utilities.LevelIndex) % level.Length].LevelPrefab);
    }
}
