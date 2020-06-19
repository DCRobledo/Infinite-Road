using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMe : MonoBehaviour
{
    public GameObject carObj;

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.y < carObj.transform.position.y - 10)
            Destroy(this.gameObject);
    }
}
