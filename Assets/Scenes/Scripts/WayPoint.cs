using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    public static Transform[] wayPoint;

    private void Awake()
    {
        wayPoint = new Transform[GameObject.Find("WayPoint").transform.childCount];

        for (int i = 0; i < wayPoint.Length; i++)
        {
            wayPoint[i] = GameObject.Find("WayPoint").transform.GetChild(i);

        }
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
