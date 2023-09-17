using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombiePolicia : EnemigoBase
{
    public void Awake()
    {
        vida = 100;
        _dano = 10;
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
        referenciaAdminJuego.enemigoBaseDerrotados++;
    }
}
