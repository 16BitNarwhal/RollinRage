using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public Transform target;

    private Vector2 input;

    void Start()
    {
        transform.position = Vector2.zero;
    }
    
    void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        if(transform.position == target.position)
        {
            if(input.x < 0) target.position = transform.position + Vector3.left;
            else if(input.x > 0) target.position = transform.position + Vector3.right;
            else if(input.y < 0) target.position = transform.position + Vector3.down;
            else if(input.y > 0) target.position = transform.position + Vector3.up;
        }
        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
    }
}
