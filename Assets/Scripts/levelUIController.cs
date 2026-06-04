using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class levelUIController : MonoBehaviour
{
    public GameObject pausePanel;
    public TMP_Text textoTiempo;
    
    void Start()
    {
        // Registrar el panel de pausa en el GameStateController
        if (pausePanel != null)
        {
            GameStateController.Instance.RegistrarPanelPausa(pausePanel);
        }

        if (textoTiempo != null && GameStateController.Instance != null)
        {
            textoTiempo.text = GameStateController.Instance.ObtenerTiempoFormateado();
        }
    }

    void Update()
    {
        if (textoTiempo != null && GameStateController.Instance != null)
        {
            textoTiempo.text = GameStateController.Instance.ObtenerTiempoFormateado();
        }
    }

    public void BotonPausar()
    {
        GameStateController.Instance.PausarNivel();
    }

    public void BotonReanudar()
    {
        GameStateController.Instance.ReanudarNivel();
    }

    public void BotonReintentar()
    {
        GameStateController.Instance.ReiniciarNivelActual();
    }
}
