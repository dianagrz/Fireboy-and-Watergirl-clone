using UnityEngine;
using UnityEngine.SceneManagement;

public class Fuego : MonoBehaviour
{
    private GameStateController gameStateController;
    private Rigidbody2D rb;
    private float dx = 0f;
    private float moveSpeed = 4.5f;  
    private float jumpForce = 7f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameStateController = GameStateController.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        dx = Input.GetAxisRaw("Horizontal_fuego");
        rb.linearVelocity = new Vector2(dx * moveSpeed, rb.linearVelocityY);  

        if (Input.GetKeyDown("up"))
            {
                rb.linearVelocity = new Vector2(rb.linearVelocityX, jumpForce);
            }

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        // Verificamos si el objeto que atravesamos tiene la etiqueta "Recompensa"
        if (collider.CompareTag("Diamante rojo"))
        {
            Destroy(collider.gameObject);
            gameStateController.RegistrarGema_Fuego();
        } 
        else if (collider.CompareTag("Lava verde") 
                || collider.CompareTag("Lava azul") 
                || collider.CompareTag("picos"))
        {
            gameStateController.gameOver();
        }
    }
}
