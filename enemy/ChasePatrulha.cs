using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePatrulha : MonoBehaviour
{
    private float speed = 5;
    public GameObject A;
    public GameObject B;
    public Transform player;
    public float followDistance = 15f;
    public float attackDistance = 5f;

  
    float playerDistance;

    private Vector2 originalPosition;

    Animator anim;

    void Start()
    {
        originalPosition = transform.position;
      
        // Debug.Log("patrulhando");
        anim = GetComponent<Animator>();
       
    }


    void Update()
    {
        playerDistance = Vector3.Distance(transform.position, player.position);
        //// Debug.Log("distancia: "+playerDistance );

        if (playerDistance > followDistance)
        {
            Patrulha();
        }
        if (playerDistance < followDistance)
        {
            // Debug.Log("perseguindo");
            Follow();
        }
        

       
       

    }
    void OnCollisionTrigger2D(Collision2D cl)
    {
        if (cl.gameObject.tag == ("Player"))
        {
            anim.SetTrigger("ataque");
            // Debug.Log("atacando");

        }

    }
    

    void Follow()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
         
        
        Vector2 ls = transform.localScale;
        if (player.position.x > transform.position.x)
        {
            ls.x = 7;
        }
       
        else 
        {
            ls.x = -7;
        }
        transform.localScale = ls;

    }
    void Atacar()
    {
        anim.SetTrigger("ataque");


    }
    void Patrulha()
    {
        transform.Translate(Vector2.right * Time.deltaTime * speed);
        if ((transform.position.x >= B.transform.position.x) || (transform.position.x <= A.transform.position.x))
        {

            speed *= -1;

            Vector2 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;

        }

    }
   

}