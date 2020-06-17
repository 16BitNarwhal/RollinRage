using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralManager : MonoBehaviour
{
    public float score;
    public GameObject coin;
    public GameObject barrel;

    private float coinTime = 0f;
    private float barrelTime = 0f;
    
    void Start() {
        score = 0f;
    }

    void Update() {
        coinTime -= Time.deltaTime;
        barrelTime -= Time.deltaTime;
        if (coinTime <= 0) {
            Instantiate(coin, new Vector3(0, 0, 0), Quaternion.identity);
            coinTime = Random.Range(5f, 10f);
        }
        if (barrelTime <= 0) {
            Instantiate(barrel, new Vector3(0, 0, 0), Quaternion.identity);
            barrelTime = Random.Range(1f, 3f);
        }
    }
}
