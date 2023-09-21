using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdministradorUI : MonoBehaviour
{
    public GameObject canvasPrincipal;
    public GameObject menuPerdiste;
    public GameObject MenuOlaGanada;
    public GameObject MensajeFinOla;
    public SpawnearEnemigos referenciaSpawner;
    public Objetivo referenciaObjetivo;
    public AdminJuegos referenciaAdminJuego;
    public TMPro.TMP_Text textoRecursos;
    public TMPro.TMP_Text textoOleada;
    public TMPro.TMP_Text textoEnemigos;
    public TMPro.TMP_Text textoJefes;

    private void OnEnable()
    {
        referenciaObjetivo.EnObjetivoDestruido += MostrarMenuGameOver;
        referenciaSpawner.EnOleadaIniciada += ActualizarOla;
        referenciaSpawner.EnOleadaTerminada += MostrarMensajeUltimoEnemigo;
        referenciaSpawner.EnOleadaGanada += MostrarMenuOlaGanada;
        referenciaAdminJuego.EnRecursosModificados += ActualizarRecursos;
        referenciaSpawner.EnOleadaIniciada += ActualizarRecursos;
    }

    public void ActualizarRecursos()
    {
        textoRecursos.text = $"Recursos: {referenciaAdminJuego.recursos}";
    }

    public void MostrarMenuOlaGanada()
    {
        textoEnemigos.text = $"ENEMGOS: \t {referenciaAdminJuego.enemigoBaseDerrotados}";
        textoJefes.text = $"JEFES: \t\t {referenciaAdminJuego.enemigosJefeDerrotados}";
        MenuOlaGanada.SetActive(true);
    }

    public void OcultarMenuOlaGanada()
    {
        MenuOlaGanada.SetActive(false);
    }

    public void MostrarMensajeUltimoEnemigo()
    {
        MensajeFinOla.SetActive(true);
        Invoke("OcultarMensajeUltimoEnemigo", 3);
    }

    public void OcultarMensajeUltimoEnemigo()
    {
        MensajeFinOla.SetActive(false);
    }

    public void ActualizarOla()
    {
        textoOleada.text = $"Oleada: {referenciaSpawner.oleada}";
        OcultarMenuOlaGanada();
    }

    private void OnDisable()
    {
        referenciaObjetivo.EnObjetivoDestruido -= MostrarMenuGameOver;
        referenciaSpawner.EnOleadaIniciada -= ActualizarOla;
        referenciaSpawner.EnOleadaTerminada -= MostrarMensajeUltimoEnemigo;
        referenciaSpawner.EnOleadaGanada -= MostrarMenuOlaGanada;
        referenciaAdminJuego.EnRecursosModificados -= ActualizarRecursos;
        referenciaSpawner.EnOleadaIniciada -= ActualizarRecursos;
    }

    public void MostrarMenuFinOleada()
    {

    }

    public void OcultarMenuFinOleada()
    {

    }

    public void MostrarMenuGameOver()
    {
        menuPerdiste.SetActive(true);
    }

    public void OcultarMenuGameOver()
    {
        menuPerdiste.SetActive(false);
    }

    public void FinalizarJuego()
    {
        Application.Quit();
    }

    public void CargarMenuPrincipal()
    {
        SceneManager.LoadScene(0);
    }

    public void ReintentarNivel()
    {
        int escenaActual = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(escenaActual);
    }
}
