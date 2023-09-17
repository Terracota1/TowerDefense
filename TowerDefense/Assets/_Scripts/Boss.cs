using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss : EnemigoBase
{
    public void Awake()
    {
        vida = 200;
        _dano = 20;
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
        referenciaAdminJuego.enemigoBaseDerrotados++;
    }
}
