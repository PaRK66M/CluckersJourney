using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleControl : MonoBehaviour
{
    public float floatSpeed = 2f;
    public float raiseSpeed = 2f;
    public float floatHeight = 0.25f; 
    public Vector3 start_raise_position = new Vector3(0f,0f,0f);
    public float start_raise_time = 0.0f;

    public bool isBound = false;
    public Collider2D tmp;

    private Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isBound)
        {
            // 根据sin函数计算浮动偏移
            float yOffset = Mathf.Sin(Time.time * floatSpeed) * floatHeight;

            // 设置新的位置
            transform.position = startPos + new Vector3(0f, yOffset, 0f);
        }

        if (isBound && Input.GetKeyDown(KeyCode.S))
        {
            UnbindChicken();
        }
        if (isBound)
        {
            // 根据sin函数计算浮动偏移
            float yOffset = (Time.time-start_raise_time)*raiseSpeed;

            // 设置新的位置
            transform.position = start_raise_position + new Vector3(0f, yOffset , 0f);
            Vector3 bubbleCenter = transform.position;
            // 设置石头的位置为气泡的中心位置
            tmp.transform.position = bubbleCenter- new Vector3(0f,0.2f,0f);

            
           // playerRb.velocity = new Vector3(0,0,0);
        }
        
    }
    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            tmp=col;
            Vector3 bubbleCenter = transform.position;
        // 设置石头的位置为气泡的中心位置
            col.transform.position = bubbleCenter- new Vector3(0f,0.2f,0f);
            
            //tmp.jumpStart=false;
            //col.transform.jumpStart=false;
            //Renderer renderer = otherObject.GetComponent<Renderer>();
            //renderer.material.color = Color.red;
            //Renderer renderer = col.gameObject.GetComponent<Renderer>();
            //renderer.jumpStart = false;
            //renderer.material.color = Color.red;
            BindChicken(col.gameObject);
        }
    }
    private void BindChicken(GameObject pl)
    {
        isBound = true;
        start_raise_position = transform.position;
        start_raise_time = Time.time;
        pl.transform.SetParent(transform);
    }

    private void UnbindChicken()
    {
        isBound = false;
        // 解除绑定，将石头的父物体设置为null
        transform.GetChild(0).parent = null;
        Destroy(gameObject);
    }

}
