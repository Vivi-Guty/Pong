using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovimientoPlayer : MonoBehaviour
{

    public float speed = 10.0f;
    private Vector3 oldPosition;
    GameObject bola;
    // Start is called before the first frame update
    void Start()
    {
        bola = GameObject.Find("Bola");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= 8 && transform.position.y >= -7.50f)
        {
            if (Input.GetKey(KeyCode.W))
            {
                
                transform.Translate(Vector3.up * Time.deltaTime * speed);
                if (transform.position.y > 7.49f)
                {
                    transform.position = new Vector3(-13, 7.49f, 20);
                }
            }
            if (Input.GetKey(KeyCode.S))
            {
                
                transform.Translate(Vector3.down * Time.deltaTime * speed);
                
                if (transform.position.y < -7.49f)
                {
                    transform.position = new Vector3(-13, -7.49f, 20);
                }
            }
        }
        oldPosition = transform.position;

        if (bola.transform.position.x == 0 && bola.transform.position.y == 0)
        {
            speed = 10;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Bola")
        {
            speed += 1.5f;
            transform.position = oldPosition;
        }

        
    }
}   
