using UnityEngine;
using TMPro;

public class nextLevelController : MonoBehaviour
{
    public TMP_Text textoTiempo;
    public TMP_Text textoGemas;

    void Start()
    {
        float tiempoFinal = GameStateController.Instance.tiempoDelNivel;
        int gemasRecogidas = GameStateController.Instance.gemasRecogidas_Agua
                             + GameStateController.Instance.gemasRecogidas_Fuego;
        textoGemas.text = gemasRecogidas.ToString() + "/12";

        int minutos = Mathf.FloorToInt(tiempoFinal / 60);
        int segundos = Mathf.FloorToInt(tiempoFinal % 60);

        textoTiempo.text = string.Format("{0:00}:{1:00}", minutos, segundos);
    }
    public void siguienteNivel()
    {
        GameStateController.Instance.AvanzarSiguienteNivel();
    } 

    public void volverMenu()
    {
        GameStateController.Instance.VolverAlMenuPrincipal();
    }

    public void reiniciarNivel()
    {
        GameStateController.Instance.ReiniciarNivelActual();
    }

}
