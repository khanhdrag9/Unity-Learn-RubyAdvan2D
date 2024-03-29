﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public bool isVertical;
    public float changeTime = 3f;
    public int damage = 1;

    Rigidbody2D body;
    Animator animator;
    float direction = 1;
    float timer;
    
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        timer = changeTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            direction *= -1;
            timer = changeTime;
        }

        Vector2 position = body.position;
        if(isVertical)
        {
            animator.SetFloat("MoveX", 0f);
            animator.SetFloat("MoveY", direction);
            position.y = position.y + Time.deltaTime * speed * direction;
        }
        else
        {
            animator.SetFloat("MoveX", direction);
            animator.SetFloat("MoveY", 0f);
            position.x = position.x + Time.deltaTime * speed * direction;
        }
        
        body.MovePosition(position);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        RubyController ruby = other.gameObject.GetComponent<RubyController >();
        if (ruby)
        {
            ruby.ChangeHealth(-damage);
        }
    }
}
