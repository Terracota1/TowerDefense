using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public GameObject MenuOpciones;
    public GameObject MenuInicial;

    public void IniciarJuego()
    {
        SceneManager.LoadScene(1);
    }

    public void finalizarJuego()
    {
        Application.Quit();
    }

    public void MostrarOpciones()
    {
        MenuInicial.SetActive(false);
        MenuOpciones.SetActive(true);
    }

    public void MostrarMenuIncial()
    {
        MenuOpciones.SetActive(false);
        MenuInicial.SetActive(true);
    }
}
