using UnityEngine;
using UnityEngine.UIElements;

public abstract class NavegacaoPeloBoard
{
    protected int linhaAtual;
    protected int colunaAtual;

    private ReferenciasDoBoard referencias;

    public NavegacaoPeloBoard(VisualElement root, ReferenciasDoBoard referencias)
    {
        this.referencias = referencias;
        configurarBotoes(root);
    }

    protected abstract string getNomeBtnIrParaCima();
    protected abstract string getNomeBtnIrParaBaixo();
    protected abstract bool isLinhaMenor(int value);

    public void resetMira()
    {
        posicionarMira(0, 0);
        linhaAtual = 0;
        colunaAtual = 0;
    }    

    public PosicaoMira getPosicaoDaMira()
    {
        return new PosicaoMira(linhaAtual, colunaAtual);
    }

    public void navegarCimaTotal()
    {
        linhaAtual = referencias.getQtdLinhasGos() - 1;
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
        if (isLinhaMenor(linhaAtual))
        {
            colunaAtual = referencias.getQtdColunasDaLinha(linhaAtual) - 2;
        }
        else
        {
            colunaAtual = referencias.getQtdColunasDaLinha(linhaAtual) - 1;
        }
        posicionarMira(linhaAtual, colunaAtual);
    }

    private void configurarBotoes(VisualElement root)
    {
        UnityEngine.UIElements.Button btnCima = root.Q<UnityEngine.UIElements.Button>(getNomeBtnIrParaCima());
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

        UnityEngine.UIElements.Button btnBaixo = root.Q<UnityEngine.UIElements.Button>(getNomeBtnIrParaBaixo());
        btnBaixo.clickable.clicked += () =>
        {
            if (podeAndarUmaLinha())
            {
                linhaAtual--;
            }
            posicionarMira(linhaAtual, colunaAtual);
        };
    }

    protected bool isImpar(int valor)
    {
        return valor % 2 != 0;
    }

    protected bool isPar(int valor)
    {
        return valor % 2 == 0;
    }

    private bool podeAndarUmaColuna()
    {
        bool resultProximaColuna = colunaAtual + 1 < referencias.getQtdColunasDaLinha(linhaAtual);        
        bool resultPos7Par = isLinhaMenor(linhaAtual) && colunaAtual + 1 == 6;
        return resultProximaColuna && !resultPos7Par;
    } 

    private bool podeVoltarUmaColuna()
    {
        return colunaAtual - 1 >= 0;
    }

    private bool podeAndarUmaLinha()
    {
        bool resultProximaLinha = linhaAtual - 1 >= 0;        
        bool resultPos7Par = isLinhaMenor(linhaAtual - 1) && colunaAtual == 6;
        return resultProximaLinha && !resultPos7Par;
    }

    private bool podeDescerUmaLinha()
    {
        bool resultProximaLinha = linhaAtual + 1 < referencias.getQtdLinhasGos();        
        bool resultPos7Par = isLinhaMenor(linhaAtual + 1) && colunaAtual == 6;
        return resultProximaLinha && !resultPos7Par;
    }

    private void posicionarMira(int linha, int coluna)
    {        
        Vector3 posicao = referencias.getPosicaoElemento(linha, coluna);
        referencias.goMira.transform.position = posicao;
    }   
}
