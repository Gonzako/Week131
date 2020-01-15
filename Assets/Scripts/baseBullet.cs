/*
 *
 * Copyright (c) Gonzako
 * Gonzako123@gmail.com
 *
 */

using System;
using UnityEngine;
 
public class baseBullet : MonoBehaviour
{
    #region Public Fields
    [SerializeField]
    private float Speed = 4;

    [SerializeField] private int _damage = 35;

    public event Action<GameObject> onThisDisable;
    #endregion
 
    #region Private Fields
    #endregion

    #region Public Methods
    public void ShootForward()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.right * Speed, ForceMode2D.Impulse);
    }
    #endregion

    #region Private Methods
    #endregion


    #if true
    #region Unity API

    void Start()
    {
    }
 
    void FixedUpdate()
    {
    }

    private void OnDisable()
    {
        onThisDisable?.Invoke(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "NPC")
        {
            IMortal m = collision.transform.GetComponent<IMortal>();
            m.Damage(_damage);
            this.gameObject.SetActive(false);
        }
    }
    #endregion
#endif

}