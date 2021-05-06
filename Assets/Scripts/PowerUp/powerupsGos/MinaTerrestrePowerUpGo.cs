using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinaTerrestrePowerUpGo : AbstractPowerUpGo
{
    private static Vector3 posInicial;
    private bool configurado;

    private Animator animator;
    private GameObject goExplosao;

    private int tempoExplosao;

    public MinaTerrestrePowerUpGo(GameObject tileMinaTerrestre)
        :base(tileMinaTerrestre, "mina-terrestre")
    {

    }

    public override bool garraPodeSegurar()
    {
        return false;
    }

    public override void iniciarNaPosicao(Vector3 posicao)
    {
        posInicial = posicao;
    }

    public override void ligar()
    {
        if (!configurado)
        {
            configurarObjetoMina();
        }
        base.ligar();
        base.colocarNaPosicao(posInicial);
    }

    private void configurarObjetoMina()
    {
        animator   = goColetavel.transform.Find("imagem").GetComponent<Animator>();
        goExplosao = goColetavel.transform.Find("explosao").gameObject;

        tempoExplosao = PowerUpEntidade.getPowerUpEntidadeByEnum(PowerUpEntidade.NAME.MINA_TERRESTRE).duracao;
        configurado = true;
    }

    public override void parar() { }
    public override void colocarNaPosicao(Vector3 posicao) { }
    public override void desligarGravidade() { }
    public override void ligarGravidade() { }
    public override void fixarVerticalmente() { }

}
