using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoringaPowerUpGo : AbstractTrocaPowerUpGo,
                                Transformador<Coletavel, IEnumerator>
{
    private bool finalizando;

    private HumAlvoColetavelSelecionado alvoSelecionado;
    private Coletavel coletavelSelecionado;

    private Coroutine coroutineAlvo;    

    public CoringaPowerUpGo() : 
        base(powerUpDto.VazioPUp, "coringa")
    {
        Debug.Log("Coringa instanciado");
    }

    public override void configurarPup(){}

    public override void iniciarPup()
    {   

        if (HelperColetaveisInGame.naoTemColetavelOvoInGame())
        {
            HelperColetaveisInGame.ligarMirasNosColetaveis(true);

            alvoSelecionado = new HumAlvoColetavelSelecionado(true);
            coroutineAlvo = ContextoEstaticoUtils.MonoBehaviour.StartCoroutine(alvoSelecionado.onSelecionar(inputGame, this));
        }
        else
        {
            ContextoEstaticoUtils.MonoBehaviour.StartCoroutine(ativacaoFalha());
        }
    }

    public override void resetPup()
    {
        Debug.Log("Reset chamado");
        coletavelSelecionado = null;
        finalizando = false;
        coroutineAlvo = null;        
    }

    public IEnumerator transformar(Coletavel entrada)
    {
        return fazerTroca(entrada);
    }

    private IEnumerator ativacaoFalha()
    {
        yield return new WaitForSeconds(1f);
        finalizar();
    }

    private IEnumerator fazerTroca(Coletavel coletavel)
    {
        coletavelSelecionado = coletavel;

        MapaEntidade mapaEntidade = ContextoEstaticoUtils.mapaEntidade;        
        ColetavelEntidade coletavelEntidade = mapaEntidade.getColetavelEntidadeBySpriteNome(coletavel.nomeSprite);
        ColetavelEntidade[] coletaveisFamilia = mapaEntidade.getColetaveisExcluindo(coletavelEntidade);        

        MaterialTeleporte materialTeleporte = new MaterialTeleporte();        
        materialTeleporte.addTrocaIn(coletavel.getSprite());
        coletavel.addMaterial(materialTeleporte.materialTeleporte);

        int indiceSorteado = MathUtils.escolherDeZeroAteLimite(coletaveisFamilia.Length);
        Sprite sprSorteado = null;
        while (!finalizando)
        {
            ColetavelEntidade coletavelSorteado = coletaveisFamilia[indiceSorteado];
            Debug.Log("indice sorteado " + indiceSorteado);
            sprSorteado = HelperColetavelEntidade.getSpriteColetavelByNomeSprite(coletavelSorteado.nomeSprite);            
            materialTeleporte.addTrocaOut(sprSorteado);
             
            bool houveToque = false;
            float contador = 0;
            while (contador < 1.01f)
            {
                houveToque = houveToque ? houveToque : inputGame.aconteceuTap();
                contador += Time.deltaTime * powerUpDto.TeleporteDto.VelocidadeCoringa;
                materialTeleporte.addValorDeTroca(contador);
                yield return null;
            }

            if (houveToque)
            {
                break;
            }

            indiceSorteado = MathUtils.escolherDeZeroAteLimiteDiferenteDe(coletaveisFamilia.Length, indiceSorteado);
            Debug.Log("indice sorteado " + indiceSorteado);
            coletavelSorteado = coletaveisFamilia[indiceSorteado];
            sprSorteado = HelperColetavelEntidade.getSpriteColetavelByNomeSprite(coletavelSorteado.nomeSprite);            
            materialTeleporte.addTrocaIn(sprSorteado);

            houveToque = false;
            while (contador > -0.09f)
            {
                houveToque = houveToque ? houveToque : inputGame.aconteceuTap();
                contador -= Time.deltaTime * powerUpDto.TeleporteDto.VelocidadeCoringa;
                materialTeleporte.addValorDeTroca(contador);
                yield return null;
            }

            if (houveToque)
            {
                break;
            }

            indiceSorteado = MathUtils.escolherDeZeroAteLimiteDiferenteDe(coletaveisFamilia.Length, indiceSorteado);
        }

        finalizando = true;

        HelperColetaveisInGame.desligarMirasNosColetaveis();
        powerUpFinalizacao.preFinalizar();
        coletavel.receberSprite(sprSorteado);
        coletavel.clearMaterial();
        getTrocadorDeOrdem().atualizar(coletavel);
        resetPup();        
        powerUpFinalizacao.finalizado();
        yield return null;
    }

    public override void timeout()
    {
        if (!finalizando)
        {
            ContextoEstaticoUtils.MonoBehaviour.StopCoroutine(coroutineAlvo);
            alvoSelecionado.timeout();
            finalizar();   
        }
    }  
    
    private void finalizar()
    {
        if (coletavelSelecionado != null)
        {
            coletavelSelecionado.clearMaterial();
            getTrocadorDeOrdem().atualizar(coletavelSelecionado);
        }

        HelperColetaveisInGame.desligarMirasNosColetaveis();
        powerUpFinalizacao.finalizado();
        resetPup();
    }
}
