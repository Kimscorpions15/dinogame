using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaVertical : MonoBehaviour
{
    public float speed = 5f;
    public GameObject pontoAV;
    public GameObject pontoBV;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * speed);
         if ((transform.position.y > pontoBV.transform.position.y) || (transform.position.y < pontoAV.transform.position.y))
         {
            speed *= -1;

           

         }
         


    }
}
