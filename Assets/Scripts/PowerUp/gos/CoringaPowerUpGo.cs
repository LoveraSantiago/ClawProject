using System.Collections;
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
            coroutineAlvo = ContextoEstaticoUtils.monoBehaviour.StartCoroutine(alvoSelecionado.onSelecionar(inputGame, this));
        }
        else
        {
            ContextoEstaticoUtils.monoBehaviour.StartCoroutine(ativacaoFalha());
        }
    }

    public override void resetPup()
    {
        Debug.Log("Reset chamado");
        coletavelSelecionado = null;
        finalizando = false;
        coroutineAlvo = null;

        EfeitosTeleportes efeitoTeleporte = new EfeitosTeleportes();
        efeitoTeleporte.desligar(powerUpDto.TeleporteDto.EfeitoTeleporte1);
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
        powerUpFinalizacao.emAndamento(PowerUpEnums.ESTADO.ALVO1_SELECIONADO);
        coletavelSelecionado = coletavel;

        PowerUpRotacionadorDeColetavel rotacionador = new PowerUpRotacionadorDeColetavel(powerUpDto.VelocidadeRotacao, coletavelSelecionado);
        yield return rotacionador.rotacionar();

        CorEfeitoTeleporteDto corEfeitoTeleporte = powerUpDto.TeleporteDto.CorEfeitoCoringa;
        EfeitosTeleportes efeitoTeleporte = new EfeitosTeleportes();
        efeitoTeleporte.ligar(powerUpDto.TeleporteDto.EfeitoTeleporte1, corEfeitoTeleporte.CorMaterial, coletavelSelecionado.getPosicao());

        MapaEntidade mapaEntidade = ContextoEstaticoUtils.mapaEntidade;        
        ColetavelEntidade coletavelEntidade = mapaEntidade.getColetavelEntidadeBySpriteNome(coletavel.nomeSprite);
        ColetavelEntidade[] coletaveisFamilia = mapaEntidade.getColetaveisExcluindo(coletavelEntidade);

        Color corHdr = HSBColor.toHdrColor(corEfeitoTeleporte.CorMaterial, corEfeitoTeleporte.HdrMaterial);

        MaterialTeleporte materialTeleporte = new MaterialTeleporte();        
        materialTeleporte.addTrocaIn(coletavel.getSprite(), corHdr);
        coletavel.addMaterial(materialTeleporte.materialTeleporte);

        int indiceSorteado = MathUtils.escolherDeZeroAteLimite(coletaveisFamilia.Length);
        Sprite sprSorteado = null;
        while (!finalizando)
        {
            somPowerUp.playSomTeleporte();
            ColetavelEntidade coletavelSorteado = coletaveisFamilia[indiceSorteado];
            Debug.Log("indice sorteado " + indiceSorteado);
            sprSorteado = coletavelSorteado.sprite;      
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
                powerUpFinalizacao.emAndamento(PowerUpEnums.ESTADO.ALVO2_SELECIONADO);
                break;
            }

            somPowerUp.playSomTeleporte();
            indiceSorteado = MathUtils.escolherDeZeroAteLimiteDiferenteDe(coletaveisFamilia.Length, indiceSorteado);
            Debug.Log("indice sorteado " + indiceSorteado);
            coletavelSorteado = coletaveisFamilia[indiceSorteado];
            sprSorteado = coletavelSorteado.sprite;
            materialTeleporte.addTrocaIn(sprSorteado, corHdr);

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
                powerUpFinalizacao.emAndamento(PowerUpEnums.ESTADO.ALVO2_SELECIONADO);
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
        finalizar();        
        yield return null;
    }

    public override void timeout()
    {
        if (!finalizando)
        {
            ContextoEstaticoUtils.monoBehaviour.StopCoroutine(coroutineAlvo);
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
