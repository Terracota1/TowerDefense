using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombiePolicia : MonoBehaviour
{
    public GameObject objetivo;
    public int vida = 50;

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
        objetivo?.GetComponent<Objetivo>().RecibirDano(10);
    }

    public void RecibirDano(int dano = 5)
    {
        vida -= dano;
    }
}