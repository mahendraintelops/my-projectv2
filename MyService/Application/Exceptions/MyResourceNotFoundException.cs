namespace Application.Exceptions
{
    public class MyResourceNotFoundException : ApplicationException
    {
        public MyResourceNotFoundException(string name, object key) : base($"Entity {name} - {key} is not found.")
        {

        }
    }
}
