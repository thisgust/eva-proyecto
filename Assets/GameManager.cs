
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    int monedas = 0;

    public TextMeshProUGUI textoMonedas;
    public GameObject textoVictoria;

    void Start()
    {
        textoMonedas.text = "Cantidad: " + monedas.ToString();
    }

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {

    }

    public void AñadirMonedas(int cantidad)
    {
        monedas += cantidad;
        textoMonedas.text = "Cantidad: " + monedas.ToString();

        if (monedas >= 3)
        {
            textoVictoria.SetActive(true);
        }
    }
}
