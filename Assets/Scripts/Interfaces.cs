using UnityEngine;

interface IInteract
{
    void Interact(GameObject gameObject);
}

interface IWave
{
    void Wave(GameObject go);
}

interface IObstacle
{
    void Obstacle(GameObject go);
}

public class Interfaces : MonoBehaviour
{
}
