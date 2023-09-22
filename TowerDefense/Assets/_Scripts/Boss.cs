using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss : EnemigoBase
{
    public void Awake()
    {
        vida = 500;
        _dano = 30;
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
        referenciaAdminJuego.enemigosJefeDerrotados++;
    }
}
