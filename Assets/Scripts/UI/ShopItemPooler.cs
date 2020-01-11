using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItemPooler : MonoBehaviour
{
    [SerializeField] int _amount;
    [SerializeField] GameObject _poolableItem;

    public List<GameObject> _pooledObjects;

    private Transform _transform;

    public static ShopItemPooler _instance;
    // Start is called before the first frame update

    private void Awake()
    {
        if (_instance != this)
        {
            _instance = this;
        }
    }

    void Start()
    {
        _transform = GetComponent<Transform>();
        _pooledObjects = new List<GameObject>();
        InstantiateObjectsIn();
    }

    private void InstantiateObjectsIn()
    {
        for(int i = 0; i < _amount; i++)
        {
            GameObject inst = Instantiate(_poolableItem);
            inst.transform.parent = _transform;
            inst.SetActive(false);
            _pooledObjects.Add(inst);
        }
    }

    public GameObject GetPooledObject()
    {
        foreach(GameObject ob in _pooledObjects)
        {
            if (!ob.activeSelf)
            {
                return ob;
            }
        }
        return null;
    }


}
