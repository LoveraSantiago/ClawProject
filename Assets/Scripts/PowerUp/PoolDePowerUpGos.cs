public class PoolDePowerUpGos 
{
    private PowerUpDto powerUpDto;
    private PoolGenerico<AbstractPowerUpGo> poolDePowerUpsDaGarra;

    private PowerUpFinalizacao powerupFinalizacao;

    public PoolDePowerUpGos(PowerUpDto powerUpDto)
    {
        this.powerUpDto = powerUpDto;
        poolDePowerUpsDaGarra = new PoolGenerico<AbstractPowerUpGo>();
    }

    public AbstractPowerUpGo getPowerUpGo(PowerUpEntidade.NAME powerUpName)
    {
        if (!poolDePowerUpsDaGarra.contemNome(powerUpName.ToString()))
        {
            criarPowerUpGo(powerUpName);
        }
        return poolDePowerUpsDaGarra.getObjetoPeloNome(powerUpName.ToString());
    }

    private void criarPowerUpGo(PowerUpEntidade.NAME powerUpName)
    {
        switch (powerUpName)
        {
            case PowerUpEntidade.NAME.BOMBA_DA_GARRA: criarPowerUpGoBomba(); break;
            case PowerUpEntidade.NAME.MISSIL_NUCLEAR: criarPowerUpGoMissilNuclear(); break;
            case PowerUpEntidade.NAME.MINA_TERRESTRE: criarPowerUpGoMinaTerrestre(); break;
            case PowerUpEntidade.NAME.MISSIL_TELEGUIADO: criarPowerUpGoMissilTeleguiado(); break;
        }
    }

    private void criarPowerUpGoMinaTerrestre()
    {
        MinaTerrestrePowerUpGo mina = new MinaTerrestrePowerUpGo(powerUpDto.MinaTerrestrePUp);
        poolDePowerUpsDaGarra.addObjetoAoDicionario(PowerUpEntidade.NAME.MINA_TERRESTRE.ToString(), mina);
    }

    private void criarPowerUpGoBomba()
    {
        BombaPowerUpGo bomba = new BombaPowerUpGo(powerUpDto.BombPUp);
        poolDePowerUpsDaGarra.addObjetoAoDicionario(PowerUpEntidade.NAME.BOMBA_DA_GARRA.ToString(), bomba);        
    }

    private void criarPowerUpGoMissilNuclear()
    {        
        MissilNuclearPowerUpGo missilNuclear = new MissilNuclearPowerUpGo(powerUpDto.MissilNuclearPUp);
        poolDePowerUpsDaGarra.addObjetoAoDicionario(PowerUpEntidade.NAME.MISSIL_NUCLEAR.ToString(), missilNuclear);        
    }

    private void criarPowerUpGoMissilTeleguiado()
    {
        MissilTeleguiadoPowerUpGo missilTeleguiado = new MissilTeleguiadoPowerUpGo(powerUpDto.MissilTeleguiadoPUp, powerUpDto.PathPointsMissil);
        poolDePowerUpsDaGarra.addObjetoAoDicionario(PowerUpEntidade.NAME.MISSIL_TELEGUIADO.ToString(), missilTeleguiado);
    }
}
