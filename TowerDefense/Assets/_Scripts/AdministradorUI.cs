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
    }

    private void ActualizarRecursos()
    {
        textoRecursos.text = $"Recursos: {referenciaAdminJuego.recursos}";
    }

    private void MostrarMenuOlaGanada()
    {
        textoEnemigos.text = $"ENEMGOS: \t {referenciaAdminJuego.enemigoBaseDerrotados}";
        textoJefes.text = $"JEFES: \t\t {referenciaAdminJuego.enemigosJefeDerrotados}";
        MenuOlaGanada.SetActive(true);
    }

    private void OcultarMenuOlaGanada()
    {
        MenuOlaGanada.SetActive(false);
    }

    private void MostrarMensajeUltimoEnemigo()
    {
        MensajeFinOla.SetActive(true);
        Invoke("OcultarMensajeUltimoEnemigo", 3);
    }

    private void OcultarMensajeUltimoEnemigo()
    {
        MensajeFinOla.SetActive(false);
    }

    private void ActualizarOla()
    {
        textoOleada.text = $"Ola: {referenciaSpawner.oleada}";
        OcultarMenuOlaGanada();
    }

    private void OnDisable()
    {
        referenciaObjetivo.EnObjetivoDestruido -= MostrarMenuGameOver;
        referenciaSpawner.EnOleadaIniciada -= ActualizarOla;
        referenciaSpawner.EnOleadaTerminada -= MostrarMensajeUltimoEnemigo;
        referenciaSpawner.EnOleadaGanada -= MostrarMenuOlaGanada;
        referenciaAdminJuego.EnRecursosModificados -= ActualizarRecursos;
    }

    public void MostrarMenuFinOleada()
    {

    }

    public void OcultarMenuFinOleada()
    {

    }

    public void MostrarMenuGameOver()
    {
        menuPerdiste.SetActive(false);
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
