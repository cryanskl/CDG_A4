using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster405 : MonoBehaviour
{
    private Transform[] positions;

    public int index = 0;
    public float speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        positions = L4WayPoint.L4wayPoint5;
    }

    // Update is called once per frame
    void Update()
    {
        Moving();
    }

    void Moving()
    {
        transform.Translate((positions[index].position - transform.position).normalized * speed * Time.deltaTime);
        if (Vector3.Distance(positions[index].position, transform.position) < 0.5f)
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
