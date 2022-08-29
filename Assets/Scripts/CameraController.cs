using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;

    private void FixedUpdate()
    {
        Vector3 desiderPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiderPos, 0.2f);
    }
}
