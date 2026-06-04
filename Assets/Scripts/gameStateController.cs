using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStateController : MonoBehaviour
{
    public static GameStateController Instance { get; private set; }

    public int nivelActual = 1;
    public float tiempoDelNivel = 0f;
    private bool cronometroActivo = false;

    private GameObject panelPausaLocal; 
    private bool juegoPausado = false;
    public bool fuegoListo = false;
    public bool aguaListo = false;

    public int gemasRecogidas_Fuego = 0;
    public int gemasRecogidas_Agua = 0;
    private bool estaMuteado = false;

    public void RegistrarPanelPausa(GameObject panel)
    {
        panelPausaLocal = panel;
        panelPausaLocal.SetActive(false);
        juegoPausado = false;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
            AplicarEstadoAudio();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (cronometroActivo)
        {
            tiempoDelNivel += Time.deltaTime;
        }
    }

    public void ActivarMute()
    {
        if (!estaMuteado)
        {
            estaMuteado = true;
            AplicarEstadoAudio();
        }
    }

    public void DesactivarMute()
    {
        if (estaMuteado)
        {
            estaMuteado = false;
            AplicarEstadoAudio();
        }
    }

    private void AplicarEstadoAudio()
    {
        AudioListener.pause = estaMuteado;
    }

    public void IniciarNivel(int numeroNivel)
    {
        nivelActual = numeroNivel;
        tiempoDelNivel = 0f; 
        cronometroActivo = true;
        juegoPausado = false;
        Time.timeScale = 1f;
        gemasRecogidas_Fuego = 0;
        gemasRecogidas_Agua = 0;
        fuegoListo = false;
        aguaListo = false;
        if (panelPausaLocal != null)
            panelPausaLocal.SetActive(false);
        SceneManager.LoadScene("Nivel " + nivelActual); 
    }

    public void ReiniciarNivelActual()
    {
        tiempoDelNivel = 0f; 
        cronometroActivo = true;
        juegoPausado = false;
        Time.timeScale = 1f; // Asegurar que el tiempo fluye
        gemasRecogidas_Fuego = 0;
        gemasRecogidas_Agua = 0;
        fuegoListo = false;
        aguaListo = false;
        if (panelPausaLocal != null)
            panelPausaLocal.SetActive(false);
        SceneManager.LoadScene("Nivel " + nivelActual);
    }

    public string ObtenerTiempoFormateado()
    {
        int minutos = Mathf.FloorToInt(tiempoDelNivel / 60);
        int segundos = Mathf.FloorToInt(tiempoDelNivel % 60);
        return string.Format("{0:00}:{1:00}", minutos, segundos);
    }

    public void TerminarNivel()
    {
        cronometroActivo = false;
        juegoPausado = false;
        Time.timeScale = 1f; 
        SceneManager.LoadScene("Next Level"); 
    }

    public void AvanzarSiguienteNivel()
    {
        nivelActual++;
        
        if (nivelActual > 2)
        {
            Debug.Log("¡Juego completado! Volviendo al menú principal...");
            Time.timeScale = 1f;
            SceneManager.LoadScene("Main Menu");
            return;
        }
        
        Debug.Log($"Cargando Nivel {nivelActual}...");
        IniciarNivel(nivelActual);
    }

    public void PausarNivel()
    {
        if (!juegoPausado)
        {
            juegoPausado = true;
            cronometroActivo = false;
            Time.timeScale = 0f; 
            if (panelPausaLocal != null)
                panelPausaLocal.SetActive(true);
        }
    }

    public void ReanudarNivel()
    {
        if (juegoPausado)
        {
            juegoPausado = false;
            cronometroActivo = true;
            Time.timeScale = 1f; 
            if (panelPausaLocal != null)
                panelPausaLocal.SetActive(false);
        }
    }

    public void VolverAlMenuPrincipal()
    {
        cronometroActivo = false;
        juegoPausado = false;
        Time.timeScale = 1f; 
        SceneManager.LoadScene("Main Menu");
    }

    public void RegistrarGema_Fuego()
    {
        gemasRecogidas_Fuego++;
    }

    public void RegistrarGema_Agua()
    {
        gemasRecogidas_Agua++;
    }

    public int ObtenerGemasTotal()
    {
        return gemasRecogidas_Fuego + gemasRecogidas_Agua;
    }

    public void VerificarNivelCompletado()
    {
        if (fuegoListo && aguaListo)
        {
            TerminarNivel();
        }
    }

    public void gameOver()
    {
        cronometroActivo = false;
        juegoPausado = false;
        Time.timeScale = 1f; // Asegurar que el tiempo fluye en game over
        SceneManager.LoadScene("Game Over");
    }
}