public interface TransformadorDeEvento<T, U>
{
    U transformarEvento(T evento);
}
