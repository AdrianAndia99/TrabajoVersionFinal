using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movimiento : MonoBehaviour
{
    Rigidbody2D rb2d;
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        rb2d.velocity = new Vector2(-1,0);
    }//esto es de la pantalla de carga p XD
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="MuroCarga")
        {            
            SceneManager.LoadScene("PantallaJuego");
        }
    }//al chocar con ese muro se iniciara el juego
}