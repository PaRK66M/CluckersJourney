using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10f;
    void Update()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");
        transform.position += new Vector3(horizontal * Time.deltaTime * 5, vertical * Time.deltaTime * jumpForce, 0);

    }
}
