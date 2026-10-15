using UnityEngine;
using TMPro;

public class AgarrarMoneda : MonoBehaviour
{
    public TextMeshProUGUI textoMonedas;

    // Este método se llama cuando un objeto entra en el área de colisión de la moneda
    private void OnTriggerEnter(Collider other)
    {   
            // Desaparecer la moneda haciendo que su GameObject esté inactivo
            GameManager.Instance.AñadirMonedas(1);
            gameObject.SetActive(false);

    }
}