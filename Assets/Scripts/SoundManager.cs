using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public static SoundManager instance;

    [SerializeField]
    private AudioSource soundFX;
    [SerializeField]
    private AudioClip enemyKillingClip, playerShootingClip, enemyMissingClip;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void PlayerShootingSound()
    {
        soundFX.clip = playerShootingClip;
        soundFX.Play();
    }

    public void EnemyKillingSound()
    {
        soundFX.clip = enemyKillingClip;
        soundFX.Play();
    }

    public void EnemyMissingSound()
    {
        soundFX.clip = enemyMissingClip;
        soundFX.Play();
    }
}
