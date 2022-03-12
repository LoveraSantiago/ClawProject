using UnityEngine;

public abstract class ComponenteAnimacaoDeColetavel : GO
{
    private ColetavelAnimacao animacao;
    public bool isMiraSelecionada { get; private set; }

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
        isMiraSelecionada = false;
    }

    public void ligarAnimacaoMiraSelecionado()
    {
        animacao.ligarMiraSelecionada();
        isMiraSelecionada = true;
    }

    public void desligarAnimacao()
    {
        animacao.desligar();
        isMiraSelecionada = false;
    }

    private void iniciarColetavelAnimacao()
    {
        Animator animator = extrairComponente<Animator>();
        animacao = new ColetavelAnimacao(animator);
    }
}
