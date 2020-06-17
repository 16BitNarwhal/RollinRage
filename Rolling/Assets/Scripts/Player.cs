using UnityEngine;

public class Player : MonoBehaviour
{
    public int health;
    public float moveSpeed;
    public Transform target;
    public GeneralManager generalManager;

    public Animator h1, h2, h3;

    private Animator anim;
    private Vector2 input;

    void Start()
    {
        health = 3;
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

            if (target.position.x >= 30 || target.position.x <= -30 || target.position.y >= 10 || target.position.y <= -10)
                target.position = transform.position;
        }
        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Coin") {
            generalManager.score += 1;
        } else if (col.gameObject.tag == "Barrel") {
            health -= 1;
            if (health == 2) h1.SetBool("red", false);
            else if (health == 1) h2.SetBool("red", false);
            else if (health == 0) h3.SetBool("red", false);
            if (health <= 0)
                Die();
        }
    }

    private void Die() {
        Debug.Log("dead");
    }
}
