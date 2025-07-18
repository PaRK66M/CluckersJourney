using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectControl : MonoBehaviour
{
    public GameObject[] CanvasOn;//定义打开画布
    public GameObject[] CanvasOff;
    public int number_of_object;
    public bool is_reversed;
    public int menuid;
    public float size_scale = 1.5f;

    public string lightBulbTag = "select"; // 灯泡物体的标签
    private GameObject[] lightBulbs; // 灯泡物体的数组
    private int selectedLightBulbIndex = 0; // 当前选择的灯泡索引
    private Vector3[] objectsize;

    public LevelSceneManager lSM;

    private bool newKey;

    private int change_index(int x)
    {
        if(is_reversed) return number_of_object- 1 - x;
        else return x;
    }

    public void changeCanvas(int i)//定义切换画布的方法
    {
        CanvasOn[i].SetActive(true);//实现打开画布
        CanvasOff[i].SetActive(false) ;//实现关闭画布
    }

    private void Start()
    {
        newKey = true;
        FindButtons();
    }

    public void FindButtons()
    {
        // 使用标签查找灯泡物体
        lightBulbs = GameObject.FindGameObjectsWithTag(lightBulbTag);
        int len = lightBulbs.Length;
        objectsize = new Vector3[len];
        for (int i = 0; i < len; i++)
        {
            objectsize[i] = new Vector3(1, 1, 1);
        }
        Debug.Log("ok");
        lightBulbs[change_index(selectedLightBulbIndex)].GetComponent<Transform>().localScale = new Vector3(objectsize[change_index(selectedLightBulbIndex)].x * size_scale, objectsize[change_index(selectedLightBulbIndex)].y * size_scale, objectsize[change_index(selectedLightBulbIndex)].z);

    }

    private void Update()
    {
        if (newKey)
        {
            if (Input.GetAxis("Horizontal") < 0)
            {
                Debug.Log("A");
                SelectPreviousLightBulb();
                newKey = false;
            }
            else if (Input.GetAxis("Horizontal") > 0)
            {
                Debug.Log("D");
                SelectNextLightBulb();
                newKey = false;
            }

            // 检测S键的按下
            if (Input.GetButtonDown("Jump"))
            {
                Debug.Log("S");
                LightUpSelectedLightBulb();
            }
        }
        else
        {
            if(Input.GetAxis("Horizontal") == 0)
            {
                newKey = true;
            }
        }
        // 检测A键和D键的按下
        
    }

    private void SelectPreviousLightBulb()
    {
        // 减少索引，循环选择灯泡
        lightBulbs[change_index(selectedLightBulbIndex)].GetComponent<Transform>().localScale = objectsize[change_index(selectedLightBulbIndex)];
        selectedLightBulbIndex--;
        if (selectedLightBulbIndex < 0)
        {
            selectedLightBulbIndex = lightBulbs.Length - 1;
        }
        lightBulbs[change_index(selectedLightBulbIndex)].GetComponent<Transform>().localScale = new Vector3(objectsize[change_index(selectedLightBulbIndex)].x*size_scale,objectsize[change_index(selectedLightBulbIndex)].y*size_scale,objectsize[change_index(selectedLightBulbIndex)].z);

        Debug.Log("当前选择的灯泡：" + lightBulbs[change_index(selectedLightBulbIndex)].name);
    }

    private void SelectNextLightBulb()
    {
        // 增加索引，循环选择灯泡
        lightBulbs[change_index(selectedLightBulbIndex)].GetComponent<Transform>().localScale = objectsize[change_index(selectedLightBulbIndex)];
        selectedLightBulbIndex++;
        if (selectedLightBulbIndex >= lightBulbs.Length)
        {
            selectedLightBulbIndex = 0;
        }
        lightBulbs[change_index(selectedLightBulbIndex)].GetComponent<Transform>().localScale = new Vector3(objectsize[change_index(selectedLightBulbIndex)].x*size_scale,objectsize[change_index(selectedLightBulbIndex)].y*size_scale,objectsize[change_index(selectedLightBulbIndex)].z);

        Debug.Log("当前选择的灯泡：" + lightBulbs[change_index(selectedLightBulbIndex)].name);
    }

    private void LightUpSelectedLightBulb()
    {
        // 点亮当前选择的灯泡
        //lightBulbs[selectedLightBulbIndex].GetComponent<Renderer>().material.color = Color.green;


        Debug.Log("点亮灯泡：" + lightBulbs[change_index(selectedLightBulbIndex)].name);
        if(menuid==1)
        {
            if(selectedLightBulbIndex==0)
                changeCanvas(0);
            if(selectedLightBulbIndex==1)
                //SceneManager.LoadScene("haha");
                Application.Quit();
        }
        else if(menuid==2)
        {
            if(selectedLightBulbIndex==3)
                changeCanvas(0);
            if(selectedLightBulbIndex==0)
                SceneManager.LoadScene("TutorialLevel");
            if(selectedLightBulbIndex==1)
                SceneManager.LoadScene("SecondPrototype");
            if(selectedLightBulbIndex==2)
                SceneManager.LoadScene("WinterLevelPrototype");

        }
        else if (menuid == 3)
        {
            if (selectedLightBulbIndex == 0)
                SceneManager.LoadScene("SecondPrototype");
            if (selectedLightBulbIndex == 1)
                SceneManager.LoadScene("myscene");
            if (selectedLightBulbIndex == 2)
                lSM.RestartLevel();
        }
        else if (menuid == 4)
        {
            if (selectedLightBulbIndex == 0)
                SceneManager.LoadScene("WinterLevelPrototype");
            if (selectedLightBulbIndex == 1)
                SceneManager.LoadScene("myscene");
            if (selectedLightBulbIndex == 2)
                lSM.RestartLevel();
        }
        else if (menuid == 5)
        {
            if (selectedLightBulbIndex == 0)
                SceneManager.LoadScene("myscene");
            if (selectedLightBulbIndex == 1)
                lSM.RestartLevel();
        }

        //changeCanvas(change_index(selectedLightBulbIndex));

        //SceneManager.LoadScene((2-selectedLightBulbIndex+1).ToString());
    }
}
