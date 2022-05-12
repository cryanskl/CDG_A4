using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class egg02 : MonoBehaviour
{


    private Animator anim;
    private BoxCollider2D bx2d;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        bx2d = GetComponent<BoxCollider2D>();
        
    }
    void hardTime(){
                bx2d.isTrigger = false;
                bx2d.enabled = true;
            }

    // Update is called once per frame
    void Update()
    {
 
    }
    
    void OnTriggerEnter2D(Collider2D other){
        if(other.name=="player")
        {
            anim.SetTrigger("Collapse");
            Invoke("hardTime",3f);
            hardTime();
        }
    }
    void DisableBoxCollider2D(){
        bx2d.enabled = false;
    }
}
