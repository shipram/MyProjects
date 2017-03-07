namespace StatePattern
{
    public abstract class State
    {
        public StateLoader stateLoader;

        public string jsonString;

        public abstract void PerformOperations();

    }
}
