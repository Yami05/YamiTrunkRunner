using UnityEngine;
using DG.Tweening;

public class ObstacleManager : MonoBehaviour, IObstacle, IInteract
{
    private ObjectPool objectPool;
    private Rigidbody rb;
    private GameEvents gameEvents;

    private void Start()
    {
        gameEvents = GameEvents.instance;
        objectPool = ObjectPool.instance;
    }

    public void Obstacle(GameObject go)
    {
        Transform obstacleParent = transform.parent;

        for (int i = 0; i < obstacleParent.childCount; i++)
        {
            GameObject a = obstacleParent.GetChild(i).gameObject;
            if (!a.GetComponent<Rigidbody>())
            {
                rb = a.AddComponent<Rigidbody>();
                rb.freezeRotation = true;
            }
        }

        objectPool.ReturnToPool(go, 0, 0);
        Destroy(gameObject);
        for (int i = 0; i < 3; i++)
        {
            GameObject diamond = objectPool.GetFromPool(PoolItems.diamond);
            diamond.transform.position = transform.position;
            Vector3 obstaclePos = transform.position;
            float a = (i % 2 == 1 ? +i : -i);
            diamond.transform.DOJump(new Vector3(obstaclePos.x + a, obstaclePos.y,
                obstaclePos.z + a), 1, 1, 1);
        }

        GameObject particle = objectPool.GetFromPool(PoolItems.GoldParticle);
        particle.transform.position = transform.position;
        objectPool.ReturnToPool(particle, PoolItems.GoldParticle, 1);
    }

    public void Interact(GameObject gameObject)
    {
        gameEvents.GameOver?.Invoke();
    }
}
