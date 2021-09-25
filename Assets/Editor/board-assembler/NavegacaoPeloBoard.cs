using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class NavegacaoPeloBoard 
{
    private int linhaAtual;
    private int colunaAtual;

    private ReferenciasDoBoardAssembler referencias;   

    public NavegacaoPeloBoard(VisualElement root, ReferenciasDoBoardAssembler referencias)        
    {
        this.referencias = referencias;        
        configurarBotoes(root);
    }    

    private void configurarBotoes(VisualElement root)
    {
        UnityEngine.UIElements.Button btnCima = root.Q<UnityEngine.UIElements.Button>("botaoCima");
        btnCima.clickable.clicked += () =>
        {
            if (podeDescerUmaLinha())
            {
                linhaAtual++;
            }
            posicionarMira(linhaAtual, colunaAtual);
        };

        UnityEngine.UIElements.Button btnEsquerda = root.Q<UnityEngine.UIElements.Button>("botaoEsquerda");
        btnEsquerda.clickable.clicked += () =>
        {
            if (podeVoltarUmaColuna())
            {
                colunaAtual--;
            }

            posicionarMira(linhaAtual, colunaAtual);
        };

        UnityEngine.UIElements.Button btnDireita = root.Q<UnityEngine.UIElements.Button>("botaoDireita");
        btnDireita.clickable.clicked += () =>
        {
            if (podeAndarUmaColuna())
            {
                colunaAtual++;
            }
            posicionarMira(linhaAtual, colunaAtual);
        };

        UnityEngine.UIElements.Button btnBaixo = root.Q<UnityEngine.UIElements.Button>("botaoBaixo");
        btnBaixo.clickable.clicked += () =>
        {
            if (podeAndarUmaLinha())
            {
                linhaAtual--;
            }
            posicionarMira(linhaAtual, colunaAtual);
        };
    }

    private bool podeAndarUmaColuna()
    {
        bool resultProximaColuna = colunaAtual + 1 < referencias.dicionarioGosBoard[linhaAtual].Count;
        bool resultPos7Par = (linhaAtual % 2 != 0) && colunaAtual + 1 == 6;
        return resultProximaColuna && !resultPos7Par;
    }

    private bool podeVoltarUmaColuna()
    {
        return colunaAtual - 1 >= 0;
    }

    private bool podeAndarUmaLinha()
    {
        bool resultProximaLinha = linhaAtual - 1 >= 0;
        bool resultPos7Par = ((linhaAtual - 1) % 2 != 0) && colunaAtual == 6;
        return resultProximaLinha && !resultPos7Par;
    }

    private bool podeDescerUmaLinha()
    {
        bool resultProximaLinha = linhaAtual + 1 < referencias.dicionarioGosBoard.Count;        
        bool resultPos7Par = ((linhaAtual + 1) % 2 != 0) && colunaAtual == 6;
        return resultProximaLinha && !resultPos7Par;
    }

    private void posicionarMira(int linha, int coluna)
    {
        GameObject go00 = referencias.dicionarioGosBoard[linha][coluna];
        referencias.goMira.transform.position = go00.transform.position;
    }

    public void resetMira()
    {
        posicionarMira(0, 0);
        linhaAtual = 0;
        colunaAtual = 0;
    }

    public GameObject getGoDaMira()
    {
        return referencias.dicionarioGosBoard[linhaAtual][colunaAtual];
    }

    public Text getTextDaMira()
    {
        return referencias.dicionarioTextLabels[linhaAtual][colunaAtual];
    }

    public void navegarCimaTotal()
    {
        linhaAtual = referencias.dicionarioGosBoard.Count - 1;
        posicionarMira(linhaAtual, colunaAtual);
    }

    public void navegarBaixoTotal()
    {
        linhaAtual = 0;
        posicionarMira(linhaAtual, colunaAtual);
    }

    public void navegarTrasTotal()
    {
        colunaAtual = 0;
        posicionarMira(linhaAtual, colunaAtual);
    }

    public void navegarFrenteTotal()
    {
        colunaAtual = referencias.dicionarioGosBoard[linhaAtual].Count - 1;
        posicionarMira(linhaAtual, colunaAtual);
    }
}
