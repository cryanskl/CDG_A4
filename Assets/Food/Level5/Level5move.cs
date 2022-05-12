using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Level5move : MonoBehaviour
{
    [Header("Movement Speed")]
    public float moveSpeed = 1f;
    [Header("End Point")]
    public GameObject EndGame;
    [Header("Game Over")]
    public GameObject GameOver;
    [Header("Player movement points")]
    public Transform movePoint;
    [Header("Movement detection layer")]
    public LayerMask whatStopMovement;
    [Header("HP text")]
    public Text bloodBarText;
    [Header("HP bar")]
    public RectTransform bloorBarImage;
    [Header("Star list")]
    public GameObject[] starList;

    [SerializeField]
    private GameObject item;

    /// Virtual axis values
    private float ver, hor;

    /// HP value
    private int number;

    //Length of the HP value image
    private float width;

    //Animation components
    private Animator ani;

    private float nu;

    // Start is called before the first frame update
    void Awake()
    {
        //Removing movePoint from the player
        movePoint.parent = null;
        //Initial life value
        number = 40;
        //Initialising the life value text
        bloodBarText.text = number.ToString();
        //Get blood bar length
        width = bloorBarImage.sizeDelta.x;
        //Get the animation component of the first child object
        ani = transform.GetChild(0).GetComponent<Animator>();

        PlayerPrefs.SetFloat("Score", 0);
    }

    private void Start()
    {
        PlayerPrefs.SetFloat("Number", 0);
    }

    // Update is called once per frame
    void Update()
    {
        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, whatStopMovement))
                {
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                    number--;
                    width -= 6;
                    bloorBarImage.sizeDelta = new Vector2(width, bloorBarImage.sizeDelta.y);
                    bloodBarText.text = number.ToString();
                    ani.SetTrigger("Move");
                    this.enabled = true;
                }

            }
            else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), .2f, whatStopMovement))
                {
                    movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                    number--;
                    width -= 6;
                    bloorBarImage.sizeDelta = new Vector2(width, bloorBarImage.sizeDelta.y);
                    bloodBarText.text = number.ToString();
                    ani.SetTrigger("Move");
                    this.enabled = true;
                }

            }
            if (number <= 0)
            {
                number = 0;
                bloodBarText.text = number.ToString();
                Time.timeScale = 0;
                GameOver.SetActive(true);
                //Debug.Log("Game Over");
            }
        }


        if (Vector3.Distance(transform.position, movePoint.position) >= 2f)
        {
            movePoint.position = GameObject.Find("player").transform.position;
        }

        if (PlayerPrefs.GetFloat("Number") >= 1)
        {
            GameObject.Find("Door1").GetComponent<BoxCollider2D>().isTrigger = true;
            GameObject.Find("Door1").GetComponent<Renderer>().enabled = false;
            Destroy(GameObject.Find("Air Wall1"));
        }
        if (PlayerPrefs.GetFloat("Number") >= 2)
        {
            GameObject.Find("Door2").GetComponent<BoxCollider2D>().isTrigger = true;
            GameObject.Find("Door2").GetComponent<Renderer>().enabled = false;
            Destroy(GameObject.Find("Air Wall2"));
        }
        if (PlayerPrefs.GetFloat("Number") >= 1)
        {
            GameObject.Find("Door3").GetComponent<BoxCollider2D>().isTrigger = true;
            GameObject.Find("Door3").GetComponent<Renderer>().enabled = false;
            Destroy(GameObject.Find("Air Wall3"));
        }
        if (PlayerPrefs.GetFloat("Number") >= 2)
        {
            GameObject.Find("Door4").GetComponent<BoxCollider2D>().isTrigger = true;
            GameObject.Find("Door4").GetComponent<Renderer>().enabled = false;
            Destroy(GameObject.Find("Air Wall4"));
        }

        //if (Input.GetKeyDown(KeyCode.I))
        //{

        //}




    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Monster-2hp")
        {
            number = number - 2;
            width = width - 12;
            bloorBarImage.sizeDelta = new Vector2(width, bloorBarImage.sizeDelta.y);
            bloodBarText.text = number.ToString();
            Destroy(collision.gameObject, 0.1f);
        }

        if (collision.tag == "Monster-4hp")
        {
            number = number - 4;
            width = width - 24;
            bloorBarImage.sizeDelta = new Vector2(width, bloorBarImage.sizeDelta.y);
            bloodBarText.text = number.ToString();
            Destroy(collision.gameObject, 0.1f);
        }

        if (collision.tag == "Stop-2hp")
        {
            number = number - 40;
            width = width - 12;
            bloorBarImage.sizeDelta = new Vector2(width, bloorBarImage.sizeDelta.y);
            bloodBarText.text = number.ToString();
        }

        if (collision.tag == "EndGame")
        {
            Time.timeScale = 0;
            EndGame.SetActive(true);
            PlayerPrefs.SetFloat("Score", number);
            float score = PlayerPrefs.GetFloat("Score");
            if (score > 25)
            {
                starList[0].SetActive(true);
                starList[1].SetActive(true);
                starList[2].SetActive(true);
            }
            else if (score >= 15 && score < 25)
            {
                starList[0].SetActive(true);
                starList[1].SetActive(true);
            }
            else
            {
                starList[0].SetActive(true);
            }

        }

        if (collision.tag == "BloodHeal")
        {
            number += 11;
            width += 66;
            bloorBarImage.sizeDelta = new Vector2(width, bloorBarImage.sizeDelta.y);
            bloodBarText.text = number.ToString();
            Destroy(collision.gameObject);
            if (number >= 41)
            {
                number = 40;
                width = 240;
                bloorBarImage.sizeDelta = new Vector2(width, bloorBarImage.sizeDelta.y);
                bloodBarText.text = number.ToString();
            }
        }

    }

}
