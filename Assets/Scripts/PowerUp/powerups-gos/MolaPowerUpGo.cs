using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MolaPowerUpGo : PowerUpSemInteracao
{
    private static readonly int IDLE = Animator.StringToHash("idle");
    private static readonly int JUMP = Animator.StringToHash("mola-jump");

    private static Vector3 posInicial;

    private Animator animator;
    private BoxCollider2D boxCollider2d;

    public MolaPowerUpGo() 
        : base(powerUpDto.MolaDto.MolaGo, "mola"){}

    public override void iniciarNaPosicao(Vector3 posicao)
    {
        posInicial = posicao;
    }

    public override void configurarPup()
    {
        Transform transformImg = extrairTransform("imagem");
        animator = transformImg.GetComponent<Animator>();
        boxCollider2d = transformImg.GetComponent<BoxCollider2D>();
    }

    public override void iniciarPup()
    {
        ligar();
        posInicial.y = powerUpDto.HalturaPupDraggavel;
        base.colocarNaPosicao(posInicial);
        Utils.MonoBehaviour.StartCoroutine(jumpar());
    }

    public override void resetPup()
    {
        desligar();
        animator.Play(IDLE);
        powerUpFinalizacao.preFinalizar();
    }
    
    private IEnumerator jumpar()
    {
        yield return new WaitForSeconds(powerUpDto.MolaDto.DelayInicial);

        Coletavel[] coletaveis = getColetaveisColididosComMola();
        animator.Play(JUMP);

        yield return new WaitForSeconds(0.1f);

        dispararColetaveis(coletaveis);       
        yield return null;

        List<Coletavel> coletaveisQueda = new List<Coletavel>(coletaveis.Length);
        while(coletaveisQueda.Count < coletaveis.Length)
        {
            for(int contador = 0; contador < coletaveis.Length; contador++)
            {
                Coletavel coletavelIt = coletaveis[contador];
                if (!coletavelIt.isVelocidadeYPositiva() && !coletaveisQueda.Contains(coletavelIt))
                {
                    coletavelIt.interacaoComOutrosColetaveis();
                    coletaveisQueda.Add(coletavelIt);
                }
            }
            yield return null;
        }
        yield return new WaitForSeconds(powerUpDto.MolaDto.DelayInicial * 5);

        resetPup();
        powerUpFinalizacao.finalizado();
        yield return null;
    }

    private Coletavel[] getColetaveisColididosComMola()
    {
        List<Coletavel> listaDeColetaveis = new List<Coletavel>();
        int tamanhoArray = 5;

        Collider2D[] colliders = new Collider2D[tamanhoArray];
        ContactFilter2D filter = new ContactFilter2D().NoFilter();        
        boxCollider2d.OverlapCollider(filter, colliders);

        HelperColetaveisInGame helperInGame = new HelperColetaveisInGame();
        for (int contador = 0; contador < tamanhoArray; contador++)
        {
            Collider2D coliderIt = colliders[contador];
            if (coliderIt != null)
            {
                int inteiro;
                string nomeCollider = colliders[contador].name;
                bool isNomeColetavel = int.TryParse(nomeCollider, out inteiro);
                if (isNomeColetavel)
                {
                    Coletavel coletavel = helperInGame.getColetavelInGameByGoName(nomeCollider);
                    listaDeColetaveis.Add(coletavel);
                    coletavel.naoInteracaoComOutrosColetaveis();                    
                }
            }            
        }
        Coletavel[] coletaveis = listaDeColetaveis.ToArray();
        return coletaveis;
    }

    private void dispararColetaveis(Coletavel[] coletaveis)
    {
        for (int contador = 0; contador < coletaveis.Length; contador++)
        {
            float anguloDisparo;
            Coletavel coletavelIt = coletaveis[contador];
            if (coletavelIt.getPosicao().x < 0)
            {
                anguloDisparo = Random.Range(-30, -5);
            }
            else
            {
                anguloDisparo = Random.Range(5, 30);
            }
            //Debug.Log("Angulo " + anguloDisparo);
            coletaveis[contador].disparar(anguloDisparo, 15f);
        }
    }
}
