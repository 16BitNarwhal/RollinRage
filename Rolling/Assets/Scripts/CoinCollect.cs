using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    public GeneralManager generalManager;

    void Start() {
        transform.position = new Vector3(Random.Range(-5, 5),Random.Range(-1, 1),0) * 5;
    }

    void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.tag == "Player") {
            generalManager.score += 1;
            Destroy(gameObject);
        }
    }
}
