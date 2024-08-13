using UnityEngine;

public class EnemyStatusController : MonoBehaviour
{
    // HP maximo do inimigo
    public int maxHP = 150;
    Rigidbody2D rb;
    // Referencia ao Script PlayerStatus do jogador
    public PlayerStatus playerStatus;

    // Metodos chamados ao iniciar o jogo
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("weapon"))
        {
            // Diminui a vida do inimigo
            maxHP -= playerStatus.dmg;
            // Mostra no console o dano causado
            Debug.LogError(playerStatus.dmg);
            // Mostra no console a vida atual do inimigo
            Debug.Log("maxHP = " + maxHP);
            // Adiciona uma forca no inimigo para ele se mover
            rb.AddForce(new Vector2(2f, 0), ForceMode2D.Impulse);
        }

        if (maxHP <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}

