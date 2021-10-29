public class AcaoDesligar 
{
    public CallbackDesligar callbackDesligar { get; private set; }

    public AcaoDesligar(CallbackDesligar callbackDesligar)
    {
        this.callbackDesligar = callbackDesligar;
    }
}
