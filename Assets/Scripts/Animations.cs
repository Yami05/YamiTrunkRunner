using UnityEngine;

public class Animations : MonoBehaviour
{
    [SerializeField] private Animator anim;

    private GameEvents gameEvents;

    private void Start()
    {
        gameEvents = GameEvents.instance;
        gameEvents.Start += () => anim.SetBool(Utilities.isRun, true);
        gameEvents.GameOver += () => anim.SetBool(Utilities.isOver, true);
        gameEvents.Win += () => anim.SetBool(Utilities.isFinished, true);
    }
}
