using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneralManager : MonoBehaviour
{
    public int score;
    public GameObject coin;
    public GameObject barrel;
    public Text scoreText;
    public Text gameOverScore;
    public float barrelSpeedMulti = 1f;
    public int coins = 0;

    private float coinTime = 0f;
    private float barrelTime = 0f;
    private float barrelTimeMulti = 1f;
    
    void Start() {
        score = 0;
    }

    void Update() {
        coinTime -= Time.deltaTime;
        barrelTime -= Time.deltaTime;
        scoreText.text = score.ToString();
        if (coinTime <= 0 && coins < 3) {
            Instantiate(coin, new Vector3(0, 0, 0), Quaternion.identity);
            coinTime = Random.Range(2f, 4f);
            coins++;
        }
        if (barrelTime <= 0) {
            GameObject b = Instantiate(barrel, new Vector3(0, 0, 0), Quaternion.identity);
            barrelTime = Random.Range(1f, 3f) / barrelTimeMulti;
            b.GetComponent<Barrel>().moveSpeed *= barrelSpeedMulti;
            if (barrelTimeMulti < 4.4f)
                barrelTimeMulti += 0.035f;
            if (barrelSpeedMulti < 3.3f)
                barrelSpeedMulti += 0.035f;
        }
    }

    public void GameOver() {
        gameOverScore.text = score.ToString();
        
        gameObject.SetActive(false);
    }
}
