public class BoardAcaoFim 
{
    public bool isGameOVer { get; private set; }
    public float acrescimo { get; private set; }

    public BoardAcaoFim(bool isGameOver, float acrescimo)
    {
        this.isGameOVer = isGameOVer;
        this.acrescimo = acrescimo;
    }
}
