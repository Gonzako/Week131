using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GonzakoUtils.DataStructures;

public class Spawner : MonoBehaviour
{

    [SerializeField] private AIManager _defaultData;
    private GameStateManager _gsm;
    

    //Ball needs to be gameobject prefab with defined class type:
    [SerializeField] Pool<AIManager> _npcPool = new Pool<AIManager>(30);



    [Range(0.0F, 500F)]
    [SerializeField] private float _spawnRadius;

   

    private void OnEnable()
    {
        _gsm = FindObjectOfType<GameStateManager>();
        Mortal.onAnyNpcDead += onAIDestroyed;

        _gsm.onStateChanged += SpawnRandomly;
        
    }

    private void OnDisable()
    {
        Mortal.onAnyNpcDead -= onAIDestroyed;
    }

    private void onAIDestroyed(Mortal ai)
    {
        _npcPool.enPool(ai.GetComponent<AIManager>());
        ai.gameObject.SetActive(false);
    }

  
    private void SpawnRandomly(GameState state)
    {
        if(state.GetType() == typeof(WaveState))
        {
            for (int i = 0; i < state._GameManager._currentWave * 2; i++)
            {

                AIManager b = _npcPool.getNextObj();
                b.transform.position = new Vector2(Random.Range(transform.position.x, _spawnRadius),
                    Random.Range(transform.position.y, _spawnRadius));
            }
        }
        

    }
}
