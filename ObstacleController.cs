using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            transform.position - Vector3.forward,
            Mathf.Round(PlayerController.speed) * Time.deltaTime
        );

        if(transform.position.z < -49f)
        {
            if(transform.childCount >= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
