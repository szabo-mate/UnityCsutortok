using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPools : MonoBehaviour
{

    public static ObjectPools Instance { get; set; } 

    public CoinController Coin;
    private Queue<CoinController> Items = new Queue<CoinController>();

    private void Awake()
    {
        Instance = this;
    }

    public CoinController Get()
    {
        if (Items.Count == 0)
        {
            CoinController obstacle = Instantiate(Coin);
            obstacle.gameObject.SetActive(false);
            Items.Enqueue(obstacle);
        }
        return Items.Dequeue();
    }

    public void ReturnToPool(CoinController obj)
    {
        obj.gameObject.SetActive(false);
        Items.Enqueue(obj);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
