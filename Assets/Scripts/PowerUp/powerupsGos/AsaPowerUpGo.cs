using UnityEngine;
using System.Collections;

public class AsaPowerUpGo : AbstractPowerUpGo
{
    private readonly int VOADA;

    private bool hitColetavel;
    private Animator animator;

    public AsaPowerUpGo() 
        : base(powerUpDto.AsaPup, null, "Asas")
    {
        VOADA = Animator.StringToHash("voada");
    }

    public override void configurarPup()
    {
        animator = goColetavel.GetComponent<Animator>();
    }

    public override PowerUpEntidade.INTERACAOGARRA getInteracaoComGarra()
    {
        return PowerUpEntidade.INTERACAOGARRA.NAO_INTERACAO;
    }

    public override void iniciarPup()
    {
        ligarMirasNosColetaveis();
        monoBehaviour.StartCoroutine(selecionarAlvo());
    }

    public override void resetPup()
    {
        
    }

    private IEnumerator selecionarAlvo()
    {
        hitColetavel = false;
        ColetavelQuery coletavelQuery = new ColetavelQuery();
        while (!hitColetavel)
        {
            if (inputGame.aconteceuTapNaAreaSuperior())
            {
                Collider2D coletavelHit = getColetavelHit();
                if (coletavelHit != null)
                {
                    string nomeAlvo = coletavelHit.name;
                    desligarMirasNosColetaveis();
                    ColetavelTile coletavelParaVoar = coletavelQuery.getColetavelInGameByName(nomeAlvo);

                    colocarNaPosicao(coletavelParaVoar.getPosicao());
                   // receberSprite(coletavelParaVoar.getSprite());

                    coletavelParaVoar.desligar();
                    ligar();
                }
            }
            yield return null;
        }

        yield return null;
    }

    public static Supplier<AbstractPowerUpGo> getSupplier()
    {
        return new Supplier();
    }

    public class Supplier : Supplier<AbstractPowerUpGo>
    {
        public AbstractPowerUpGo get()
        {
            return new AsaPowerUpGo();
        }
    }
}
