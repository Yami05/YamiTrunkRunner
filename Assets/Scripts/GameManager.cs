using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    GameEvents gameEvents;

    void Start()
    {
        gameEvents = GameEvents.instance;
        gameEvents.Restart += () => SceneManager.LoadScene("SampleScene");
        gameEvents.NextLevel += NextLevel;
    }


    private void Update()
    {
        if (Input.GetKey(KeyCode.N))
        {
            gameEvents.NextLevel?.Invoke();
        }
    }

    private void NextLevel()
    {
        Utilities.SetLevelPref();
        SceneManager.LoadScene("SampleScene");
    }
}
