using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GonzakoUtils.DataStructures;

public class Spawner : MonoBehaviour
{

    [SerializeField] private AIManager _defaultData;
    private GameManager _gsm;


    //Ball needs to be gameobject prefab with defined class type:
    [SerializeField] Pool<AIManager> _npcPool;



    private void Awake()
    {
        _npcPool = new Pool<AIManager>(0, _defaultData);
    }

    [Range(0.0F, 500F)]
    [SerializeField] private float _spawnRadius;

   

    private void OnEnable()
    {
        _gsm = FindObjectOfType<GameManager>();
        Mortal.onAnyNpcDead += onAIDestroyed;

        _gsm.onShouldSpawnEnemies += SpawnRandomly;
        
    }

    private void OnDisable()
    {
        Mortal.onAnyNpcDead -= onAIDestroyed;
        _gsm.onShouldSpawnEnemies -= SpawnRandomly;
    }

    private void onAIDestroyed(Mortal ai)
    {
        _npcPool.enPool(ai.GetComponent<AIManager>());
        ai.gameObject.SetActive(false);
    }

  
    private void SpawnRandomly(int amount)
    {

            for (int i = 0; i < amount; i++)
            {

                AIManager b = _npcPool.getNextObj();
                b.transform.position = new Vector2(Random.Range(transform.position.x, _spawnRadius),
                    Random.Range(transform.position.y, _spawnRadius));
                b.gameObject.SetActive(true);
            }
        }
        

    }

