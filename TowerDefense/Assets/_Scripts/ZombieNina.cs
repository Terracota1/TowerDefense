using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieNina : EnemigoBase
{
    private void Awake()
    {
        vida = 50;
        _dano = 5;
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
        referenciaAdminJuego.enemigoBaseDerrotados++;
    }
}
