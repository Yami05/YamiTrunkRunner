using TMPro;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject nextLevelPanel;

    private GameEvents gameEvents;

    private int levelCount;
    private void Start()
    {
        gameEvents = GameEvents.instance;

        gameEvents.Start += () => startPanel.SetActive(false);
        gameEvents.GameOver += () => gameOverPanel.SetActive(true);
        gameEvents.Win += () => nextLevelPanel.SetActive(true);

        levelCount = PlayerPrefs.GetInt(Utilities.LevelIndex) + 1;

        levelText.text = "Lv." + levelCount.ToString();
    }

    //public void GameStart() => gameEvents.Start?.Invoke();
    public void Restart() => gameEvents.Restart?.Invoke();
    public void NextLevel() => gameEvents.NextLevel?.Invoke();
}


