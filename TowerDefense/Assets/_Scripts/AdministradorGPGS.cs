using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class AdministradorGPGS : MonoBehaviour
{
    SpawnearEnemigos referenciaSpawner;
    public TMPro.TMP_Text GPGSText;

    void Start()
    {
        PlayGamesPlatform.Activate();
        PlayGamesPlatform.Instance.Authenticate(ProcesarAutenticacion);
    }

    private void OnEnable()
    {
        referenciaSpawner.EnOleadaGanada += DesbloquearLogro;
    }

    private void OnDisable()
    {
        referenciaSpawner.EnOleadaGanada -= DesbloquearLogro;
    }

    internal void ProcesarAutenticacion(SignInStatus status)
    {
        if (status == SignInStatus.Success)
        {
            GPGSText.text = $"Good Auth \n {Social.localUser.userName} \n {Social.localUser.id}";
        }
        else
        {
            GPGSText.text = $"Good Auth";
        }
    }

    internal void DesbloquearLogro()
    {
        string mStatus;
        Social.ReportProgress(
            GPGSIds.achievement_primer_oleada_ganada,
            100.0f,
            (bool success) =>
            {
                mStatus = success ? "Logro desbloqueado" : "Fallo en el desbloqueo del logo";
                GPGSText.text = mStatus;
            });
    }
}