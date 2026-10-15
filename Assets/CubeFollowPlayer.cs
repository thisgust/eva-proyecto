using UnityEngine; 


public class CubeFollowPlayer : MonoBehaviour { 
    public float moveSpeed = 5f; 
    private Transform playerTransform; 

    private void Start() { 
        GameObject player = GameObject.FindGameObjectWithTag("Player"); 
        if (player != null) playerTransform = player.transform; 
        else Debug.LogError("No se encontró el objeto con el tag 'Player'. Asigna el tag 'Player' al objeto del jugador."); 
    }

    private void Update() { 
        if (playerTransform != null) { 
            Vector3 directionToPlayer =  (playerTransform.position - transform.position).normalized; 
            transform.Translate(directionToPlayer * moveSpeed * Time.deltaTime); 
        } 
    } 
}