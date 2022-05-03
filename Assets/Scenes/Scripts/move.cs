using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class move : MonoBehaviour
{
    [Header("移动速度")]
    public float moveSpeed =1f;
    [Header("终点")]
    public GameObject EndGame;
    [Header("玩家移动点")]
    public Transform movePoint;
    [Header("移动检测层")]
    public LayerMask whatStopMovement;
    [Header("生命值文本")]
    public Text bloodBarText;
    [Header("血条")]
    public RectTransform bloorBarImage;
   
    
    /// <summary>
    /// 虚拟轴的值
    /// </summary>
    private float ver, hor;

    /// <summary>
    /// 生命值
    /// </summary>
    private int number;

    //生命值图片的长度
    private float width;

    //动画组件
    private Animator ani;

    // Start is called before the first frame update
    void Awake()
    {

        //把movePoint从玩家里移出来
        movePoint.parent = null;
        //初始化生命值
        number = 40;
        //初始化生命值文本
        bloodBarText.text = number.ToString();
        //获取血条长度
        width = bloorBarImage.sizeDelta.x;
        //获取第一个子对象的动画组件
        ani = transform.GetChild(0).GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //获取水平虚拟轴
        hor = Input.GetAxis("Horizontal");
        //获取垂直虚拟轴
        ver = Input.GetAxis("Vertical");
        //玩家固定移动的距离
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed*Time.deltaTime);

        
        //计算玩家与移动点的距离
        if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {
            //判断Horizontal虚拟轴的绝对值是否为1，Input.GetAxisRaw返回的值有-1，0，1三种
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                //检测玩家附近是否有碰撞体，有则返回true，没有则返回false
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, whatStopMovement))
                {
                    //如果没有碰撞体，movePoint横坐标+1
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                    //生命值减1
                    number--;
                    //长度减6
                    width -= 6;
                    //更新图片长度
                    bloorBarImage.sizeDelta = new Vector2(width, bloorBarImage.sizeDelta.y);
                    //更新生命值文本
                    bloodBarText.text = number.ToString();
                    //移动触发动画参数
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

        //触碰到怪物就发生战斗
        if (collision.name == "monster")
        {
            Destroy(GameObject.Find("monster"), 0.5f);
            GameObject.Find("Door2").GetComponent<BoxCollider2D>().isTrigger = true;
        }

        //触碰到终点就结束游戏
        if (collision.name == "End")
        {
            Time.timeScale = 0;
            EndGame.SetActive(true);
        }

        //触碰到加血点就一格血
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
