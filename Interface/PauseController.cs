using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public Button pauseButton;


    private bool isPaused = false;

    void Start()
    {
        // Garantir que o menu de pausa esteja oculto no início
        pauseMenuUI.SetActive(false);

        // Configurar o evento onClick do botão de pausa
        pauseButton.onClick.AddListener(TogglePause);


    }

    void Update()
    {
        // Verificar se a tecla ESC foi pressionada
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            // Pausar o jogo
            Time.timeScale = 0f;
            pauseMenuUI.SetActive(true);
        }
        else
        {
            // Despausar o jogo
            Time.timeScale = 1f;
            pauseMenuUI.SetActive(false);
        }
    }

}
