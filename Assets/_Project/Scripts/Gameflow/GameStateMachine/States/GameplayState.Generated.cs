namespace Project.StateMachines
{
    ///////////////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////
    // This code is generated. Your changes will be reverted on regeneration
    // Use GameplayState.cs
    ///////////////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////
    public partial class GameplayState
    {
        protected void TransitionToPauseState()
        {
            StateMachine.TransitionTo(GameStates.Pause);
        }
        protected void TransitionToGameOverState()
        {
            StateMachine.TransitionTo(GameStates.GameOver);
        }
    }
}
