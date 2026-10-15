using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
using UnityEngine.SceneManagement; 

public class FirstPersonController_Simple : MonoBehaviour 
{ 
public float velocidadMovimiento = 5f;   // Velocidad normal 
public float velocidadCarrera = 10f;     // Velocidad al correr (Shift) 
public float velocidadCaminarLento = 2f; // Velocidad al caminar lento (Ctrl) 
public float sensibilidadMouse = 2f;     // Sensibilidad del mouse 
private CharacterController characterController; 
private float velocidadVertical = 0f; 
private int saltosRestantes = 2;         // Para salto + doble salto 
private bool caminarLento = false; 
private void Start() 
{ 
// Accedemos al Character Controller del jugador 
characterController = GetComponent<CharacterController>(); 
// Bloqueamos el cursor para controlar la cámara sin que el mouse salga de la pantalla 
Cursor.lockState = CursorLockMode.Locked; 
} 
void Update() 
{ 
// Movimiento WASD 
float movimientoHorizontal = Input.GetAxis("Horizontal"); 
float movimientoVertical = Input.GetAxis("Vertical"); 
// Movimiento de cámara con el mouse 
float mouseX = Input.GetAxis("Mouse X") * sensibilidadMouse; 
transform.Rotate(Vector3.up * mouseX); 
// Gravedad básica 
if (characterController.isGrounded) 
{ 
velocidadVertical = -0.5f; // Mantenemos al jugador pegado al suelo 
saltosRestantes = 2;       // Se reinicia el doble salto al tocar el suelo 
} 
else 
{ 
velocidadVertical += Physics.gravity.y * Time.deltaTime; 
} 
// Saltar o doble salto 
if (Input.GetButtonDown("Jump") && saltosRestantes > 0) 
{ 
velocidadVertical = Mathf.Sqrt(2f * 3.0f * Mathf.Abs(Physics.gravity.y)); 
saltosRestantes--;   
} 
// Caminar lento (Ctrl) 
caminarLento = Input.GetKey(KeyCode.LeftControl) && characterController.isGrounded; 
// Elegir velocidad según input 
float currentSpeed = caminarLento  
? velocidadCaminarLento  
: (Input.GetKey(KeyCode.LeftShift) ? velocidadCarrera : velocidadMovimiento); 
// Combinar direcciones según dónde mira el jugador 
Vector3 movimiento =  
(transform.forward * movimientoVertical + 
transform.right * movimientoHorizontal) * currentSpeed; 
// Agregar gravedad/saltos 
movimiento.y = velocidadVertical; 
// Aplicar movimiento 
characterController.Move(movimiento * Time.deltaTime); 
}

void OnControllerColliderHit(ControllerColliderHit hit) {
    if(hit.gameObject.tag == "Peligro") {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

} 