using UnityEngine;

public class Player : MonoBehaviour
{
    public int health;
    public float moveSpeed;
    public float maxMoveSpeed;
    public Transform target;
    public GeneralManager generalManager;
    public GameObject damage;
    public Animator h1, h2, h3;
    public GameObject gameOver;
    public AudioManager audioManager;

    private Animator anim;
    private Vector2 input;
    private int lastCoins = 0;
    private float invincibility = 0f;

    void Start()
    {
        health = 3;
        anim = GetComponent<Animator>();
        transform.position = Vector2.zero;
    }
    
    void Update()
    {
        invincibility -= Time.deltaTime;
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

            if (target.position.x >= 20 || target.position.x <= -20 || target.position.y >= 15 || target.position.y <= -15)
                target.position = transform.position;
        }
        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Coin") {
            audioManager.CoinSound();
            generalManager.score += 1;
            generalManager.coins--;
            if (moveSpeed < maxMoveSpeed) {
                moveSpeed += 0.5f;
            }
            if (generalManager.score - lastCoins == 10) {
                if (health == 1 || health == 2) {
                    audioManager.HealSound();
                    health++;
                    UpdateHealth();
                }
                lastCoins = generalManager.score;
            }

        } else if (col.gameObject.tag == "Barrel" && invincibility <= 0f) {
            invincibility = 1f;
            audioManager.BarrelSound();
            damage.SetActive(true);
            health--;
            UpdateHealth();
            if (health <= 0)
                Die();
        }
    }
    
    private void UpdateHealth() {
        if (health == 3) {
            h1.SetBool("red", true);
            h2.SetBool("red", true);
            h3.SetBool("red", true);
        } else if (health == 2) {
            h1.SetBool("red", false);
            h2.SetBool("red", true);
            h3.SetBool("red", true);
        } else if (health == 1) {
            h1.SetBool("red", false);
            h2.SetBool("red", false);
            h3.SetBool("red", true);
        } else if (health ==0) {
            h1.SetBool("red", false);
            h2.SetBool("red", false);
            h3.SetBool("red", false);
        }
    }
    private void Die() {
        audioManager.DeathSound();
        gameOver.SetActive(true);
        generalManager.GameOver();
        audioManager.source.loop = false;
        gameObject.SetActive(false);
    }
}
