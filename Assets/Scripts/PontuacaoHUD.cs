using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PontuacaoHUD : MonoBehaviour
{
    public TextMeshProUGUI textoPontuacao; // Referência ao objeto de texto que exibirá a pontuação
    private int pontuacao = 0; // Pontuação inicial

    void Start()
    {
        // Atualize o texto da UI com a pontuação inicial
        AtualizarPontuacaoUI();
    }

    public void AtualizarPontuacao(int pontos)
    {
        // Atualize a pontuação e, em seguida, atualize a UI
        pontuacao += pontos;
        AtualizarPontuacaoUI();
    }

    void AtualizarPontuacaoUI()
    {
        // Atualize o texto da UI com a pontuação atual
        textoPontuacao.text = "Pontuação: " + pontuacao;
    }
}
