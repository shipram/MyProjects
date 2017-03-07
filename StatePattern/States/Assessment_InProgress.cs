using StatePattern.States;
namespace StatePattern
{
    using System;

    public class Assessment_InProgress : State
    {
        // to take values from the old state
        public Assessment_InProgress(State oldState)
            : this(oldState.jsonString, oldState.stateLoader)
        {
        }

        //to pass on to the next state
        public Assessment_InProgress(string jsonString, StateLoader stateLoader)
        {
            this.jsonString = jsonString;
            this.stateLoader = stateLoader;
        }

        public override void PerformOperations()
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
