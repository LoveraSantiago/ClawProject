public class ProcuradorGOMaisAlto<T> : Consumidor<T> where T : GO
{
    public T goMaisAlto { get; private set; }

    public void consumir(T goIt)
    {
        if (goIt.isAtivo())
        {
            float alturaIt = goIt.getPosicao().y;
            float alturaMaisAlta = getHalturaAtual();

            if(alturaIt > alturaMaisAlta)
            {
                goMaisAlto = goIt;
                //Debug.Log("Setado mais alto");
            }
        }        
    }    

    private float getHalturaAtual()
    {
        if(goMaisAlto != null)
        {
            return goMaisAlto.getPosicao().y;
        }
        return -100;
    }
}
