using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    
    public float moveSpeed = 5f;
    public GameObject bridge;
    public GameObject VertAssistant;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bridge, transform.position, Quaternion.identity);
        }

        if (Input.GetMouseButtonDown(1))
        {
            Instantiate(VertAssistant, transform.position, Quaternion.identity);
        }

        if (transform.position.y < 0f)
        {
            Vector3 transpos = transform.position;
            transpos.y = transform.position.y + 10f;
            transform.position = transpos;
        }

        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");

        Vector3 MoveDirection = new Vector3(Horizontal, Vertical, 0);

        transform.Translate(MoveDirection * moveSpeed * Time.deltaTime);

        if (transform.position.y > 400f)
        {
            SceneManager.LoadScene(1);
        }
    }
}
