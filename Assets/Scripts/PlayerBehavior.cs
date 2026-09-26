using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerBehavior : MonoBehaviour
{
    private InputAction upButton;
    private InputAction downButton;
    private InputAction leftButton;
    private InputAction rightButton;
    private Vector3 startPosition;
    private Vector3 screenPosition;
    private float moveSpeed = 2;
    public GameObject powerup;

    AudioSource MyCdPlayer;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        upButton = InputSystem.actions.FindAction("up");
        downButton = InputSystem.actions.FindAction("down"); 
        leftButton = InputSystem.actions.FindAction("left");
        rightButton = InputSystem.actions.FindAction("right");

        MyCdPlayer = GetComponent<AudioSource>();
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 screenPosition = Camera.main.WorldToViewportPoint(transform.position);
        Vector3 playerPosition = transform.position;
        if (upButton.IsPressed() && screenPosition.y < 1)
        {
            playerPosition.y += moveSpeed * Time.deltaTime;
            Debug.Log("Go up");
        }
        if (downButton.IsPressed() && screenPosition.y > 0)
        {
            playerPosition.y -= moveSpeed * Time.deltaTime;
            Debug.Log("Go down");
        }
        if (leftButton.IsPressed() && screenPosition.x > 0)
        {
            playerPosition.x -= moveSpeed * Time.deltaTime;
            Debug.Log("Go left");
        }
        if (rightButton.IsPressed() && screenPosition.x < 1)
        {
            playerPosition.x += moveSpeed * Time.deltaTime;
            Debug.Log("Go right");
        }
        transform.position = playerPosition;
        if (screenPosition.y >= 1)
        {
            transform.position = startPosition;
            moveSpeed = 2;
            powerup.SetActive(true);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.name == "PowerUp")
        {
            moveSpeed = 4;
            powerup = other.gameObject;
            other.gameObject.SetActive(false);
        }
        else
        {
            MyCdPlayer.Play();
            transform.position = startPosition;
            Debug.Log("Touched");
            moveSpeed = 2;
            powerup.SetActive(true); 
        }
    }
}
