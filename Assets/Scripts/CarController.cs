using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    Rigidbody2D rb;

    public float speed = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(new Vector2(0, 0.5f));
        CheckInput();
    }

    private void CheckInput()
    {
        if (Input.GetKey(KeyCode.W))
            rb.AddForce(new Vector2(0, 1 * speed));

        if (Input.GetKey(KeyCode.A))
            rb.AddForce(new Vector2(-1 * speed, 0));

        if (Input.GetKey(KeyCode.D))
            rb.AddForce(new Vector2(1 * speed, 0));
    }
}
