/*
 *
 * Copyright (c) Gonzako
 * Gonzako123@gmail.com
 *
 */

using UnityEngine;
using GonzakoUtils.DataStructures;

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
    private Pool<GameObject> pool;

    public GameObject Fire(Transform position, float rotation)
    {
        if (cooldownTimer < Time.time)
        {
            baseBullet on = pool.getNextObj().GetComponent<baseBullet>();
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

    public void prepareData()
    {
        int starterPool = (int)(10 / (coolDownTime+0.1f));
        pool = new Pool<GameObject>(starterPool, bulletToSpawn.gameObject);
        cooldownTimer = 0;
    }

    public void disposeData()
    {
        var allGO = pool.getAllpooledItems();
        foreach(GameObject n in allGO)
        {
            Destroy(n);
        }
    }

    public void poolBullet(GameObject bulletToPool) { pool.enPool(bulletToPool); bulletToPool.GetComponent<baseBullet>().onThisDisable -= poolBullet; }
}