using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    public Sprite fallenSprite;

    public void OnTriggerEnter2D(Collider2D collision) {
        StartCoroutine(waitForSeconds());
    }

    IEnumerator waitForSeconds(){
        yield return new WaitForSeconds(0.1f);

        foreach (PolygonCollider2D collider in GetComponents<PolygonCollider2D>())
        {
            collider.enabled = false;
        }

        GetComponent<SpriteRenderer>().sprite = fallenSprite;
    }
}
