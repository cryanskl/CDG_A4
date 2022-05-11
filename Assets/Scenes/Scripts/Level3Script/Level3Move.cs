using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level3Move : MonoBehaviour
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


    /// Virtual axis values
    private float ver, hor;

    /// HP value
    private int number;

    //Length of the HP value image
    private float width;

    //Animation components
    private Animator ani;

    private float score, counter, aniCounter;

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
        #region Movement
        counter += Time.deltaTime;
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

        #endregion

      

        #region Level3
        if (transform.childCount >= 3 && counter > 3)
        {
            number += 1;
            width += 6;
            bloorBarImage.sizeDelta = new Vector2(width, bloorBarImage.sizeDelta.y);
            bloodBarText.text = number.ToString();
            counter = 0;

            if (number >= 41)
            {
                number = 40;
                width = 240;
                bloorBarImage.sizeDelta = new Vector2(width, bloorBarImage.sizeDelta.y);
                bloodBarText.text = number.ToString();
            }



        }

        if (ani.GetCurrentAnimatorStateInfo(0).IsName("Injured"))
        {
            aniCounter += Time.deltaTime;
            if (aniCounter > 2)
            {
                transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                transform.GetComponent<BoxCollider2D>().isTrigger = false;
                ani.SetBool("Injured", false);
                aniCounter = 0;
            }
        }
        #endregion

   


    }


    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Level3-Monster")
        {
            number -= 5;
            width -= 30;
            bloorBarImage.sizeDelta = new Vector2(width, bloorBarImage.sizeDelta.y);
            bloodBarText.text = number.ToString();
            ani.SetBool("Injured", true);

            transform.GetComponent<BoxCollider2D>().isTrigger = true;
            transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            if (number >= 41)
            {
                number = 40;
                width = 240;
                bloorBarImage.sizeDelta = new Vector2(width, bloorBarImage.sizeDelta.y);
                bloodBarText.text = number.ToString();
            }
        }

        else if (transform.childCount >= 3 && collision.transform.tag == "Level3-Monster")
        {
            number -= 2;
            width -= 12;
            bloorBarImage.sizeDelta = new Vector2(width, bloorBarImage.sizeDelta.y);
            bloodBarText.text = number.ToString();
            ani.SetBool("Injured", true);
            transform.GetComponent<BoxCollider2D>().isTrigger = true;
            transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            if (number >= 41)
            {
                number = 40;
                width = 240;
                bloorBarImage.sizeDelta = new Vector2(width, bloorBarImage.sizeDelta.y);
                bloodBarText.text = number.ToString();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        #region NormalTrigger
        if (collision.tag == "EndGame")
        {
            Time.timeScale = 0;
            EndGame.SetActive(true);
            PlayerPrefs.SetFloat("Score", number + score);
            float result = PlayerPrefs.GetFloat("Score");
            if (result>=22)
            {
                starList[0].SetActive(true);
                starList[1].SetActive(true);
                starList[2].SetActive(true);
            }
            else if (result >= 15 && result < 22)
            {
                starList[0].SetActive(true);
                starList[1].SetActive(true);
            }
            else
            {
                starList[0].SetActive(true);
            }

            number += (int)score;
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
        #endregion


        #region Level3Trigger
        if (collision.tag == "Partner1")
        {
            collision.transform.SetParent(this.transform);
            collision.transform.localPosition = new Vector3(-0.53f, 0.21f, 0);
            collision.transform.localScale = new Vector3(0.4f, 0.5f, 0);
            collision.transform.GetComponent<BoxCollider2D>().enabled = false;
            score += 4;

        }
        if (collision.tag == "Partner2")
        {
            collision.transform.SetParent(this.transform);
            collision.transform.localPosition = new Vector3(-0.48f, -0.72f, 0);
            collision.transform.localScale = new Vector3(0.28f, 0.4f, 0);
            score += 4;

        }
        if (collision.tag == "Partner3")
        {
            collision.transform.SetParent(this.transform);
            collision.transform.localPosition = new Vector3(0.6f, -0.18f, 0);
            collision.transform.localScale = new Vector3(0.5f, 0.6f, 0);
            score += 4;

        }

        #endregion

    }
}
