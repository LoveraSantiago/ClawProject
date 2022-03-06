using System.Collections;
using UnityEngine;

public class BuracoNegroPowerUpGo : PowerUpSemInteracao,
                                    Transformador<TrioDeColetaveis, IEnumerator>
{
    private bool delayTresOcupados;
    private bool preFinalizadoJaAcionado;
    private bool alvosSelecionados;

    public Coletavel atraido1;
    public Coletavel atraido2;
    public Coletavel atraido3;

    private Coroutine coroutine;

    public BuracoNegroPowerUpGo() : 
        base(powerUpDto.BuracoNegroDto.BuracoNegroGo, "Buraco Negro"){}

    public override void configurarPup()
    {
        Transform transform1 = extrairTransform("atraido1");
        atraido1 = new Coletavel(transform1);

        Transform transform2 = extrairTransform("atraido2");
        atraido2 = new Coletavel(transform2);        

        Transform transform3 = extrairTransform("atraido3");
        atraido3 = new Coletavel(transform3);        
    }

    public override void iniciarPup()
    {
        ligar();

        int totalDesocupados = 3 - informacaoDisplayColetado.getQtdDisplaysOcupados();
        if(totalDesocupados == 0)
        {
            delayTresOcupados = true;
            totalDesocupados = 3;
        }

        HelperColetaveisInGame helperInGame = new HelperColetaveisInGame();
        helperInGame.ligarMirasNosColetaveis(true);

        AteTresAlvosSelecionados alvosSelecionados = new AteTresAlvosSelecionados(totalDesocupados);
        coroutine = Utils.MonoBehaviour.StartCoroutine(alvosSelecionados.onSelecionado(true, inputGame, this));
    }

    public override void resetPup()
    {
        atraido1.desligar();
        atraido2.desligar();
        atraido3.desligar();

        desligar();
        delayTresOcupados = false;
        alvosSelecionados = false;
    }

    public IEnumerator transformar(TrioDeColetaveis trioDeColetaveis)
    {
        alvosSelecionados = true;

        yield return new WaitForSeconds(0.5f);
        if (delayTresOcupados)
        {
            yield return new WaitForSeconds(1f);
        }

        ligarColetavelAtraido(atraido1, trioDeColetaveis.coletavel1);
        ligarColetavelAtraido(atraido2, trioDeColetaveis.coletavel2);
        ligarColetavelAtraido(atraido3, trioDeColetaveis.coletavel3);
        
        while (!isTodosColetados(trioDeColetaveis))
        {
            preFinalizadoJaAcionado = false;
            yield return new WaitForSeconds(0.5f);
        }

        powerUpFinalizacao.finalizado();
        resetPup();
        yield return null;   
    }    

    public bool isTodosColetados(TrioDeColetaveis trioDeColetaveis)
    {
        return (isColetado(atraido1, trioDeColetaveis.coletavel1) &
                isColetado(atraido2, trioDeColetaveis.coletavel2) &
                isColetado(atraido3, trioDeColetaveis.coletavel3));
    }

    public bool isColetado(Coletavel atraido, Coletavel coletavelSelecionado)
    {
        if (atraido.isNotAtivo())
        {
            return true;
        }
        else
        {
            Debug.Log("nome" + atraido.nome +  " pos " + atraido.getPosicao());
            if (atraido.getPosicao().y > 2.9 && !preFinalizadoJaAcionado)
            {
                coletavelSelecionado.colocarNaPosicao(atraido.getPosicao());
                atraido.desligar();
                powerUpFinalizacao.preFinalizar(coletavelSelecionado);

                preFinalizadoJaAcionado = true;
            }
            return false;
        }
    }

    private void ligarColetavelAtraido(Coletavel coletavelAtracao, Coletavel coletavelSelecionado)
    {
        if(coletavelSelecionado != null)
        {
            coletavelAtracao.colocarNaPosicao(coletavelSelecionado.getPosicao(), coletavelSelecionado.getAngulo());
            coletavelAtracao.receberSprite(coletavelSelecionado.getSprite());
            coletavelAtracao.colocarNoLayerDestaque();
            coletavelAtracao.ligar();            

            coletavelSelecionado.desligar();
        }
    }

    public override void timeout()
    {
        if (!alvosSelecionados)
        {
            resetPup();
            powerUpFinalizacao.finalizado();
        }
    }
}
