public class TutorialLevel1 : AcaoColetadoFim.ConsumidorEvento                             
{    
    private int contagemColetados;

    private MainGameDto mainDto;
    private AnimacaoTutorial animacaoTutorial;
    private AllGameManagers allGameManagers;    

    public TutorialLevel1(AllGameManagers allGameManagers, MainGameDto mainDto)
    {
        this.allGameManagers = allGameManagers;
        this.mainDto = mainDto;
        animacaoTutorial = new AnimacaoTutorial(mainDto.TutorialDto.Animator);        
    }

    public void iniciar()
    {
        allGameManagers.getBotoesPowerUp().desligarBotoes();
        allGameManagers.getBotaoLigaDesliga().ligar();

        mainDto.TutorialDto.GoTutorial.SetActive(true);
        prepararTutorialParteCliqueColetavel();
    }

    private void prepararTutorialParteCliqueColetavel()
    {
        mainDto.TutorialDto.LblTexto.text = "Toque na tela para acionar a garra.";
        animacaoTutorial.playColetar();
    }

    private void tratarColetadosParteCliqueColetavel()
    {
        if (contagemColetados == 1)
        {
            mainDto.TutorialDto.LblTexto.text = "Muito bom!\nColete mais um item.";
        }
        else if (contagemColetados == 2)
        {
            mainDto.TutorialDto.LblTexto.text = "Colete mais item para combinar e aumentar sua pontuação!";
        }

        if (contagemColetados == 3)
        {
            mainDto.TutorialDto.GoTutorial.SetActive(false);
        }
    }    
    
    void AcaoColetadoFim.ConsumidorEvento.consumirEvento(ColetadoFimDto evento)
    {
        contagemColetados++;
        tratarColetadosParteCliqueColetavel();
    }   
}
