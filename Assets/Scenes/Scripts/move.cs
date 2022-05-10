using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class move : MonoBehaviour
{
    [Header("Movement Speed")]
    public float moveSpeed =1f;
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

    /// <summary>
    /// Virtual axis values
    /// </summary>
    private float ver, hor;

    /// <summary>
    /// HP value
    /// </summary>
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

        //���÷���Ϊ0
        PlayerPrefs.SetFloat("Score", 0);
   
        
    }

    private void Start()
    {
        PlayerPrefs.SetFloat("Number", 0);
    }

    // Update is called once per frame
    void Update()
    {
        //��ȡˮƽ������
        hor = Input.GetAxis("Horizontal");
        //��ȡ��ֱ������
        ver = Input.GetAxis("Vertical");
        //��ҹ̶��ƶ��ľ���
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed*Time.deltaTime);
        
        //����������ƶ���ľ���
        if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {
            //�ж�Horizontal������ľ���ֵ�Ƿ�Ϊ1��Input.GetAxisRaw���ص�ֵ��-1��0��1����
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                //�����Ҹ����Ƿ�����ײ�壬���򷵻�true��û���򷵻�false
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, whatStopMovement))
                {
                    //���û����ײ�壬movePoint������+1
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                    //����ֵ��1
                    number--;
                    //���ȼ�6
                    width -= 6;
                    //����ͼƬ����
                    bloorBarImage.sizeDelta = new Vector2(width, bloorBarImage.sizeDelta.y);
                    //��������ֵ�ı�
                    bloodBarText.text = number.ToString();
                    //�ƶ�������������
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
            if(number <= 0)
            {
                number = 0;
                bloodBarText.text = number.ToString();
                Time.timeScale = 0;
                GameOver.SetActive(true);

                Debug.Log("Game Over");
            }
        }


        if (Vector3.Distance(transform.position, movePoint.position) >= 2f)
        {
            movePoint.position = GameObject.Find("player").transform.position;
        }



    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        //����������ͷ���ս��
        if (collision.tag == "Monster-2hp")
        {
            number = number - 2;
            width = width - 12;
            bloorBarImage.sizeDelta = new Vector2(width, bloorBarImage.sizeDelta.y);
            bloodBarText.text = number.ToString();
            Destroy(collision.gameObject, 0.1f);
            //GameObject.Find("Door2").GetComponent<BoxCollider2D>().isTrigger = true;
        }

        if (collision.tag == "Monster-4hp")
        {
            number = number - 4;
            width = width - 24;
            bloorBarImage.sizeDelta = new Vector2(width, bloorBarImage.sizeDelta.y);
            bloodBarText.text = number.ToString();
            Destroy(collision.gameObject, 0.1f);
            //GameObject.Find("Door2").GetComponent<BoxCollider2D>().isTrigger = true;
        }

        //�������յ�ͽ�����Ϸ
        if (collision.tag == "EndGame")
        {
            Time.timeScale = 0;
            EndGame.SetActive(true);
            PlayerPrefs.SetFloat("Score", number);
            float score = PlayerPrefs.GetFloat("Score");
           if(score >= 25)
            {
                starList[0].SetActive(true);
                starList[1].SetActive(true);
                starList[2].SetActive(true);
            }
           else if (score>=15 && score < 25)
            {
                starList[0].SetActive(true);
                starList[1].SetActive(true);
            }
            else
            {
                starList[0].SetActive(true);
            }

        }

        //��������Ѫ���һ��Ѫ
       if(collision.tag == "BloodHeal")
        {
            number += 6;
            width += 36;
            bloorBarImage.sizeDelta = new Vector2(width, bloorBarImage.sizeDelta.y);
            bloodBarText.text = number.ToString();
            Destroy(collision.gameObject);
        }

    }

}
