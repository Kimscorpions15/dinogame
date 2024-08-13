using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    public float HP, vidaMax = 100f;
    public bool canBeDamaged = true;
    public Image img;
    public float dmgCooldown = 1f;
    public float cooldownTimer = 0;
    // adicionado o dano do jogador
    public int dmg = 10;

    // Start is called before the first frame update
    void Start()
    {
        HP = 100f;
        vidaMax = 100f;
        // inicia com dano de 10
        dmg = 10;
    }

    // Update is called once per frame
    void Update()
    {
        img.fillAmount = HP / vidaMax;
        if (canBeDamaged == true)
        {
            cooldownTimer += Time.deltaTime;
            if (cooldownTimer >= dmgCooldown)
            {
                canBeDamaged = true;
                cooldownTimer = 0f;
            }
        }
    }
}
