namespace StatePattern
{
    public abstract class State
    {
        internal StateLoader stateLoader;

        internal string jsonString;

        internal abstract void PerformOperations();

    }
}
