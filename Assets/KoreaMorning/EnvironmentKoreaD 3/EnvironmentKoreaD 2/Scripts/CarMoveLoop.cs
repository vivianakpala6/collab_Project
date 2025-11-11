using UnityEngine;

public class CarMoveLoop : MonoBehaviour
{
    public float moveDistance = 10f;  
    public float moveSpeed = 5f;       
    private Vector3 startPosition;    
    private Vector3 targetPosition;
    private bool movingForward = true; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = transform.position;
        targetPosition = startPosition + transform.right * moveDistance;
    }

    // Update is called once per frame
    void Update()
    {
        MoveCar();
    }

     void MoveCar()
    {
        // Move forward or backward depending on the current direction
        if (movingForward)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, targetPosition) < 0.001f)
            {
                movingForward = false; // Switch direction when reaching forward point
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPosition, moveSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, startPosition) < 0.001f)
            {
                movingForward = true; // Switch direction when returning
            }
        }
    }
}

