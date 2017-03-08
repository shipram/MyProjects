namespace StatePattern
{
    internal class Cleanup_Started : State
    {
        internal Cleanup_Started(State oldState)
            : this(oldState.jsonString, oldState.stateLoader)
        {
        }

        //to pass on to the next state
        internal Cleanup_Started(string jsonString, StateLoader stateLoader)
        {
            this.jsonString = jsonString;
            this.stateLoader = stateLoader;
        }

        internal override void PerformOperations()
        {
            // read RG Id from the json and delete all.
            this.UpdateState();
        }

        private void UpdateState()
        {
            // next state is Uninitialized
            this.stateLoader.CurrentState = new Setup_Started(this);
            // Persist the next state in the table along with the appropriate jsonstring
        }
    }
}
