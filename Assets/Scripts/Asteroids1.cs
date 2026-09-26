using UnityEngine;

public class Asterroids1 : MonoBehaviour
{
    public Transform targetPosition;
    private Vector3 startPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, 2 * Time.deltaTime);
        if (transform.position == targetPosition.position)
        {
            transform.position = startPosition;
        }
    }
}
