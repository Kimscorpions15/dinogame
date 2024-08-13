using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaHorizontal : MonoBehaviour
{
    public float speed = 5f;
    public GameObject pontoAH;
    public GameObject pontoBH;
    // Start is called before the first frame update
    void Start()
    {
        speed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * speed);
         if ((transform.position.x > pontoBH.transform.position.x) || (transform.position.x < pontoAH.transform.position.x))
         {
            speed *= -1;

           

         }
         


    }
}
