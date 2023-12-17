using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTruFal : MonoBehaviour
{
    public bool siono = false;
    public GameObject positionPlayer;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            siono = true;
            positionPlayer = collision.gameObject;
        }
    }//cuando entra en el rango dispara
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            siono = false;
            positionPlayer = null;
        }
    }//cuando sale del rango deja de disparar
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            siono = true;
            positionPlayer = null;
        }
    }//llama una vez al disparo
}
