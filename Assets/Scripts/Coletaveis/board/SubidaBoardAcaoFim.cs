public class SubidaBoardAcaoFim 
{
    public bool isGameOver { get; private set; }
    public float acrescimo { get; private set; }

    public SubidaBoardAcaoFim(bool isGameOver, float acrescimo)
    {
        this.isGameOver = isGameOver;
        this.acrescimo = acrescimo;
    }

    public static SubidaBoardAcaoFim of(float acrescimo)
    {
        return new SubidaBoardAcaoFim(false, acrescimo);
    }

    public static SubidaBoardAcaoFim ofGameOver()
    {
        return new SubidaBoardAcaoFim(true, 0);
    }
}
