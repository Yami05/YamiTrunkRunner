using UnityEngine;

public class FinishLine : MonoBehaviour, IInteract
{
    private GameEvents gameEvents;


    private void Start()
    {
        gameEvents = GameEvents.instance;
    }

    public void Interact(GameObject gameObject)
    {
        Debug.Log("WEin");
        gameEvents.Win?.Invoke();

    }
}
