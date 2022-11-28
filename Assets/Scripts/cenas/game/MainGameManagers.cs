using System.Collections;
using UnityEngine;

public class MainGameManagers 
{
    protected AllGameManagersImpl allGameManagers;  

    public MainGameManagers()
    {
        allGameManagers = new AllGameManagersImpl();
    }

    public void configurar(MainGameDto mainDto, Consumidor<UpdaterManagers> consumidorUpdateManagers)
    {
        PrefabLoading prefabLoading = mainDto.PrefabLoading.GetComponent<PrefabLoading>();
        SomManagerGame somManager = new SomManagerGame(mainDto.AudioGameDto);
        prefabLoading.iniciarLoading(somManager, mainDto.GosDesligar);

        ColetorDeDados coletorDeDados = new ColetorDeDados();

        iniciarManagers(mainDto, somManager, coletorDeDados);
        configurandoLevel(mainDto);
        configurandoEventos();
        consumidorUpdateManagers.consumir(new UpdaterEmptyManagers());

        coletorDeDados
            .addProvedorDadosTempo       (allGameManagers.getDadosTempo())
            .addProvedorDadosColetaveis  (allGameManagers.getColetaveisManager())            
            .addProvedorSubidasDaGarra   (allGameManagers.getGarraManager())
            .addProvedorSubidasDoElevador(allGameManagers.getBoardElevador())
            .addProvedorDadosPowerUp     (allGameManagers.getPowerUpManager());

        ContextoEstaticoUtils.monoBehaviour.StartCoroutine(startLaizy(mainDto, consumidorUpdateManagers));
        ContextoEstaticoUtils.loading.fecharModal();
        somManager.playSomBackground();
    }

    private void iniciarManagers(MainGameDto mainDto, SomManagerGame somManager, ColetorDeDados coletorDeDados)
    {
        InputGameImpl inputGame = new InputGameImpl();

        allGameManagers
            .addInputManager     (inputGame)
            .addGarraManager     (new GarraManager(mainDto.GarraDto, somManager))
            .addColetaveisManager(new ColetaveisManager(mainDto.ColetaveisDto, somManager))
            .addMaquinaManager   (new MaquinaManager(mainDto.MaquinaDto, somManager))
            .addPowerUpManager   (new PowerUpManager(mainDto.PowerUpDto, inputGame, somManager))
            .addUiGameManager    (new UiGameManager(mainDto, coletorDeDados, somManager))
            .addCameraManager    (new CameraManager(mainDto.CameraDto))
            .addDraggavelManager (new DraggavelManager(mainDto.DragCollider));
    }

    private void configurandoLevel(MainGameDto mainDto)
    {
        allGameManagers.getColetaveisManager()
                       .configuradoPeloLevel(mainDto.ColetaveisDto);

        AbstractLevel levelEscolhido = ContextoEstaticoUtils.level;
        allGameManagers.getMaquinaManager()
            .configuradoPeloLevel(levelEscolhido, mainDto.MaquinaDto);

        allGameManagers.getUiManager()
            .configurandoLevel(levelEscolhido);

        ColetaveisManager coletaveiManager = allGameManagers.getColetaveisManager();
        allGameManagers.getPowerUpManager()
            .configurarGosPowerUps(getInformacaoDisplayColetado(),
                                   coletaveiManager.getFornecedorTrocadorDeOrdem());       
    }

    protected virtual void configurandoEventos()
    {
        MainGameEventos eventos = new MainGameEventos(allGameManagers);
        eventos.configurarEventos();
    }

    protected virtual IEnumerator startLaizy(MainGameDto mainDto, Consumidor<UpdaterManagers> consumidorUpdateManagers)
    {
        yield return allGameManagers.getColetaveisManager().start();
        yield return new WaitForSeconds(mainDto.DelayInicio);

        InputGame inputGame = allGameManagers.getInputGame();
        allGameManagers.getMaquinaManager().start(inputGame);
        allGameManagers.getGarraManager().start(mainDto.GarraDto);
        consumidorUpdateManagers.consumir(getUpdatables());
    }

    protected UpdaterMainGameManagers getUpdatables()
    {
        return new UpdaterMainGameManagers(allGameManagers);
    }

    private InformacaoDisplayColetado getInformacaoDisplayColetado()
    {
        return allGameManagers.getModoColetados();            
    }
}
