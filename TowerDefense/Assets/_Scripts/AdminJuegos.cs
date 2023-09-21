using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdminJuegos : MonoBehaviour
{
    public int enemigoBaseDerrotados;
    public int enemigosJefeDerrotados;
    public int recursos;

    public delegate void RecursosModificados();
    public event RecursosModificados EnRecursosModificados;

    void Start()
    {
        recursos = 1000;
    }

    public void ModificarRecursos(int modificacion)
    {
        recursos += modificacion;
        if (EnRecursosModificados != null)
        {
            EnRecursosModificados();
        }
    }

    public void ResetValores()
    {
        enemigoBaseDerrotados = 0;
        enemigosJefeDerrotados = 0;
    }
}

