using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FailureObject : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider) {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
