using UnityEngine;

public class ModalSair : AcaoDesligarMaquinaResultado.ProdutorEvento, 
                         AcaoDesligarMaquina.ConsumidorEvento    
{
    private const int SAIR_NORMAL    = 0;
    private const int SAIR_COLETAVEL = 1;
    private const int SAIR_EXTRA     = 2;

    private static readonly int ANIM_ABRIR  = Animator.StringToHash("modal-sair-abrir");
    private static readonly int ANIM_FECHAR = Animator.StringToHash("modal-sair-fechar");

    private int estadoSairPara;    
    
    private ModalSairDto modalSairDto;
    private ProdutorDeEvento<ResultadoDesligarMaquinaDto> produtorDeEvento;
    private SomModais somModais;

    public ModalSair(ModalSairDto modalSairDto, SomModais somModais)
    {
        this.modalSairDto = modalSairDto;
        this.somModais    = somModais;
        this.modalSairDto.BtnCancelar.onClick.AddListener(()=>cancelarSaida());
        this.modalSairDto.BtnSair.onClick.AddListener(()=>sairDoGame());
        produtorDeEvento = new ProdutorDeEvento<ResultadoDesligarMaquinaDto>();
    }

    public void configuradoPeloLevel()
    {
        if(LevelUtils.isPlayableLevel())
        {
            estadoSairPara = SAIR_NORMAL;                       
        }
        else if (LevelUtils.isColetavelLevel())
        {
            estadoSairPara = SAIR_COLETAVEL;
        }
        else
        {
            estadoSairPara = SAIR_EXTRA;                        
        }
    }   

    private void cancelarSaida()
    {
        somModais.playSomAbrirModal();
        somModais.playSomCliqueNegativo();
        modalSairDto.Animator.Play(ANIM_FECHAR);
        produtorDeEvento.produziuEvento(new ResultadoDesligarMaquinaDto(false));
        ContextoEstaticoUtils.continuarGame();
    }

    private void sairDoGame()
    {
        ContextoEstaticoUtils.continuarGame();
        somModais.playSomCliquePositivo();
        if (ContextoEstaticoUtils.loading.naoAcionado)
        {
            switch (estadoSairPara)
            {
                case SAIR_NORMAL:
                    {
                            produtorDeEvento.produziuEvento(new ResultadoDesligarMaquinaDto(true, true));
                            ContextoEstaticoUtils.loading.irParaMapScene();                    
                        break;
                    }
                case SAIR_COLETAVEL:
                    {
                        produtorDeEvento.produziuEvento(new ResultadoDesligarMaquinaDto(true, false));
                        ContextoEstaticoUtils.loading.irParaColetaveisCena();
                        break;
                    }
                case SAIR_EXTRA:
                    {
                        produtorDeEvento.produziuEvento(new ResultadoDesligarMaquinaDto(true, false));
                        ContextoEstaticoUtils.loading.irParaPowerUpCena();
                        break;
                    }
            }        
        }
    }

    void AcaoDesligarMaquina.ConsumidorEvento.consumirEvento(DesligarMaquinaDto evento)
    {
        ContextoEstaticoUtils.pausarGame();
        string text = null;
        switch (estadoSairPara)
        {
            case SAIR_NORMAL:    text = "Tem certeza que deseja sair?\nVocê perderá sua ficha!"; break;
            case SAIR_COLETAVEL: text = "Tem certeza que deseja sair?\nVocê perderá sua ficha!"; break;
            case SAIR_EXTRA:     text = "Tem certeza que deseja sair do treinamento?"; break;
        }
        
        modalSairDto.TextoSair.text = text;
        somModais.playSomAbrirModal();
        modalSairDto.Animator.Play(ANIM_ABRIR);
    }

    ProdutorDeEvento<ResultadoDesligarMaquinaDto> AcaoDesligarMaquinaResultado.ProdutorEvento.getProdutorDeEvento()
    {
        return produtorDeEvento;
    }
}
