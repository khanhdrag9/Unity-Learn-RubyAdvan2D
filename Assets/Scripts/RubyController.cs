using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    public int maxHealth = 5;
    public float timeInvincible = 2f;
    public float speed = 7;

    Rigidbody2D rigidBody;
    public int currentHealth{get; private set;}
    bool isInvincible;
    float invincibleTimer;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        isInvincible = false;
        invincibleTimer = 0;
    }

    void Update()
    {
        //Horizontal
        float horizontal = Input.GetAxis("Horizontal");
        float x = transform.position.x + speed * horizontal * Time.deltaTime;

        //Verticale
        float vertical = Input.GetAxis("Vertical");
        float y = transform.position.y + speed * vertical * Time.deltaTime;

        // transform.position = new Vector2(x, y);
        rigidBody.MovePosition(new Vector2(x, y));

        if(isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if(invincibleTimer < 0)isInvincible = false;
        }
    }

    public void ChangeHealth(int amount)
    {
        if(amount < 0)
        {
            if(isInvincible)return;

            isInvincible = true;
            invincibleTimer = timeInvincible;
        }
        currentHealth = Mathf.Clamp(currentHealth + amount, 0 , maxHealth);
        Debug.Log($"HP: {currentHealth}/{maxHealth}");
    }
}
