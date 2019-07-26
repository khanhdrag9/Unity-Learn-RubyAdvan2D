using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    public int damage = 1;
    void OnTriggerEnter2D(Collider2D collider)
    {
    }
    void OnTriggerStay2D(Collider2D collider)
    {
        Trigger(collider.gameObject);
    }

    void Trigger(GameObject other)
    {
        RubyController ruby = other.GetComponent<RubyController>();
        if(ruby)
        {
            ruby.ChangeHealth(-damage);
        }
    }
}
