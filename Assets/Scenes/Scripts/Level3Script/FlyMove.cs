using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyMove : MonoBehaviour
{
    public float moveSpeed = 2f;
    private Animator ani;
    private bool moDes = true,turnRight = true, mothDes=true, mothDesRight = true;
    private bool moDes1 = false, turnLeft=false ,turnDown=false,turnUp = false,mothDes1=false, mothDesDown = false,mothDesUp=false,mothDesLeft = false;

    // Start is called before the first frame update
    void Awake()
    {
        ani =GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (turnRight && ani.GetCurrentAnimatorStateInfo(0).IsName("Fly"))
        {
            transform.position += transform.right * Time.deltaTime * moveSpeed;

        }
        if (turnUp && ani.GetCurrentAnimatorStateInfo(0).IsName("Fly"))
        {
            transform.position += transform.up * Time.deltaTime * moveSpeed;
        }

        if (turnLeft && ani.GetCurrentAnimatorStateInfo(0).IsName("LeftFly"))
        {
            transform.position += transform.right * Time.deltaTime * moveSpeed;
        }
        if (turnDown && ani.GetCurrentAnimatorStateInfo(0).IsName("LeftFly"))
        {
            transform.position += -transform.up * Time.deltaTime * moveSpeed;
        }

        if (moDes && ani.GetCurrentAnimatorStateInfo(0).IsName("MosquitoMove"))
        {
            transform.position += transform.up * Time.deltaTime * moveSpeed;
            
        }
        if(moDes1 && ani.GetCurrentAnimatorStateInfo(0).IsName("MosquitoMove"))
        {
            transform.position += -transform.up * Time.deltaTime * moveSpeed;
        }

        if (mothDes && ani.GetCurrentAnimatorStateInfo(0).IsName("MothMove"))
        {
            transform.position += transform.right * Time.deltaTime * moveSpeed;
        }
        if (mothDes1 && ani.GetCurrentAnimatorStateInfo(0).IsName("MothLeft"))
        {
            transform.position += transform.right * Time.deltaTime * moveSpeed;
        }




        if(mothDesRight && ani.GetCurrentAnimatorStateInfo(0).IsName("Moth1Move"))
        {
            transform.position += transform.right * Time.deltaTime*moveSpeed;
        }
        if (mothDesDown && ani.GetCurrentAnimatorStateInfo(0).IsName("Moth1Move"))
        {
            transform.position += -transform.up * Time.deltaTime*moveSpeed;
        }
      
        if (mothDesUp && ani.GetCurrentAnimatorStateInfo(0).IsName("Moth1Left"))
        {
            transform.position += transform.up * Time.deltaTime*moveSpeed;
        }
        if (mothDesLeft && ani.GetCurrentAnimatorStateInfo(0).IsName("Moth1Left"))
        {
            transform.position += transform.right * Time.deltaTime*moveSpeed;
        }


    }
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Destination1")
        {
            transform.position = collision.transform.position;
            turnRight = false;
            turnUp = true;
           
        }
        else if (collision.name == "Destination2")
        {
            transform.position = collision.transform.position;
            turnUp = false;
            turnLeft = true;
            ani.SetBool("Left", true);
        }
        else if (collision.name == "Destination3")
        {
            transform.position = collision.transform.position;
            turnLeft = false;
            turnDown = true;
            ani.SetBool("Left", true);
        }
        else if (collision.name == "Destination4")
        {
            transform.position = collision.transform.position;
            turnDown = false;
            turnRight = true;
            ani.SetBool("Left", false);
            
        }
        else if(collision.name == "mDestination1")
        {
            transform.position = collision.transform.position;
            moDes = false;
            moDes1 = true;
            
        }
        else if (collision.name == "mDestination2")
        {
            transform.position = collision.transform.position;
            moDes = true;
            moDes1 =false;
        }
        else if (collision.name == "oDestination1")
        {
            transform.position = collision.transform.position;
            mothDes = false;
            mothDes1 = true;
            ani.SetBool("mTL", true);

        }
        else if (collision.name == "oDestination2")
        {
            transform.position = collision.transform.position;
            mothDes = true;
            mothDes1 = false;
            ani.SetBool("mTL", false);
        }
        else if(collision.name == "oDestination4")
        {
            transform.position = collision.transform.position;
            mothDesRight= false;
            mothDesDown = true;
        }
        else if (collision.name == "oDestination5")
        {
            transform.position = collision.transform.position;
            mothDesRight = true;
            mothDesDown = false;
        }
        else if (collision.name == "oDestination6")
        {
            transform.position = collision.transform.position;
            mothDesRight = false;
            mothDesDown = false;
            mothDesLeft = true;
            ani.SetBool("mTL1", true);

            GameObject.Find("Moth-Destination").transform.Find("oDestination7").gameObject.SetActive(true);
            GameObject.Find("Moth-Destination").transform.Find("oDestination8").gameObject.SetActive(true);
            GameObject.Find("Moth-Destination").transform.Find("oDestination5").gameObject.SetActive(false);
            GameObject.Find("Moth-Destination").transform.Find("oDestination4").gameObject.SetActive(false);
        }
        else if (collision.name == "oDestination7")
        {
            transform.position = collision.transform.position;
            mothDesLeft = false;
            mothDesUp = true;
        }
        else if (collision.name == "oDestination8")
        {
            transform.position = collision.transform.position;
            mothDesLeft = true;
            mothDesUp = false;
        }
        else if (collision.name == "oDestination3")
        {
            transform.position = collision.transform.position;
            GameObject.Find("Moth-Destination").transform.Find("oDestination5").gameObject.SetActive(true);
            GameObject.Find("Moth-Destination").transform.Find("oDestination4").gameObject.SetActive(true);
            GameObject.Find("Moth-Destination").transform.Find("oDestination7").gameObject.SetActive(false);
            GameObject.Find("Moth-Destination").transform.Find("oDestination8").gameObject.SetActive(false);
            ani.SetBool("mTL1", false);
            mothDesRight = true;
            mothDesUp = false;
        }

    }
}
