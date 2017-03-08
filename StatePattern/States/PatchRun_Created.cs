namespace StatePattern
{
    internal class PatchRun_Created : State
    {
        // to take values from the old state
        internal PatchRun_Created(State oldState)
            : this(oldState.jsonString, oldState.stateLoader)
        {
        }

        internal PatchRun_Created(string jsonString, StateLoader stateLoader)
        {
            this.jsonString = jsonString;
            this.stateLoader = stateLoader;
        }

        internal override void PerformOperations()
        {
            // Schedule Patch Run 
            this.UpdateState();
        }

        private void UpdateState()
        {
            // next state is Setup_Started
            this.stateLoader.CurrentState = new PatchRun_InProgress(this);
            // Persist state in the table
        }
    }
}
