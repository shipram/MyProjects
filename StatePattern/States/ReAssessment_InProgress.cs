namespace StatePattern
{
    internal class ReAssessment_InProgress : State
    { // to take values from the old state
        internal ReAssessment_InProgress(State oldState)
            : this(oldState.jsonString, oldState.stateLoader)
        {
        }

        //to pass on to the next state
        internal ReAssessment_InProgress(string jsonString, StateLoader stateLoader)
        {
            this.jsonString = jsonString;
            this.stateLoader = stateLoader;
        }

        internal override void PerformOperations()
        {
           // Check if there are Update Run Progress records, then update state
            this.UpdateState();
        }

        private void UpdateState()
        {
            // next state is Setup_Started
            this.stateLoader.CurrentState = new Cleanup_Started(this);
            // Persist the next state in the table along with the appropriate jsonstring
        }
    }
}
