using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePointer : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("ScoreAdd");
        }
    }
}
