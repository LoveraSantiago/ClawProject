using System.Collections.Generic;
using UnityEngine;

public class ControleObstaculos 
{
    public Dictionary<int, Dictionary<int, bool>> dicionarioEstadosGaiola;
    private ReferenciasDoBoardObstaculo referencias;

    public ControleObstaculos(ReferenciasDoBoardObstaculo referencias)
    {
        this.referencias = referencias;
        inicializarDicionarioEstados(referencias.dicionarioGosGaiolas.Count, referencias.dicionarioGosGaiolas[0].Count);
    }

    public void processarObstaculo(PosicaoMira posicaoMira)
    {
        Dictionary<int, bool> dicionarioLinha = dicionarioEstadosGaiola[posicaoMira.linha];
        bool estado = dicionarioLinha[posicaoMira.coluna];
        bool estadoAtual = !estado;

        dicionarioLinha[posicaoMira.coluna] = estadoAtual;

        Dictionary<int, GameObject> dicionarioGosGaiolaLinha = referencias.dicionarioGosGaiolas[posicaoMira.linha];
        GameObject goGaiola = dicionarioGosGaiolaLinha[posicaoMira.coluna];
        if (estadoAtual)
        {
            goGaiola.SetActive(true);
        }
        else
        {
            goGaiola.SetActive(false);
        }
    }

    private void inicializarDicionarioEstados(int qtdLinhas, int qtdColunas)
    {
        dicionarioEstadosGaiola = new Dictionary<int, Dictionary<int, bool>>();
        for(int contadorLinha = 0; contadorLinha < qtdLinhas; contadorLinha++)
        {
            Dictionary<int, bool> dicionarioEstadoColuna = new Dictionary<int, bool>();
            for(int contadorColuna = 0; contadorColuna < qtdColunas; contadorColuna++)
            {
                dicionarioEstadoColuna.Add(contadorColuna, false);
            }
            dicionarioEstadosGaiola.Add(contadorLinha, dicionarioEstadoColuna);
        }
    }
}
