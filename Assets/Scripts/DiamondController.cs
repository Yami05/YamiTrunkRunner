using UnityEngine;

public class DiamondController : MonoBehaviour, IInteract
{
    private Vector3 desiredPos;

    private bool goIn;
    private GameObject goo;

    public void Interact(GameObject go)
    {
        goo = go;
        goIn = true;
    }

    private void FixedUpdate()
    {
        if (goIn)
        {
            transform.position = Vector3.Lerp(transform.position, goo.transform.position + new Vector3(0, 0, 0.7f), 0.2f);

            if (gameObject.activeInHierarchy)
            {
                //Destroy(gameObject, 0.3f);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<IWave>()?.Wave(gameObject);
    }
}
