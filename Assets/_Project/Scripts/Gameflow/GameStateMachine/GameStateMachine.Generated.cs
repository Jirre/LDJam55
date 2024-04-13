using JvLib.StateMachine;

namespace Project.StateMachines
{
    ///////////////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////
    // This code is generated. Your changes will be reverted on regeneration
    // Use GameStateMachine.cs
    ///////////////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////
    public partial class GameStateMachine : StateMachine<GameStates, GameState, GameStateMachine>
    {
        protected virtual void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            AddState<InitState>(GameStates.Init);
            AddState<MainMenuState>(GameStates.MainMenu);
            AddState<GameplayState>(GameStates.Gameplay);
            AddState<PauseState>(GameStates.Pause);
            AddState<InitGameState>(GameStates.InitGame);
            AddState<GameOverState>(GameStates.GameOver);

            CreateTransition(GameStates.Init, GameStates.MainMenu);
            CreateTransition(GameStates.MainMenu, GameStates.InitGame);
            CreateTransition(GameStates.InitGame, GameStates.Gameplay);
            CreateTransition(GameStates.Gameplay, GameStates.Pause);
            CreateTransition(GameStates.Gameplay, GameStates.GameOver);
            CreateTransition(GameStates.Pause, GameStates.MainMenu);
            CreateTransition(GameStates.GameOver, GameStates.MainMenu);


            SetStartState(GameStates.Init);

            EnterStartState();
        }
    }

    public enum GameStates
    {
        Init,
        MainMenu,
        Gameplay,
        Pause,
        InitGame,
        GameOver,
    }
}
