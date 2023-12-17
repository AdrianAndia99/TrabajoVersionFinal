using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCode : MonoBehaviour
{
    public GameObject _personaje;
    void Update()
    {
        if(_personaje != null)
        {
            transform.position = new Vector3(_personaje.transform.position.x, _personaje.transform.position.y, -10);
        }
        else
        {
            transform.position = new Vector3(0,0,0);
        }
    }//aca es para que la camara siga p al jugador cuando se mueva, pero si se destruye, la camara se va al punto d origen
}
