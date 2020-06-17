using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    private Animator anim;
    private float moveSpeed;
    private int dir;
    void Awake() {
        anim = GetComponent<Animator>();
        dir = Random.Range(0, 4);
        moveSpeed = Random.Range(5f, 10f);
        if (dir == 0) {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
            transform.position = new Vector3(-40, Random.Range(-1, 2) * 5, transform.position.z);
        } else if (dir == 1) {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 90);
            transform.position = new Vector3(Random.Range(-4, 5) * 5, -20, transform.position.z);
        } else if (dir == 2) {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 180);
            transform.position = new Vector3(40, Random.Range(-1,2) * 5, transform.position.z);
        } else if (dir == 3) {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 270);
            transform.position = new Vector3(Random.Range(-4, 5) * 5, 20, transform.position.z);
        }
        
    }

    void Update() {
        transform.position += transform.right * moveSpeed * Time.deltaTime;
        if (transform.position.x > 40 || transform.position.x < -40 || transform.position.y > 20 || transform.position.y < -20)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Player") {
            anim.SetBool("explode", true);
            moveSpeed /= 1.5f;
        }
    }

    private void Die() {
        Destroy(gameObject);
    }
}
