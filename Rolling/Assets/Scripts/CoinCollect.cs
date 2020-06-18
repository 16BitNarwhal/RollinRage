using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    public GameObject ps;

    void Start() {
        transform.position = new Vector3(Random.Range(-3, 4),Random.Range(-2, 3),0) * 5;
    }

    void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.tag == "Player") {
            Instantiate(ps, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

}
