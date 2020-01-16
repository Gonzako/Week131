using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GonzakoUtils.DataStructures;

[CreateAssetMenu(menuName = "Gameplay/Huba Mask")]
public class HubaMask : BasicScriptableMask
{

    [SerializeField]
    private float coolDownTime = 0.2f;


    private float cooldownTimer = -1;
    private Pool<GameObject> pool;

    public override GameObject Fire(Transform position, float rotation)
    {
        if (cooldownTimer < Time.time)
        {

            baseBullet on = pool.getNextObj().GetComponent<baseBullet>();
            on.transform.position = position.position;
            on.onThisDisable += poolBullet;
            on.transform.rotation = Quaternion.AngleAxis(rotation, Vector3.forward);
            on.gameObject.SetActive(true);
            on.ShootForward();

            cooldownTimer = coolDownTime;
            Debug.Log("Fired gun");
            cooldownTimer = Time.time + coolDownTime;
            return on.gameObject;
        }
        else
        {

            Debug.Log("Gun on cooldown");
            return null;
        }
    }
}
