public class UpdateMainGameManagers 
{
    public GarraManager   garraManager   { get; private set; }
    public MaquinaManager maquinaManager { get; private set; }
    public InputGame      inputGame      { get; private set; }

    public UpdateMainGameManagers(
        GarraManager garraManager, MaquinaManager maquinaManager, InputGame inputGame)
    {
        this.garraManager = garraManager;
        this.inputGame = inputGame;
        this.maquinaManager = maquinaManager;
    }

    public void update()
    {
        inputGame.update();
        garraManager.update(inputGame);
        maquinaManager.update(inputGame);
    }

    public void fixedUpdate(MainGameDto mainDto)
    {
        garraManager.fixedUpdate(mainDto.GarraDto);
        maquinaManager.fixedUpdate();
    }
}
