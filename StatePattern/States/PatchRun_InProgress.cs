namespace StatePattern
{
    internal class PatchRun_InProgress : State
    {
         // to take values from the old state
        internal PatchRun_InProgress(State oldState)
            : this(oldState.jsonString, oldState.stateLoader)
        {
        }

        internal PatchRun_InProgress(string jsonString, StateLoader stateLoader)
        {
            this.jsonString = jsonString;
            this.stateLoader = stateLoader;
        }

        internal override void PerformOperations()
        {
            // Check if patch run completed, then Update State, else stay same
            this.UpdateState();
        }

        private void UpdateState()
        {
            // next state is ReAssessment_InProgress
            this.stateLoader.CurrentState = new ReAssessment_InProgress(this);
            // Persist state in the table
        }
    }
}
