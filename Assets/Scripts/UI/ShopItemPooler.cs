using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItemPooler : MonoBehaviour
{
    [SerializeField]
    private float amount;
    [SerializeField]
    private GameObject _gmob;
    private List<GameObject> pooledProjectiles;

    public static ShopItemPooler _pooler;

    private void Awake()
    {

        _pooler = this;
        pooledProjectiles = new List<GameObject>();
        setupObjects();

    }
    // Start is called before the first frame update
    void Start()
    {
      
    }

    /// <summary>
    /// Setup projectile objects:
    /// </summary
    void setupObjects()
    {
        for (int x = 0; x < amount; x++)
        {
            GameObject _instob = Instantiate(_gmob);
            _instob.transform.SetParent(transform);
            pooledProjectiles.Add(_instob);
            _instob.SetActive(false);
        }
    }

    /// <summary>
    /// returns a instance of pooled projectile object
    /// </summary>
    public GameObject getpooledObject()
    {
        foreach (GameObject projectileInstance in pooledProjectiles)
        {
            if (!projectileInstance.activeInHierarchy)
            {
                //projectileInstance.SetActive(true);
                return projectileInstance;
            }
        }
        return null;
    }


}
