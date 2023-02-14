public class WrapperArrayStringInteiro 
{
    public WrapperSingleStringInteiro[] stringInteiros;

    public WrapperArrayStringInteiro(){}

    public WrapperArrayStringInteiro(int qtd) {
        stringInteiros = new WrapperSingleStringInteiro[qtd];
    }
}
