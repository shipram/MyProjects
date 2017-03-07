namespace StatePattern
{
    using System;

    using StatePattern.States;

    public class Setup_Started : State
    {
        // to take values from the old state
        public Setup_Started(State oldState)
            : this(oldState.jsonString, oldState.stateLoader)
        {
        }

        public Setup_Started(string jsonString, StateLoader stateLoader)
        {
            this.jsonString = jsonString;
            this.stateLoader = stateLoader;
        }

        public override void PerformOperations()
        {
            // Create VM, AA, WS, Link them, enable the solution
            this.UpdateState();
        }

        private void UpdateState()
        {
            // next state is Setup_Started
            this.stateLoader.CurrentState = new Assessment_InProgress(this);
        }
    }
}
