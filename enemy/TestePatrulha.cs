using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestePatrulha : MonoBehaviour
{
    private float speed = 5;
    public GameObject A;
    public GameObject B;
     
    void Start()
    {
        
      
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * speed);
         if ((transform.position.x >= B.transform.position.x) || (transform.position.x <= A.transform.position.x) )
         {
           
            speed *= -1;

             Vector2 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;

         }
         


    }
}
