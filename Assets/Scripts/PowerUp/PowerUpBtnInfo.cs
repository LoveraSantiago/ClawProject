public class PowerUpBtnInfo 
{
    public int indiceBotao { get; private set; }
    public PowerUpEntidade powerUpEntidade { get; private set; }

    public PowerUpBtnInfo(int indiceBotao, PowerUpEntidade powerUpEntidade)
    {
        this.indiceBotao = indiceBotao;
        this.powerUpEntidade = powerUpEntidade;
    }
}
