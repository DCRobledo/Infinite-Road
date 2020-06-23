using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailureObject : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider) {
        GameObject go = GameObject.FindGameObjectWithTag("UI");
        go.GetComponent<UIController>().livesLeft--;
    }
}
