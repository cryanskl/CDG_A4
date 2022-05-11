using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delivery : MonoBehaviour
{
    public Transform goToPos;
    private Transform playerPos;

    // Start is called before the first frame update
    void Start()
    {
        playerPos = GameObject.Find("player").transform;        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        playerPos.transform.position = goToPos.transform.position;
    }

}
