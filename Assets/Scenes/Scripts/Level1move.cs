using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1move : MonoBehaviour
{
    public float moveSpeed;
    public GameObject text;
    private float ver, hor;
  

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetFloat("number", 0);
    }

    // Update is called once per frame
    void Update()
    {
        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");

        transform.position += transform.up * ver * moveSpeed * Time.deltaTime;
        transform.position += transform.right * hor * moveSpeed * Time.deltaTime;



        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(PlayerPrefs.GetFloat("number"));
        }

        if (PlayerPrefs.GetFloat("number") >= 1)
        {

            GameObject.Find("Door1").GetComponent<BoxCollider2D>().isTrigger = true;
            GameObject.Find("Door1-1").GetComponent<BoxCollider2D>().isTrigger = true;
            GameObject.Find("Door1").gameObject.GetComponent<Renderer>().enabled = false;
            GameObject.Find("Door1-1").gameObject.GetComponent<Renderer>().enabled = false;
        }
        if (PlayerPrefs.GetFloat("number") >= 2)
        {

            GameObject.Find("Door2").GetComponent<BoxCollider2D>().isTrigger = true;
            GameObject.Find("Door2").gameObject.GetComponent<Renderer>().enabled = false;
        }
        if (PlayerPrefs.GetFloat("number") >= 3)
        {

            GameObject.Find("Door3").GetComponent<BoxCollider2D>().isTrigger = true;
            GameObject.Find("Door3").gameObject.GetComponent<Renderer>().enabled = false;
        }
        if (PlayerPrefs.GetFloat("number") >= 4)
        {

            GameObject.Find("Door4").GetComponent<BoxCollider2D>().isTrigger = true;
            GameObject.Find("Door4").gameObject.GetComponent<Renderer>().enabled = false;
        }


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
            text.SetActive(true);
        }
    }


}
