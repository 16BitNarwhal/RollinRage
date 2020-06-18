using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip barrelSound;
    public AudioClip coinSound;
    public AudioClip healSound;
    public AudioClip deathSound;

    public AudioSource source;

    void Start() {
        source = GetComponent<AudioSource>();
    }

    public void BarrelSound() {
        source.PlayOneShot(barrelSound, 0.8f);
    }

    public void CoinSound() {
        source.PlayOneShot(coinSound, 0.8f);
    }

    public void HealSound() {
        source.PlayOneShot(healSound, 0.8f);
    }

    public void DeathSound() {
        source.PlayOneShot(deathSound, 0.8f);
    }
}
