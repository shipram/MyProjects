namespace StatePattern
{
    using System;

    internal class Assessment_InProgress : State
    {
        // to take values from the old state
        internal Assessment_InProgress(State oldState)
            : this(oldState.jsonString, oldState.stateLoader)
        {
        }

        //to pass on to the next state
        internal Assessment_InProgress(string jsonString, StateLoader stateLoader)
        {
            this.jsonString = jsonString;
            this.stateLoader = stateLoader;
        }

        internal override void PerformOperations()
        {
           // Check for Update run records, if there are records, update the state else stay same
            this.UpdateState();
        }

        private void UpdateState()
        {
            // next state is Setup_Started
            this.stateLoader.CurrentState = new PatchRun_Created(this);
        }
    }
}
