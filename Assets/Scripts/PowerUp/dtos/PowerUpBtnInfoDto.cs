public class PowerUpBtnInfoDto 
{
    public bool hasEntidade { get { return powerUpEntidade != null; } }
    public int indiceBotao { get; private set; }
    public PowerUpEntidade powerUpEntidade { get; private set; }

    public PowerUpBtnInfoDto(int indiceBotao)
        :this(indiceBotao, null)
    {
    }

    public PowerUpBtnInfoDto(int indiceBotao, PowerUpEntidade powerUpEntidade)
    {
        this.indiceBotao = indiceBotao;
        this.powerUpEntidade = powerUpEntidade;
    }
}
