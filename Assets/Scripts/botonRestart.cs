using UnityEngine;
using UnityEngine.SceneManagement;

public class botonRestart : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BotonReintentar()
    {
        var gameState = GameStateController.Instance;
        if (gameState != null)
        {
            gameState.ReiniciarNivelActual();
            return;
        }

        Debug.LogError("GameStateController.Instance is null — falling back to reloading current scene.");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
