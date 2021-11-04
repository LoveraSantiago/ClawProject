using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoringaPowerUpGo : PowerUpNaoInteracaoComGarra
{
    private bool hitColetavel;
    private Coroutine coroutine;

    public CoringaPowerUpGo() : 
        base(powerUpDto.VazioPUp, "coringa"){}

    public override void configurarPup(){}

    public override void iniciarPup()
    {
        ColetavelHelper coletavelHelper = new ColetavelHelper();
        coletavelHelper.ligarMirasNosColetaveis();
        coroutine = Utils.MonoBehaviour.StartCoroutine(selecionarAlvo());
    }

    public override void resetPup(){}

    private IEnumerator selecionarAlvo()
    {
        hitColetavel = false;
        ColetavelHelper coletavelHelper = new ColetavelHelper();
        coletavelHelper.ligarMirasNosColetaveis();

        SelecionadorDeAlvos selecionadorDeAlvos = new SelecionadorDeAlvos();
        yield return selecionadorDeAlvos.selecionarAlvo(inputGame);

        ColetavelTile coletavelSelecionado = selecionadorDeAlvos.coletavelSelecionado;        
        coletavelHelper.ligarMiraAlvoFinalNoColetavel(coletavelSelecionado.nome);
    }

        public static Fornecedor<AbstractPowerUpGo> getFornecedor()
    {
        return new FornecedorCoringa();
    }

    public class FornecedorCoringa : Fornecedor<AbstractPowerUpGo>
    {
        public AbstractPowerUpGo fornecer()
        {
            return new CoringaPowerUpGo();
        }
    }
}
