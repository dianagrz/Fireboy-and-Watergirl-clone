using UnityEngine;

public class puerta : MonoBehaviour
{
   public string personaje;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (string.IsNullOrEmpty(personaje))
        {
            Debug.LogError($"{name}: el campo 'personaje' no está asignado en Inspector.");
            return;
        }

        if (other.CompareTag(personaje))
        {
            ActualizarEstado(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (string.IsNullOrEmpty(personaje))
        {
            Debug.LogError($"{name}: el campo 'personaje' no está asignado en Inspector.");
            return;
        }

        if (other.CompareTag(personaje))
        {
            ActualizarEstado(false);
        }
    }

    private void ActualizarEstado(bool estaDentro)
    {

        if (personaje == "fireboy")
        {
            GameStateController.Instance.fuegoListo = estaDentro;
            Debug.Log($"Fuego {(estaDentro ? "dentro" : "fuera")} de la puerta. fuegoListo = {GameStateController.Instance.fuegoListo}");
        }
        else if (personaje == "watergirl")
        {
            GameStateController.Instance.aguaListo = estaDentro;
            Debug.Log($"Agua {(estaDentro ? "dentro" : "fuera")} de la puerta. aguaListo = {GameStateController.Instance.aguaListo}");
        }
        
        GameStateController.Instance.VerificarNivelCompletado();
    }
}
