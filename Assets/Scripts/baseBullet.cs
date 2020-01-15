/*
 *
 * Copyright (c) Gonzako
 * Gonzako123@gmail.com
 *
 */
 
using UnityEngine;
 
public class baseBullet : MonoBehaviour
{
    #region Public Fields
    [SerializeField]
    private float Speed = 4;
    [SerializeField]private int _damage = 1;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hit" + collision.transform.tag);
        IMortal t = collision.gameObject.GetComponent<IMortal>();
        if(t != null)
         t.Damage(_damage);

        
    }

   

    #endregion
#endif

}