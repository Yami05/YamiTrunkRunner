using UnityEngine;

public class LavaManager : MonoBehaviour, IInteract
{
    GameEvents gameEvents;
    void Start()
    {
        gameEvents = GameEvents.instance;
    }

    public void Interact(GameObject gameObject)
    {
        gameEvents.GameOver?.Invoke();
    }
}
