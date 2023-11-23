using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoComTrigger : MonoBehaviour
{
    public GameObject novoObjetoPrefab; // O Prefab do novo objeto
    public float limiteSuperiorX = 10f; // Limite superior da posição X
    public float limiteInferiorX = -10f; // Limite inferior da posição X
    public float limiteSuperiorZ = 10f; // Limite superior da posição Z
    public float limiteInferiorZ = -10f; // Limite inferior da posição Z

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bola")) // Verifica se o objeto que colidiu é a "Bola"
        {
            FindObjectOfType<PontuacaoHUD>().AtualizarPontuacao(1);

            // Salve a rotação do objeto atual
            Quaternion rotacaoAtual = transform.rotation;

            // Destrua o objeto atual
            Destroy(gameObject);

            // Gere um novo objeto em uma posição aleatória
            Vector3 novaPosicao = new Vector3(
                Random.Range(limiteInferiorX, limiteSuperiorX),
                transform.position.y, // Mantenha a mesma altura
                Random.Range(limiteInferiorZ, limiteSuperiorZ)
            );

            // Instancie o novo objeto
            GameObject novoObjeto = Instantiate(novoObjetoPrefab, novaPosicao, Quaternion.identity);

            // Aplique a rotação salva ao novo objeto
            novoObjeto.transform.rotation = rotacaoAtual;
        }
    }
}
