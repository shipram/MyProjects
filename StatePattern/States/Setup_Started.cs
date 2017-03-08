namespace StatePattern
{
    internal class Setup_Started : State
    {
        // to take values from the old state
        internal Setup_Started(State oldState)
            : this(oldState.jsonString, oldState.stateLoader)
        {
        }

        internal Setup_Started(string jsonString, StateLoader stateLoader)
        {
            this.jsonString = jsonString;
            this.stateLoader = stateLoader;
        }

        internal override void PerformOperations()
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
