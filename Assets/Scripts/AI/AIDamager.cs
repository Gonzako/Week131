using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDamager : MonoBehaviour
{

    [SerializeField] private int _damage;
    [SerializeField] private float forceMultiplier = 10;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            IMortal m = collision.transform.GetComponent<IMortal>();
            collision.otherRigidbody.AddForce(collision.
                GetContact(0).normal * _damage * forceMultiplier, ForceMode2D.Impulse);
            collision.rigidbody.AddForce(collision.GetContact(0).normal *
                _damage * forceMultiplier, ForceMode2D.Impulse);
            Damage(m);
        }
    }


    private void Damage(IMortal mortal)
    {
        mortal.Damage(_damage);
    }
}
