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

    Sprite frontMask, backMask, sideMask;
    baseBullet bulletToSpawn;

    [SerializeField]
    public float coolDownTime = 0.2f;
    private float cooldownTimer = 0;

    public void Fire(Vector3 position, float rotation)
    {
        if (cooldownTimer < Time.time)
        {
            Instantiate(bulletToSpawn, position, Quaternion.AngleAxis(rotation, Vector3.forward));
            cooldownTimer = Time.time + coolDownTime;
            Debug.Log("Fired gun");
        }
        else
        {
            Debug.Log("Tried to fire");
        }
    }
          
}