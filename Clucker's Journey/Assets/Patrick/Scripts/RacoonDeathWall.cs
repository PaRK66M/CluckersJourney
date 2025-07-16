using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacoonDeathWall : MonoBehaviour
{
    public float speed;
    public Vector3 direction;
    public LevelSceneManager lsm;

    // Update is called once per frame
    void Update()
    {
        transform.position += speed * direction * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.SetActive(false);
            lsm.RestartLevel();
        }
    }
}
