using UnityEngine;
using UnityEngine.SceneManagement;

public class JogadorController : MonoBehaviour
{
    public float walkspeed;
    public float runSpeed;
    public float jumpForce;
    public Rigidbody2D rb;
    public bool grounded;
    private Animator anim;
    private PlayerStatus playerStatus;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        // pega a instancia do player
        playerStatus = GetComponent<PlayerStatus>();
    }

    void Update()
    {
        Movement();
        Attack();
        Jump();
    }

    void Movement()
    {
        //andar p direita e desativar animação qnd para
        if (Input.GetKey(KeyCode.D) == true)
        {
            transform.Translate(Vector2.right * Time.deltaTime * walkspeed);
            Vector2 localScale = transform.localScale;
            localScale.x = 1f;
            transform.localScale = localScale;

            anim.SetBool("walk", true);

            //correr qnd o botão direito do mouse está pressionado e parar de correr qnd é solto
            if (Input.GetKey(KeyCode.D) && Input.GetMouseButton(1) && grounded == true)
            {
                transform.Translate(Vector2.right * Time.deltaTime * runSpeed);
                anim.SetBool("run", true);
            }
            else if (Input.GetKey(KeyCode.D) && Input.GetMouseButton(1) == false)
            {
                anim.SetBool("run", false);
            }
        }

        else if (Input.GetKey(KeyCode.D) == false)
        {
            anim.SetBool("walk", false);
            anim.SetBool("run", false);
        }


        //andar p esquerda e desativar animação qnd para
        if (Input.GetKey(KeyCode.A) == true)
        {
            transform.Translate(Vector2.left * Time.deltaTime * walkspeed);
            Vector2 localScale = transform.localScale;
            localScale.x = -1;
            transform.localScale = localScale;



            anim.SetBool("walkleft", true);

            //correr qnd o botão direito do mouse está pressionado e parar de correr qnd é solto
            if (Input.GetKey(KeyCode.A) && Input.GetMouseButton(1) && grounded == true)
            {
                transform.Translate(Vector2.left * Time.deltaTime * runSpeed);
                anim.SetBool("runleft", true);

            }
            else if (Input.GetKey(KeyCode.A) && Input.GetMouseButton(1) == false)
            {
                anim.SetBool("runleft", false);
            }


        }

        else if (Input.GetKey(KeyCode.A) == false)
        {
            anim.SetBool("walkleft", false);
            anim.SetBool("runleft", false);
        }




    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (grounded == true))
        {
            // mostra no console o dano atual quando pula
            Debug.LogWarning(playerStatus.dmg);
            grounded = false;
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            anim.SetBool("jump", true);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0, -10), ForceMode2D.Impulse);

            anim.SetBool("jump", false);

            //animação de cair qnd toca o chão
            anim.SetBool("fall", true);
        }
        if (grounded == true)
        {
            anim.SetBool("fall", false);
        }
    }
    public void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("attack");
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            grounded = true;
        }

    }

    // Método executado quando ocorre uma colisão com outro objeto
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Se colidir com um inimigo, diminui a vida do jogador em 5 e impede que o jogador seja danificado novamente
        if (collision.gameObject.CompareTag("enemy"))
        {
            playerStatus.HP -= 5f; // Diminui a vida do jogador em 5 unidades
            playerStatus.canBeDamaged = false; // Impede que o jogador seja danificado novamente
        }

        // Se a vida do jogador for menor ou igual a 0, destrói o objeto do jogador e recarrega a cena atual
        if (playerStatus.HP <= 0)
        {
            Destroy(this.gameObject); // Destrói o objeto do jogador
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Recarrega a cena atual
        }

        // Se colidir com um coração, aumenta a vida máxima do jogador em 50 e adiciona 50 unidades de vida
        if (collision.gameObject.CompareTag("heart"))
        {
            playerStatus.vidaMax += 50; // Aumenta a vida máxima do jogador em 50 unidades
            playerStatus.HP += 50; // Adiciona 50 unidades de vida ao jogador
            Destroy(collision.gameObject); // Destrói o objeto do coração
        }

        // Se colidir com uma poção, aumenta o dano do jogador em 15 e destrói o objeto da poção
        if (collision.gameObject.CompareTag("potion"))
        {
            playerStatus.dmg += 15; // Aumenta o dano do jogador em 15 unidades
            Debug.LogWarning("dano do potion: " + playerStatus.dmg); // Mostra no console o dano atual da poção
            Destroy(collision.gameObject); // Destrói o objeto da poção
        }
    }

    // Método executado quando o jogador para de colidir com outro objeto
    // Se o jogador parou de colidir com um inimigo, permite que o jogador seja danificado novamente
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            playerStatus.canBeDamaged = true;
        }
    }


























}


