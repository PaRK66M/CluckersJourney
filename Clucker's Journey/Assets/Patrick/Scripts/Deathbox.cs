using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deathbox : MonoBehaviour
{
    public GameManager GM;

    public List<GameObject> thingsToReset = new List<GameObject>();

    void Awake()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ResetThings();
            collision.gameObject.transform.position = GM.spawnPoint.position;
        }
    }

    void ResetThings()
    {
        foreach (GameObject thing in thingsToReset)
        {
            thing.SendMessage("Reset");
        }
    }
}
