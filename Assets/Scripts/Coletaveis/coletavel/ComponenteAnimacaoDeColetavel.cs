using UnityEngine;

public abstract class ComponenteAnimacaoDeColetavel : GO
{
    private static readonly int ESTADO_NORMAL = 0;
    private static readonly int ESTADO_MIRA_SELECIONADA_NORMAL = 1;
    private static readonly int ESTADO_OVO = 2;
    private static readonly int ESTADO_MIRA_SELECIONADA_OVO = 3;

    private int estadoAtual;
    private ColetavelAnimacao animacao;

    public ComponenteAnimacaoDeColetavel(
        GOContexto contextoGO, Transformador<GameObject, SpriteRenderer> getGoComSprRenderer, string nome)
        : base(contextoGO, getGoComSprRenderer, nome)
    {
        iniciarColetavelAnimacao();
    }

    public ComponenteAnimacaoDeColetavel(Transform transform)
        : base(transform)
    {
        iniciarColetavelAnimacao();
    }    

    public void ligarAnimacaoMira()
    {
        if(estadoAtual == ESTADO_OVO)
        {
            animacao.ligarMiraOnOvo();
        }
        else
        {
            animacao.ligarMira();            
        }
    }

    public void ligarAnimacaoMiraSelecionado()
    {
        if(estadoAtual == ESTADO_OVO)
        {
            animacao.ligarMiraSelecionadaOnOvo();
            estadoAtual = ESTADO_MIRA_SELECIONADA_OVO;
        }
        else
        {
            animacao.ligarMiraSelecionada();
            estadoAtual = ESTADO_MIRA_SELECIONADA_NORMAL;
        }
    }

    public void ligarAnimacaoFecharOvo()
    {
        animacao.fecharOvo();
        estadoAtual = ESTADO_OVO;
    }

    public void ligarAnimacaoAbrirOvo()
    {
        animacao.abrirOvo();
        estadoAtual = ESTADO_NORMAL;
    }

    public void ligarAnimacaoIdle()
    {
        if(estadoAtual == ESTADO_MIRA_SELECIONADA_OVO || estadoAtual == ESTADO_OVO)
        {
            animacao.idleOvo();
            estadoAtual = ESTADO_OVO;
        }
        else
        {
            animacao.idle();
            estadoAtual = ESTADO_NORMAL;        
        }
    }

    public bool isMiraSelecionada()
    {
        return estadoAtual == ESTADO_MIRA_SELECIONADA_NORMAL ||
               estadoAtual == ESTADO_MIRA_SELECIONADA_OVO;
    }

    public bool isOvo()
    {
        return estadoAtual == ESTADO_OVO || estadoAtual == ESTADO_MIRA_SELECIONADA_OVO;
    }

    private void iniciarColetavelAnimacao()
    {
        Animator animator = extrairComponente<Animator>();
        animacao = new ColetavelAnimacao(animator);
    }
}
