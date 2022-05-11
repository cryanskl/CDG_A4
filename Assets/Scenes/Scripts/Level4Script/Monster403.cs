using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster403 : MonoBehaviour
{
    private Transform[] positions3;

    public int index = 0;
    public float speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        positions3 = L4WayPoint.L4wayPoint3;
    }

    // Update is called once per frame
    void Update()
    {
        Moving();
    }

    void Moving()
    {
        transform.Translate((positions3[index].position - transform.position).normalized * Time.deltaTime * speed);
        if (Vector3.Distance(positions3[index].position, transform.position) < 0.5f)
        {
            index++;
            if (index == 4)
            {
                index = 0;
                index++;
            }
        }
    }
}
