using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    public static Transform[] wayPoint;

    private void Awake()
    {
        wayPoint = new Transform[transform.childCount];

        for (int i = 0; i < wayPoint.Length; i++)
        {
            wayPoint[i] = transform.GetChild(i);
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
