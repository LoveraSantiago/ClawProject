public class ResultadoPowerUpDto 
{
    public int totalPowerUps { get; private set; }

    public ResultadoPowerUpDto(int totaoPowerUps)
    {
        this.totalPowerUps = totaoPowerUps;
    }
}
