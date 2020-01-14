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

    private float cooldownTimer = -1;

    public void Fire(Transform position, float rotation)
    {
        if (cooldownTimer < Time.time)
        {
            baseBullet on = Instantiate(bulletToSpawn, position.position, Quaternion.AngleAxis(rotation, Vector3.forward));
            on.ShootForward();

            cooldownTimer = coolDownTime;
            Debug.Log("Fired gun");
            cooldownTimer = Time.time + coolDownTime;
        }
        else
        {
            Debug.Log("Gun on cooldown");
        }
    }
}