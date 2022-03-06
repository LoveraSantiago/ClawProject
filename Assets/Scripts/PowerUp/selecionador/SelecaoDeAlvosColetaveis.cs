public abstract class SelecaoDeAlvosColetaveis<T> : SelecaoDeAlvos<T>,
                                           Transformador<InputGame, Coletavel>
{
    public Coletavel transformar(InputGame entrada)
    {
        return ColetavelInputHit.hit(entrada);
    }
}
