using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class PlayBut : MonoBehaviour
{

    public string key;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
  public void Update()
  { 
  if (Input.GetKeyDown (key))
  {
     EventSystem.current.SetSelectedGameObject(this.gameObject);
  }
  }
}
