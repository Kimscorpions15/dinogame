using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformCollision : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collisionP)
    {
        if (collisionP.gameObject.tag == ("Player"))
        {
            collisionP.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collisionP)
    {
        if (collisionP.gameObject.tag == ("Player"))
        {
            collisionP.transform.SetParent(null);
        }
    }
}
