using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrulhaController : MonoBehaviour
{

    private float velocidade;
    public GameObject pontoA;
    public GameObject pontoB;

    private int vida;

    // Start is called before the first frame update
    void Start()
    {
        velocidade = 2f;
        // Quantidade de vida do NPC
        vida = 50;
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(vida);
        transform.Translate(Vector2.left * Time.deltaTime * velocidade);

        if ((transform.position.x < pontoA.transform.position.x) || (transform.position.x > pontoB.transform.position.x))
        {

            //Muda o sinal da velocidade, se positiva vai para negativa, se negativa vai para positiva
            velocidade *= -1;

            //Espelha o NPC para a direção correta
            Vector2 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }

    }

    
}
