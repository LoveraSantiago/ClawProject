public interface BiTransformador<T, U, R>
{
    R transformar(T entrada1, U entrada2);
}
