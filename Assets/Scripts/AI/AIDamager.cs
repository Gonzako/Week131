using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDamager : MonoBehaviour
{

    [SerializeField] private int _damage;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            IMortal m = collision.transform.GetComponent<IMortal>();
            Damage(m);
        }
    }


    private void Damage(IMortal mortal)
    {
        mortal.Damage(_damage);
    }
}
