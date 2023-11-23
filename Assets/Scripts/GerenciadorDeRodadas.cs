using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GerenciadorDeRodadas : MonoBehaviour
{
    public TextMeshProUGUI textoTempoRestante; // Referência ao objeto de texto para exibir o tempo restante
    private float tempoRodada = 60f; // Duração da rodada em segundos
    private float tempoRestante;
    private int pontuacao = 0;
    private bool emRodada = false;

    void Start()
    {
        IniciarNovaRodada();
    }

    void Update()
    {

        if (emRodada) {
            tempoRestante -= Time.deltaTime;
            AtualizarTempoRestante();
            if (tempoRestante <= 0) {
                TerminarRodada();
            }
        }

        if (!emRodada && Input.GetKeyDown(KeyCode.Return)) {
            IniciarNovaRodada();
        }

    }

    void IniciarNovaRodada()
    {
        emRodada = true;
        tempoRestante = tempoRodada;
        pontuacao = 0;
        AtualizarTempoRestante();
    }

    void TerminarRodada()
    {
        // Aqui você pode adicionar lógica para encerrar a rodada, calcular pontuações finais, etc.
        // fimDaRodada.text = "Fim da Rodada! Pontuação final: " + pontuacao;
        Debug.Log("Fim da Rodada! Pontuação final: " + pontuacao);
        emRodada = false;
    }

    void AtualizarTempoRestante()
    {
        int minutos = Mathf.FloorToInt(tempoRestante / 60);
        int segundos = Mathf.FloorToInt(tempoRestante % 60);
        textoTempoRestante.text = string.Format("Tempo Restante: {0:00}:{1:00}", minutos, segundos);
    }
}
