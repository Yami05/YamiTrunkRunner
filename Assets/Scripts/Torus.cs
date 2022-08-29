using System.Collections;
using UnityEngine;
using DG.Tweening;

public class Torus : MonoBehaviour, IWave
{
    private GameEvents gameEvents;
    private ObjectPool objectPool;

    private int layer_mask;

    private bool youCanShoot;
    private void Start()
    {
        gameEvents = GameEvents.instance;
        objectPool = ObjectPool.instance;

        layer_mask = LayerMask.GetMask("Obstacle");

        StartCoroutine(ShootTime());
    }

    public void Wave(GameObject go)
    {
        gameEvents.SuckIn?.Invoke();
        Destroy(go);
    }
    private void Update()
    {
        DetectShoot();
    }

    private void DetectShoot()
    {
        RaycastHit hit;

        youCanShoot = Physics.Raycast(transform.position, transform.forward, out hit, 53, layer_mask);
        if (youCanShoot && !hit.transform.GetComponent<Rigidbody>())
        {
            hit.transform.gameObject.AddComponent<Rigidbody>();
        }
    }

    IEnumerator ShootTime()
    {
        while (true)
        {
            if (youCanShoot)
            {

                GameObject stone = objectPool.GetFromPool(PoolItems.stone);
                stone.transform.position = transform.position;
                stone.transform.DOMoveZ(transform.position.z + 100, 2.5f);

                if (stone.activeInHierarchy)
                {
                    objectPool.ReturnToPool(stone, PoolItems.stone, 2);
                }
                if (!stone.GetComponent<StoneManager>())
                    stone.AddComponent<StoneManager>();

                yield return new WaitForSeconds(0.4f);

            }
            else
            {
                yield return null;
            }
        }
    }
}
