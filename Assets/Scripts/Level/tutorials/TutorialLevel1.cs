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
        mainDto.TutorialDto.LblTexto.text = "Toque para coletar!\nCombine 3 itens iguais para um combo.";
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
        mainDto.TutorialDto.LblTexto.text = "Toque para coletar!\nCombine 3 itens iguais para um combo.";
        animacaoTutorial.playColetar();        
    }

    private void tratarColetadosParteCliqueColetavel()
    {
        if (contagemColetados == 1)
        {
            mainDto.TutorialDto.GoTutorial.SetActive(false);
            mainDto.TutorialDto.LblTexto.text = "Colete um item igual ao anterior\npara preparar um combo.";
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
