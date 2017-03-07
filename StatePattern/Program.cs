namespace StatePattern
{
    public class Program
    {
        public static void Main(string[] args)
        {
            StateLoader loader = new StateLoader();
            loader.TransitionState();
        }
    }
}
