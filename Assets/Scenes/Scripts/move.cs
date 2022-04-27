using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float moveSpeed;
    public GameObject EndGame;
    //private float ver, hor;
    public Transform movePoint;
    public LayerMask whatStopMovement;


    // Start is called before the first frame update
    void Start()
    {
       // PlayerPrefs.SetFloat("number", 0);
        movePoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        //hor = Input.GetAxis("Horizontal");
        //ver = Input.GetAxis("Vertical");

       // transform.position += transform.up * ver * moveSpeed * Time.deltaTime;
       // transform.position += transform.right * hor * moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

       // if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
       // {
            if (Mathf.Abs(Input.GetAxis("Horizontal")) == 1)
            {
                //if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(hor, 0f, 0f), .2f, whatStopMovement))
                //{
                    movePoint.position += new Vector3(Input.GetAxis("Horizontal"), 0, 0);
                //}

            }

            else if (Mathf.Abs(Input.GetAxis("Vertical")) == 1)
            {
                //if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, ver, 0f), .2f, whatStopMovement))
                //{
                    movePoint.position += new Vector3(0, Input.GetAxis("Vertical"), 0);
                //}
            }
       // }

       // if (Input.GetKeyDown(KeyCode.Space))
       // {
       //     Debug.Log(PlayerPrefs.GetFloat("number"));
       // }

       // if (PlayerPrefs.GetFloat("number") >= 3)
       // {

       //     GameObject.Find("Door1").GetComponent<BoxCollider2D>().isTrigger = true;
       // }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        if (collision.name == "monster")
        {
            Destroy(GameObject.Find("monster"), 0.5f);
            GameObject.Find("Door2").GetComponent<BoxCollider2D>().isTrigger = true;
        }

        if (collision.name == "End")
        {
            Time.timeScale = 0;
            EndGame.SetActive(true);
        }
    }


}
