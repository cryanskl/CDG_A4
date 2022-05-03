using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class move : MonoBehaviour
{
    [Header("�ƶ��ٶ�")]
    public float moveSpeed =1f;
    [Header("�յ�")]
    public GameObject EndGame;
    [Header("����ƶ���")]
    public Transform movePoint;
    [Header("�ƶ�����")]
    public LayerMask whatStopMovement;
    [Header("����ֵ�ı�")]
    public Text bloodBarText;
    [Header("Ѫ��")]
    public RectTransform bloorBarImage;
   
    
    /// <summary>
    /// �������ֵ
    /// </summary>
    private float ver, hor;

    /// <summary>
    /// ����ֵ
    /// </summary>
    private int number;

    //����ֵͼƬ�ĳ���
    private float width;

    //�������
    private Animator ani;

    // Start is called before the first frame update
    void Awake()
    {

        //��movePoint��������Ƴ���
        movePoint.parent = null;
        //��ʼ������ֵ
        number = 40;
        //��ʼ������ֵ�ı�
        bloodBarText.text = number.ToString();
        //��ȡѪ������
        width = bloorBarImage.sizeDelta.x;
        //��ȡ��һ���Ӷ���Ķ������
        ani = transform.GetChild(0).GetComponent<Animator>();
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
                }
                    
            }
            if(number <= 0)
            {
                number = 0;
                bloodBarText.text = number.ToString();
                Debug.Log("Game Over");
            }
        }
        
           



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        //����������ͷ���ս��
        if (collision.name == "monster")
        {
            Destroy(GameObject.Find("monster"), 0.5f);
            GameObject.Find("Door2").GetComponent<BoxCollider2D>().isTrigger = true;
        }

        //�������յ�ͽ�����Ϸ
        if (collision.name == "End")
        {
            Time.timeScale = 0;
            EndGame.SetActive(true);
        }

        //��������Ѫ���һ��Ѫ
       if(collision.tag == "BloodHeal")
        {
            number ++;
            width += 6;
            bloorBarImage.sizeDelta = new Vector2(width, bloorBarImage.sizeDelta.y);
            bloodBarText.text = number.ToString();
            Destroy(collision.gameObject);
        }

    }


}
