using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuController : MonoBehaviour
{
    public void BotonJugar()
    {
        GameStateController.Instance.IniciarNivel(1);
    }

    public void BotonSalir()
    {
        Application.Quit();

        // 2. Esto detiene el modo "Play" si estás dentro del editor de Unity
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    public void ActivarSonido()
    {
        GameStateController.Instance.DesactivarMute();
    }

    public void DesactivarSonido()
    {
        GameStateController.Instance.ActivarMute();
    }
}
