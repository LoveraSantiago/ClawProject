using UnityEngine;

public abstract class ComponenteAnimacaoDeColetavel : GO
{
    private static readonly int ESTADO_NORMAL = 0;
    private static readonly int ESTADO_MIRA_SELECIONADA = 1;
    private static readonly int ESTADO_OVO = 2;

    private int estadoAtual;
    private ColetavelAnimacao animacao;

    public ComponenteAnimacaoDeColetavel(GOContexto contextoGO,
              Transformador<GameObject, SpriteRenderer> getGoComSprRenderer,
              string nome)
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
        animacao.ligarMira();
        estadoAtual = ESTADO_NORMAL;        
    }

    public void ligarAnimacaoMiraSelecionado()
    {
        animacao.ligarMiraSelecionada();
        estadoAtual = ESTADO_MIRA_SELECIONADA;        
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

    public void desligarAnimacao()
    {
        animacao.desligar();
        estadoAtual = ESTADO_NORMAL;        
    }

    public bool isMiraSelecionada()
    {
        return estadoAtual == ESTADO_MIRA_SELECIONADA;
    }

    public bool isOvo()
    {
        return estadoAtual == ESTADO_OVO;
    }

    private void iniciarColetavelAnimacao()
    {
        Animator animator = extrairComponente<Animator>();
        animacao = new ColetavelAnimacao(animator);
    }
}
