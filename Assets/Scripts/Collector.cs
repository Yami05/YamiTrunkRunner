using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField] private GameObject torus;

    private void Start()
    {
        //trunk = transform.parent.GetChild(1).gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<IInteract>()?.Interact(torus);
    }
}
