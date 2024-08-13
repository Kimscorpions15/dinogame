using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Chase : MonoBehaviour
{
    public Transform player;
    public float followDistance = 5f;
    public float speed = 3f;
    private Vector2 originalPosition;
    private TestePatrulha patrulha;

    void Start()
    {
        originalPosition = transform.position;

       patrulha = GetComponent<TestePatrulha>();
       patrulha.enabled = false;
            // Debug.Log("patrulha desativada");
            if(patrulha.enabled == true)
            {
                 // Debug.Log("patrulha ativada");
            }

    }

    void Update()
    {
        float playerDistance = Vector3.Distance(transform.position, player.position);
        
        if (playerDistance < followDistance)
        {
            Follow(player.position);
            
        }
       
        else
        {
            Follow(originalPosition);
            patrulha.enabled = true;
           
        }
        

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
    void Follow(Vector3 alvo)
    {
        Vector3 direction = (alvo - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;


    }
}
