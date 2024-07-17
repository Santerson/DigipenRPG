using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLocking : MonoBehaviour
{
    [SerializeField] float xScrollSpeed = 15f;
    [SerializeField] float yScrollSpeed = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D RefCameraRB = Camera.main.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 playerPosition = transform.position;
        Vector3 cameraPosition = Camera.main.transform.position;
        float xDiff = playerPosition.x - cameraPosition.x;
        float yDiff = playerPosition.y - cameraPosition.y;
        Debug.Log(cameraPosition.x + ", " + cameraPosition.y);
        if (yDiff > 5)
        {
            Camera.main.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, yScrollSpeed));
        }
        else if (yDiff < -5)
        {
            Camera.main.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -yScrollSpeed));
        }
        if (xDiff > 9)
        {
            Camera.main.GetComponent<Rigidbody2D>().AddForce(new Vector2(xScrollSpeed, 0));
        }
        else if (xDiff < -9)
        {
            Camera.main.GetComponent<Rigidbody2D>().AddForce(new Vector2(-xScrollSpeed, 0));
        }
        Debug.Log(Camera.main.transform.position.x >= 18 && Camera.main.transform.position.y >= 10);
        if (Camera.main.transform.position.x >= 18 && Camera.main.transform.position.y >= 10)
        {
            Debug.Log("Camera is locking to the top right");
            Camera.main.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            Camera.main.GetComponent<Rigidbody2D>().position = new Vector2(18, 10);

        }
        else if (Camera.main.transform.position.y >= 10 && Camera.main.transform.position.x <= 0 && !(yDiff > 5) && !( yDiff < -5))
        {
            Debug.Log("Camera is locking to the top left");
            Camera.main.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            Camera.main.GetComponent<Rigidbody2D>().position = new Vector2(0, 10);
        }
        else if (Camera.main.transform.position.y <= 0 && Camera.main.transform.position.x <= 0 &&  !(yDiff > 5) && !(yDiff < -5))
        {
            Debug.Log("Camera is locking to the bottom left");
            Camera.main.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            Camera.main.GetComponent<Rigidbody2D>().position = new Vector2(0, 0);
        }
        else if (Camera.main.transform.position.x >= 18 && Camera.main.transform.position.y <= 0 && !(xDiff > 9) && !(xDiff < -9))
        {
            Debug.Log("Camera is locking to the bottom right");
            Camera.main.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            Camera.main.GetComponent<Rigidbody2D>().position = new Vector2(18, 0);
        }
    }
}
