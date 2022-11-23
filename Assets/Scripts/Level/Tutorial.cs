using UnityEngine;
using System.Collections;

public class Tutorial : AcaoColetadoFim.ConsumidorEvento,
                        AcaoBotaoPowerUpVazio.ConsumidorEvento, 
                        AcaoPupFromScrollSelecao.ConsumidorEvento,
                        AcaoPowerUpAcionado.ConsumidorEvento,
                        AcaoColetado.ProdutorEvento
{
    private static readonly int ANIM_PARTE_COLETAR = Animator.StringToHash("clique-coletar");
    private static readonly int ANIM_PARTE_POWERUP = Animator.StringToHash("clique-powerup");
    private static readonly int ANIM_PARTE_DRAGPUP = Animator.StringToHash("drag-powerup");    
    private static readonly int ANIM_PARTE_TEXTO   = Animator.StringToHash("so-texto");    

    private int contagemColetados;
    private MainGameDto    mainDto;
    private GarraManager   garraManager;
    private MaquinaManager maquinaManager;
    private ProdutorDeEvento<InformacoesColetadoDto> produtorDeEvento;

    public Tutorial()
    {
        produtorDeEvento = new ProdutorDeEvento<InformacoesColetadoDto>();
    }

    public void iniciar(MainGameDto mainDto, GarraManager garraManager, MaquinaManager maquinaManager)
    {
        this.mainDto        = mainDto;
        this.garraManager   = garraManager;
        this.maquinaManager = maquinaManager;
        mainDto.TutorialDto.GoTutorial.SetActive(true);
        prepararTutorialParteCliqueColetavel();
    }

    private void prepararTutorialParteCliqueColetavel()
    {
        maquinaManager.botoesPowerUp.desativarPowerUp();
        maquinaManager.botaoLigaDesliga.desligar();
        mainDto.TutorialDto.LblTexto.text = "Vamos Coletar!\nClique para acionar a garra!";
        mainDto.TutorialDto.Animator.Play(ANIM_PARTE_COLETAR);        
    }    

    private void tratarColetadosParteCliqueColetavel()
    {
        if(contagemColetados == 1)
        {
            mainDto.TutorialDto.LblTexto.text = "Muito bom!\nColete mais um item!";
        }
        else if (contagemColetados == 2)
        {
            mainDto.TutorialDto.LblTexto.text = "Vamos completar uma trinca!\nFalta só mais um!";
        }
        if(contagemColetados == 3)
        {
            prepararTutorialPartePowerUp();
        }
    }

    private void prepararTutorialPartePowerUp()
    {
        garraManager.parar();        
        mainDto.TutorialDto.LblTexto.text = "Acione o botão power up!\nEsta vazio agora.";        

        mainDto.TutorialDto.GoTutorial.SetActive(true);
        maquinaManager.botoesPowerUp.reativarPowerUp();        
        mainDto.TutorialDto.Animator.Play(ANIM_PARTE_POWERUP);
    }

    private void prepararTutorialParteDragPup()
    {
        mainDto.TutorialDto.LblTexto.text = "Arraste e encontre um powerup\ndisponivel, clique nele!";
        mainDto.TutorialDto.Animator.Play(ANIM_PARTE_DRAGPUP);
    }

    private void prepararTutorialParteAcionarPowerUp()
    {
        mainDto.TutorialDto.LblTexto.text = "Acione o botão power up!\nAgora esta carregado!";
        mainDto.TutorialDto.Animator.Play(ANIM_PARTE_POWERUP);
    }

    private void prepararTutorialParteJogarPowerUp()
    {
        mainDto.TutorialDto.LblTexto.text = "Ative o powerup!\nClique para soltar o power up!";
        mainDto.TutorialDto.Animator.Play(ANIM_PARTE_COLETAR);
    }    

    private void prepararFimTutorialPupExpirado()
    {
        mainDto.TutorialDto.LblTexto.text = "ok!O tempo acabou.\nBoa Sorte!";
        mainDto.TutorialDto.Animator.Play(ANIM_PARTE_TEXTO);
        ContextoEstaticoUtils.MonoBehaviour.StartCoroutine(coroutineEncerrarTutorial());
    }

    private void prepararFimTutorial()
    {
        mainDto.TutorialDto.LblTexto.text = "Isso ai!Muibo bom!\nBoa Sorte!";
        mainDto.TutorialDto.Animator.Play(ANIM_PARTE_TEXTO);
        ContextoEstaticoUtils.MonoBehaviour.StartCoroutine(coroutineEncerrarTutorial());
    }

    protected IEnumerator coroutineEncerrarTutorial()
    {
        maquinaManager.botoesPowerUp.desativarPowerUp();
        garraManager.parar();
        yield return new WaitForSeconds(mainDto.DelayInicio * 2);

        mainDto.TutorialDto.GoTutorial.SetActive(false);
        InformacoesFimDeJogoDto infoFimDeJogo = InformacoesFimDeJogoDto.ofFimColetados(true);
        InformacoesColetadoDto eventoFim = new InformacoesColetadoDto()
            .addInfoFimDeJogo(infoFimDeJogo);

        Debug.Log("Criando evento de fim de jogo");
        produtorDeEvento.produziuEvento(eventoFim);
    }

    void AcaoColetadoFim.ConsumidorEvento.consumirEvento(ColetadoFimDto evento)
    {
        contagemColetados++;
        tratarColetadosParteCliqueColetavel();
    }

    void AcaoBotaoPowerUpVazio.ConsumidorEvento.consumirEvento(int evento)
    {
        prepararTutorialParteDragPup();
    }

    void AcaoPupFromScrollSelecao.ConsumidorEvento.consumirEvento(PowerUpBtnInfo evento)
    {
        prepararTutorialParteAcionarPowerUp();
    }

    void AcaoPowerUpAcionado.ConsumidorEvento.consumirEvento(PowerUpInfo evento)
    {
        if (evento.isInicio)
        {
            prepararTutorialParteJogarPowerUp();
        }
        else if (evento.isExpirado)
        {
            prepararFimTutorialPupExpirado();
        }
        else if(evento.isFinalizar)
        {
            prepararFimTutorial();
        }
    }

    ProdutorDeEvento<InformacoesColetadoDto> AcaoColetado.ProdutorEvento.getProdutorDeEvento()
    {
        return produtorDeEvento;
    }
}
