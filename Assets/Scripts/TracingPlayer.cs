using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TracingPlayer : MonoBehaviour
{
    public Transform player;
    private Vector3 startPosition;
    private Vector3 screenPosition;
    private bool following = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) < 3)
        {
            following = true;
            transform.position = Vector3.MoveTowards(transform.position, player.position, 2 * Time.deltaTime);
        }
        if (following == true && Vector3.Distance(transform.position, player.position) > 4)
        {
            following = false;
            Vector3 randomPosition = new Vector3(Random.Range(0f, 1f), Random.Range(0f, 1f), Camera.main.WorldToScreenPoint(transform.position).z);
            transform.position = Camera.main.ViewportToWorldPoint(randomPosition);
        }
        if (Camera.main.WorldToViewportPoint(player.position).y >= 1)
        {
            following = false;
            Vector3 randomPosition = new Vector3(Random.Range(0f, 1f), Random.Range(0f, 1f), Camera.main.WorldToScreenPoint(transform.position).z);
            transform.position = Camera.main.ViewportToWorldPoint(randomPosition);
        }
    }
}