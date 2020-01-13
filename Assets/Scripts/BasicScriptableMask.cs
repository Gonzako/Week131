/*
 *
 * Copyright (c) Gonzako
 * Gonzako123@gmail.com
 *
 */
 
using UnityEngine;
 

[CreateAssetMenu(menuName = "Gameplay/SimpleMask")]
public class BasicScriptableMask : ScriptableObject
{
    [SerializeField]
    public Sprite frontMask, backMask, sideMask; //TODO: might want to look into making an editor script for these
    [SerializeField]
    public baseBullet bulletToSpawn;

    #region TimerValues
    [SerializeField]
    private float coolDownTime = 0.2f;
    private float cooldownTimer = 0; 
    #endregion

    public void Fire(Vector3 position, float rotation)
    {
        if (cooldownTimer < Time.time) //Timer Check
        {
            baseBullet on = Instantiate(bulletToSpawn, position, Quaternion.AngleAxis(rotation, Vector3.forward));
            on.GetComponent<Rigidbody2D>().AddForce(position * 5F, ForceMode2D.Impulse);
            cooldownTimer = Time.time + coolDownTime; //Timer reset

            Debug.Log("Fired gun");
        }
        else
        {
            Debug.Log("Tried to fire");
        }
    }
          
}