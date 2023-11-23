using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Arremesso : MonoBehaviour
{
    public Camera mainCamera; // Referência à câmera principal
    public GameObject bolaPrefab; // Prefab da bolinha a ser arremessada
    public float forcaArremesso = 10.0f; // Força do arremesso

    private bool arremessando = false;
    private GameObject bolaAtual;
    public float sensitivity = 2.0f;
    private Vector2 currentRotation = Vector2.zero;

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Aplica rotação na câmera e no jogador na horizontal e vertical
        currentRotation.y += mouseX * sensitivity;
        currentRotation.x -= mouseY * sensitivity;

        // Limita a rotação vertical para evitar inversões
        currentRotation.x = Mathf.Clamp(currentRotation.x, -90, 90);

        // Aplica a rotação na câmera na vertical
        transform.localRotation = Quaternion.Euler(currentRotation.x, currentRotation.y, 0);
        
        if (Input.GetMouseButtonDown(0) && !arremessando)
        {
            // Verifique se o botão do mouse foi pressionado e não estamos arremessando uma bola atualmente.
            IniciarArremesso();
        }

        if (Input.GetMouseButtonUp(0) && arremessando)
        {
            // Verifique se o botão do mouse foi solto e estávamos arremessando.
            FinalizarArremesso();
        }
    }

    void IniciarArremesso()
    {
        // Crie uma nova bola a partir do prefab.
        bolaAtual = Instantiate(bolaPrefab, transform.position, Quaternion.identity);
        arremessando = true;
    }

    void FinalizarArremesso()
    {
        if (bolaAtual != null)
        {
            // Determine a direção do arremesso com base na posição da câmera e da bola.
            Vector3 direcaoArremesso = (mainCamera.transform.forward).normalized;

            // Aplique a força ao Rigidbody da bola.
            Rigidbody rb = bolaAtual.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.AddForce(direcaoArremesso * forcaArremesso, ForceMode.Impulse);

            // Defina a bola atual como nula e permita outro arremesso.
            bolaAtual = null;
            arremessando = false;
        }
    }
}
