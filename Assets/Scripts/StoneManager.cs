using UnityEngine;

public class StoneManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IObstacle>(out var obstacle))
        {
            obstacle.Obstacle(gameObject);
        }
    }
}
