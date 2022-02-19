using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuracoNegroPowerUpGo : PowerUpSemInteracao,
                                    Transformador<TrioDeColetaveis, IEnumerator>
{
    public Coletavel atraido1;
    public Coletavel atraido2;
    public Coletavel atraido3;

    private Coroutine coroutine;

    public BuracoNegroPowerUpGo() : 
        base(powerUpDto.BuracoNegroDto.BuracoNegroGo, "Buraco Negro"){}

    public override void configurarPup()
    {
        Transform transform = goColetavel.transform.Find("atraido1").transform;
        atraido1 = new Coletavel(transform.gameObject, "atraido1");

        Transform transform2 = goColetavel.transform.Find("atraido2").transform;
        atraido2 = new Coletavel(transform2.gameObject, "atraido2");

        Transform transform3 = goColetavel.transform.Find("atraido3").transform;
        atraido3 = new Coletavel(transform3.gameObject, "atraido3");
    }

    public override void iniciarPup()
    {
        ligar();

        int totalDesocupados = 3 - informacaoDisplayColetado.getQtdDisplaysOcupados();

        HelperColetaveisInGame helperInGame = new HelperColetaveisInGame();
        helperInGame.ligarMirasNosColetaveis();

        AteTresAlvosSelecionados alvosSelecionados = new AteTresAlvosSelecionados(totalDesocupados);
        coroutine = Utils.MonoBehaviour.StartCoroutine(alvosSelecionados.onSelecionado(inputGame, this));
    }

    public override void resetPup()
    {
        atraido1.desligar();
        atraido2.desligar();
        atraido3.desligar();
    }

    public IEnumerator transformar(TrioDeColetaveis trioDeColetaveis)
    {
        yield return new WaitForSeconds(1);

        ligarColetavelAtraido(atraido1, trioDeColetaveis.coletavel1);
        ligarColetavelAtraido(atraido2, trioDeColetaveis.coletavel2);
        ligarColetavelAtraido(atraido3, trioDeColetaveis.coletavel3);

        yield return null;   
    }

    private void ligarColetavelAtraido(Coletavel coletavelAtracao, Coletavel coletavelSelecionado)
    {
        if(coletavelSelecionado != null)
        {
            coletavelAtracao.colocarNaPosicao(coletavelSelecionado.getPosicao());
            coletavelAtracao.receberSprite(coletavelSelecionado.getSprite());
            coletavelAtracao.ligar();

            coletavelSelecionado.desligar();
        }
    }
}
