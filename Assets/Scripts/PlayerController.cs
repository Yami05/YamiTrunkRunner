using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Camera UIcam;
    [SerializeField] private float sens;
    [SerializeField] private float speed;

    private GameObject torus;
    private GameEvents gameEvents;
    private Rigidbody rb;

    private Vector3 firstClick;
    private Vector3 lastClick;
    private Vector3 diff;

    private bool canMove = false;

    private void Start()
    {
        gameEvents = GameEvents.instance;
        rb = GetComponent<Rigidbody>();
        torus = transform.GetChild(0).gameObject;

        gameEvents.Start += () => canMove = true;
        gameEvents.GameOver += () => { canMove = false; rb.isKinematic = true; };
        gameEvents.Win += () => { canMove = false; rb.isKinematic = true; };
        gameEvents.MouseUp += () => diff.x = 0; ;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnMouseClick();
            GameStarter();
        }
        if (Input.GetMouseButton(0))
        {
            OnDrag();
        }
        if (Input.GetMouseButtonUp(0))
        {
            MouseUp();
        }
        Clamp();
    }

    private void FixedUpdate()
    {
        CharacterMovement();
    }

    private void GameStarter()
    {
        gameEvents.Start?.Invoke();
    }

    private void OnMouseClick()
    {
        firstClick = UIcam.ScreenToWorldPoint(Input.mousePosition);
        lastClick = firstClick;
    }

    private void OnDrag()
    {
        lastClick = UIcam.ScreenToWorldPoint(Input.mousePosition);
        diff = lastClick - firstClick;
        diff *= sens;
    }

    private void MouseUp() => gameEvents.MouseUp?.Invoke();

    private void CharacterMovement()
    {
        if (canMove)
        {
            rb.velocity = Vector3.Lerp(rb.velocity, new Vector3(diff.x * 2, rb.velocity.y, speed), 0.4f);
        }
    }

    private void Clamp()
    {
        Vector3 playerPos = transform.position;
        transform.position = new Vector3(Mathf.Clamp(playerPos.x, -4, 4), playerPos.y, playerPos.z);
    }

    public Vector3 Diff() => diff;

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<IInteract>()?.Interact(torus);
    }
}
