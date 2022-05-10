using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L4WayPoint : MonoBehaviour
{
    public static Transform[] L4wayPoint;
    public static Transform[] L4wayPoint1;
    public static Transform[] L4wayPoint2;
    public static Transform[] L4wayPoint3;
    public static Transform[] L4wayPoint4;
    public static Transform[] L4wayPoint5;
    public static Transform[] L4wayPoint6;

    private void Awake()
    {
        //wayPoint = new Transform[GameObject.Find("wayPoint").transform.childCount];
        L4wayPoint = new Transform[transform.childCount];
        L4wayPoint1 = new Transform[transform.childCount];
        L4wayPoint2 = new Transform[transform.childCount];
        L4wayPoint3 = new Transform[transform.childCount];
        L4wayPoint4 = new Transform[transform.childCount];
        L4wayPoint5 = new Transform[transform.childCount];
        L4wayPoint6 = new Transform[transform.childCount];

        for (int i = 0; i < L4wayPoint.Length; i++)
        {
            L4wayPoint[i] = GameObject.Find("L4WayPoint").transform.GetChild(i);
            L4wayPoint1[i] = GameObject.Find("L4WayPoint1").transform.GetChild(i);
            L4wayPoint2[i] = GameObject.Find("L4WayPoint2").transform.GetChild(i);
            L4wayPoint3[i] = GameObject.Find("L4WayPoint3").transform.GetChild(i);
            L4wayPoint4[i] = GameObject.Find("L4WayPoint4").transform.GetChild(i);
            L4wayPoint5[i] = GameObject.Find("L4WayPoint5").transform.GetChild(i);
            L4wayPoint6[i] = GameObject.Find("L4WayPoint6").transform.GetChild(i);
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
