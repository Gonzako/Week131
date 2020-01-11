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

    [SerializeField]
    private float coolDownTime = 0.2f;
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