using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHitAudio : MonoBehaviour
{
    public AudioClip objectHit;

    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<AudioController>().PlayAudio(objectHit);
    }
}
