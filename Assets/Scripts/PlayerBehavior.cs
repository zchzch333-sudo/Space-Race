using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerBehavior : MonoBehaviour
{
    private InputAction upButton;
    private InputAction downButton;

    AudioSource MyCdPlayer;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        upButton = InputSystem.actions.FindAction("up");
        downButton = InputSystem.actions.FindAction("down");

        MyCdPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPosition = transform.position;
        if (upButton.IsPressed())
        {
            playerPosition.y += 2 * Time.deltaTime;
            Debug.Log("Go up");
        }
        if (downButton.IsPressed())
        {
            playerPosition.y -= 2 * Time.deltaTime;
            Debug.Log("Go down");
        }
        transform.position = playerPosition;
    }
    void OnTriggerEnter(Collider other)
    {
        MyCdPlayer.Play();
        Debug.Log("Touched");
    }
}
