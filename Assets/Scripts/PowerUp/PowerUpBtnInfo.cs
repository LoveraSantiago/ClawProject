public class PowerUpBtnInfo 
{
    public bool hasEntidade { get { return powerUpEntidade != null; } }
    public int indiceBotao { get; private set; }
    public PowerUpEntidade powerUpEntidade { get; private set; }

    public PowerUpBtnInfo()
    {
    }

    public PowerUpBtnInfo(int indiceBotao, PowerUpEntidade powerUpEntidade)
    {
        this.indiceBotao = indiceBotao;
        this.powerUpEntidade = powerUpEntidade;
    }
}
