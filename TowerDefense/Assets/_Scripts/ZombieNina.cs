using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieNina : MonoBehaviour
{
    public GameObject objetivo;
    public int vida = 20;

    public Animator Anim;

    private void OnEnable()
    {
        objetivo = GameObject.Find("Objetivo");
    }

    private void OnDisable()
    {


    }

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<NavMeshAgent>().SetDestination(objetivo.transform.position);
        Anim = GetComponent<Animator>();
        Anim.SetBool("IsMoving", true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Objetivo")
        {
            Anim.SetBool("IsMoving", false);
            Anim.SetTrigger("OnObjetivoReached");
        }
    }

    public void Danar()
    {
        objetivo?.GetComponent<Objetivo>().RecibirDano(5);
    }

    public void RecibirDano(int dano = 5)
    {
        vida -= dano;
    }
}
