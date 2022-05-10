using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCounter : MonoBehaviour
{
    private float num;

    private void Update()
    {
        num = PlayerPrefs.GetFloat("Number");
    }
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "box")
        { 
            ++num;
            PlayerPrefs.SetFloat("Number", num);
        }

        if (collision.tag == "Player")
        {
            ++num;
            PlayerPrefs.SetFloat("Number", num);
            Destroy(gameObject);
        }
    }

}
