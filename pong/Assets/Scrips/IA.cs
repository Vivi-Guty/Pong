using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA : MonoBehaviour
{

    GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.Find("Bola");
    }

    // Update is called once per frame
    
    void Update()
    {
        if (transform.position.y <= 8 && transform.position.y >= -7.50f)
        {
            transform.position = new Vector3(13, ball.transform.position.y, 20);
             
            if (transform.position.y > 7.49f)
            {
                transform.position = new Vector3(13, 7.49f, 20);
            }
            if (transform.position.y < -7.49f)
            {
                transform.position = new Vector3(13, -7.49f, 20);
            }
        }
        
    }
    
}
