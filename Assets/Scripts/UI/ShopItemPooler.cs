using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItemPooler : MonoBehaviour
{
    [SerializeField]
    private float amount;
    [SerializeField]
    private baseBullet _gmob;
    private List<baseBullet> pooledProjectiles;

    public static ShopItemPooler _pooler;

 
    // Start is called before the first frame update
    void Awake()
    {
        _pooler = this;
    }

    private void Start()
    {
        setupObjects();
    }

    /// <summary>
    /// Setup projectile objects:
    /// </summary
    void setupObjects()
    {
        for (int x = 0; x < amount; x++)
        {
            baseBullet _instob = Instantiate(_gmob);
            pooledProjectiles.Add(_instob);
            _instob.gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// returns a instance of pooled projectile object
    /// </summary>
    public baseBullet getpooledObject()
    {
        foreach (baseBullet projectileInstance in pooledProjectiles)
        {
            if (!projectileInstance.gameObject.activeInHierarchy)
            {
                //projectileInstance.SetActive(true);
                return projectileInstance;
            }
        }
        return null;
    }


}
