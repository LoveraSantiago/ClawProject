using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModalResultados 
{
    private ModalPontosDto modalPontosDto;
    private LinhaModalPontos[] linhasModal;

    public ModalResultados(string levelName, ModalPontosDto modalPontosDto)
    {
        this.modalPontosDto = modalPontosDto;
        setNivel(levelName);

        linhasModal = new LinhaModalPontos[modalPontosDto.Linhas.Length];
        for (int contador = 0; contador < linhasModal.Length; contador++)
        {
            linhasModal[contador] = new LinhaModalPontos(modalPontosDto.Linhas[contador]);
        }
    }

    private void setNivel(string levelName)
    {
        modalPontosDto.TextoNivel.text = levelName;
    }

    public void configurarResultado()
    {
        naoMostrarLinhasResult();

        AbstractModalFim modalFim = new ModalFimPontos();
        modalFim.configurarBotaoAvancar(modalPontosDto.BtnAvancar);
    }

    public void configurarResultadoPup()
    {
        AbstractModalFim modalFim = new ModalFimPup();
        modalFim.configurarBotaoAvancar(modalPontosDto.BtnAvancar);
    }

    public void configurarResultadoColetavel()
    {
        AbstractModalFim modalFim = new ModalFimColetaveis();
        modalFim.configurarBotaoAvancar(modalPontosDto.BtnAvancar);
    }

    public void ligar()
    {
        modalPontosDto.GoModalPontos.SetActive(true);
    }

    public void setScoreAtual(string scoreAtual)
    {
        modalPontosDto.TextoPontos.text = scoreAtual;
    }

    private void naoMostrarLinhasResult()
    {
        linhasModal[0].desligar();
        linhasModal[1].desligar();
        linhasModal[2].desligar();
        linhasModal[3].desligar();
    }
}
