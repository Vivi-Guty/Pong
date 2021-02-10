using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{

    private int speedX, speedY, pIA = 0, pPlayer = 0;
    private float speedBase;
    public float speedBall = 0.75f;
    public Text puntosPlayer, puntosIA;
    Rigidbody ball;
    // Start is called before the first frame update
    void Start()
    {
        speedBase = Random.Range(5, 10); //Esta va a ser la velocidad general al principio de la partida

        speedX = Random.Range(0, 2); //Para que me de un numero aleatorio entre 0 y 1

        if (speedX == 0) //Este if me determina la direcion con la que va a salir la bola
        {
            speedX = -1;
        }

        speedY = Random.Range(0, 2);

        if (speedY == 0) //Este if me dice si va a ir hacia arriba o caia abajo 
        {
            speedY = -1;
        }


        ball = GetComponent<Rigidbody>();

        //Multiplicamos la speedBase por las demas speed para que nos de la velocidad y direcion
        ball.velocity = new Vector3(speedX * speedBase, speedY * speedBase, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (transform.position.y > 9)
        {
            transform.position = new Vector3(ball.position.x, 8.99f, ball.position.z);
        }
        if (transform.position.y < -9)
        {
            transform.position = new Vector3(ball.position.x, -8.99f, ball.position.z);
        }

    }

    void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.name == "Pala")
            {                
                if (ball.velocity.x > 0.00f)
                {
                    if (ball.velocity.y > 0.00f)
                    {
                        ball.velocity = new Vector3(ball.velocity.x + speedBall, ball.velocity.y + speedBall, 0);

                    }
                    else
                    {
                        ball.velocity = new Vector3(ball.velocity.x + speedBall, ball.velocity.y + -speedBall, 0);
                    }
                }
                else
                {
                    if (ball.velocity.y > 0.00f)
                    {
                        ball.velocity = new Vector3(ball.velocity.x + -speedBall, ball.velocity.y + speedBall, 0);

                    }
                    else
                    {
                        ball.velocity = new Vector3(ball.velocity.x + -speedBall, ball.velocity.y + -speedBall, 0);
                    }
                }
            }

            if (collision.gameObject.name == "PalaIA")
            {
                if (ball.velocity.x > 0.00f)
                {
                    if (ball.velocity.y > 0.00f)
                    {
                        ball.velocity = new Vector3(ball.velocity.x + speedBall, ball.velocity.y + speedBall, 0);

                    }
                    else
                    {
                        ball.velocity = new Vector3(ball.velocity.x + speedBall, ball.velocity.y + -speedBall, 0);
                    }
                }
                else
                {
                    if (ball.velocity.y > 0.00f)
                    {
                        ball.velocity = new Vector3(ball.velocity.x + -speedBall, ball.velocity.y + speedBall, 0);

                    }
                    else
                    {
                        ball.velocity = new Vector3(ball.velocity.x + -speedBall, ball.velocity.y + -speedBall, 0);
                    }
                }
            }


            if (collision.gameObject.name == "bordesDerecho")
            {
                speedBase = Random.Range(5, 10);
                pPlayer += 1;
                puntosPlayer.text = "Jugador 1 = " + pPlayer.ToString();
                transform.position = new Vector3(0, 0, 20);
                
                ball.velocity = new Vector3((-1 * speedX) * speedBase, Random.Range(0, 2) * speedBase, 0);
            }
            if (collision.gameObject.name == "bordesIzquierdo")
            {
                speedBase = Random.Range(5, 10);
                pIA += 1;
                puntosIA.text = pIA.ToString() + " = Jugador 2";
                transform.position = new Vector3(0, 0, 20);
                ball.velocity = new Vector3((-1* speedX) * speedBase, Random.Range(0, 2) * speedBase, 0);
            }
    }
}
