using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlagController : MonoBehaviour
{
    public GameObject finishHud;

    public SelectControl sc;

    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            finishHud.SetActive(true);
            sc.FindButtons();
            //Destroy(gameObject);
        }
    }
}
