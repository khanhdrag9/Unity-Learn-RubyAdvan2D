using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    public Vector2 speed;
    Rigidbody2D rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Horizontal
        float horizontal = Input.GetAxis("Horizontal");
        float x = transform.position.x + speed.x * horizontal * Time.deltaTime;

        //Verticale
        float vertical = Input.GetAxis("Vertical");
        float y = transform.position.y + speed.y * vertical * Time.deltaTime;

        // transform.position = new Vector2(x, y);
        rigidBody.MovePosition(new Vector2(x, y));
    }
}
