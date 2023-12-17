using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickEscena : MonoBehaviour
{
    public void CambioEscena(string nombre)
    {
        SceneManager.LoadScene(nombre);
    }
}//cambiar escenas nomas con el click XD