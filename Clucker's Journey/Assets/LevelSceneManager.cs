using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSceneManager : MonoBehaviour
{
    public GameObject player;
    public Transform spawnPoint;
    public GameObject rDW;
    public Transform rDWStart;
    public GameObject victoryScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

   

    public void RestartLevel()
    {
        player.transform.position = spawnPoint.position;
        rDW.transform.position = rDWStart.position;
        player.SetActive(true);
        rDW.SetActive(true);
        victoryScreen.SetActive(false);
    }
}
