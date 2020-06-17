using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public Transform target;
    
    private Animator anim;
    private Vector2 input;

    void Start()
    {
        anim = GetComponent<Animator>();
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

        if (transform.position == target.position) {
            anim.SetBool("IsWalk", false);
            if (input.x != 0) {
                anim.SetFloat("LastInputX", input.x);
                anim.SetFloat("LastInputY", 0);
                anim.SetBool("IsWalk", true);
            } else if (input.y != 0) {
                anim.SetFloat("LastInputX", 0);
                anim.SetFloat("LastInputY", input.y);
                anim.SetBool("IsWalk", true);
            }
            if (input.x < 0) target.position = transform.position + Vector3.left*5;
            else if(input.x > 0) target.position = transform.position + Vector3.right*5;
            else if(input.y < 0) target.position = transform.position + Vector3.down*5;
            else if(input.y > 0) target.position = transform.position + Vector3.up*5;
        }
        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
    }
}
