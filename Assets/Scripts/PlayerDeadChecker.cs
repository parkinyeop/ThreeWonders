using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadChecker : MonoBehaviour
{
    public ParticleSystem dieEffects;
    GameObject dieEffectObj;

    private void Awake()
    {
        dieEffects = GetComponent<ParticleSystem>();
        dieEffectObj = transform.GetChild(0).gameObject;
    }
    private void Start()
    {
        dieEffectObj.SetActive(false);
        RunPlayerController player = FindObjectOfType<RunPlayerController>();
        player.PlayerDie += Die;

    }

    private void Die()
    {
        dieEffectObj.SetActive(true);
        dieEffects.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Block"))
        {
            Die();
        }

        dieEffects.Stop();
    }

    
}
