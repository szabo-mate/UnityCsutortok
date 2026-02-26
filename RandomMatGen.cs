using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMatGen : MonoBehaviour
{
    public GameObject[] obstacles;

    // Start is called before the first frame update
    void Start()
    {
        List<Color> colors = new List<Color> { Color.red, Color.blue, Color.cyan, Color.green };

        obstacles = new GameObject[colors.Count];

        for (int i = 0; i < colors.Count; i++)
        {
            obstacles[i] = transform.GetChild(i).gameObject;
        }

        foreach (GameObject obs in obstacles)
        {
            Color randomColor = colors[Random.Range(0, colors.Count)];
            obs.GetComponent<Renderer>().material.color = randomColor;
            colors.Remove(randomColor);
        }

        if (transform.name.Equals("Player"))
        {
            Color randomColor = colors[Random.Range(0, colors.Count)];
            GetComponent<Renderer>().material.color = randomColor;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
