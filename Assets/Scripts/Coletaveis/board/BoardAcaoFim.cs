public class BoardAcaoFim 
{
    public bool isGameOver { get; private set; }
    public float acrescimo { get; private set; }

    public BoardAcaoFim(bool isGameOver, float acrescimo)
    {
        this.isGameOver = isGameOver;
        this.acrescimo = acrescimo;
    }

    public static BoardAcaoFim of(float acrescimo)
    {
        return new BoardAcaoFim(false, acrescimo);
    }

    public static BoardAcaoFim ofGameOver()
    {
        return new BoardAcaoFim(true, 0);
    }
}
