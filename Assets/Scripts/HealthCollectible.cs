using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    public int healthChange = 1;
    void OnTriggerEnter2D(Collider2D collider)
    {
        RubyController ruby = collider.GetComponent<RubyController>();
        if(ruby)
        {
            if(ruby.currentHealth < ruby.maxHealth)
            {
                ruby.ChangeHealth(healthChange);
                Destroy(gameObject);
            }
        }
    }
}
