public class BoardAcaoFim 
{
    public bool isGameOver { get; private set; }
    public float acrescimo { get; private set; }

    public BoardAcaoFim(bool isGameOver, float acrescimo)
    {
        this.isGameOver = isGameOver;
        this.acrescimo = acrescimo;
    }
}
