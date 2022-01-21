using System.Collections.Generic;

public class ControleObstaculos 
{
    public Dictionary<int, Dictionary<int, bool>> dicionarioEstadosGaiola;
    private ReferenciasDoBoardObstaculo referencias;

    public ControleObstaculos(ReferenciasDoBoardObstaculo referencias)
    {
        this.referencias = referencias;
        inicializarDicionarioEstados();
    }

    public void processarObstaculo(PosicaoMira posicaoMira)
    {
        Dictionary<int, bool> dicionarioLinha = dicionarioEstadosGaiola[posicaoMira.linha];
        bool estado = dicionarioLinha[posicaoMira.coluna];
        bool estadoAtual = !estado;

        dicionarioLinha[posicaoMira.coluna] = estadoAtual;        
        if (estadoAtual)
        {
            referencias.updateElementoGaiola(posicaoMira.linha, posicaoMira.coluna, true);            
        }
        else
        {
            referencias.updateElementoGaiola(posicaoMira.linha, posicaoMira.coluna, false);            
        }
    }

    private void inicializarDicionarioEstados()
    {
        int qtdLinhas = referencias.getQtdLinhasDoBoard();
        int qtdColunas = referencias.getQtdColunasDoBoard(0);

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
