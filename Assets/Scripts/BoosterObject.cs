using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterObject : MonoBehaviour
{
    public float speedMultiplier;
    public float boostTime = 1f;

    private GameObject carObj;

    private void OnTriggerEnter2D(Collider2D collider) {
        carObj = GameObject.FindGameObjectWithTag("Car");

        StartCoroutine(boostSpeed());
    }

    IEnumerator boostSpeed(){
        float oldSpeed = 5f;
        carObj.GetComponent<CarController>().speed = oldSpeed * speedMultiplier;
        
        yield return new WaitForSeconds(boostTime);

        carObj.GetComponent<CarController>().speed = oldSpeed;
    }
}
