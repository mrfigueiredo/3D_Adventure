using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public enum GameStates
    {
        INTRO,
        GAMEPLAY,
        PAUSE,
        WIN,
        LOSE,
    }

    public StateMachine<GameStates> stateMachine;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        FSMInitialization();
    }

    private void FSMInitialization()
    {
        stateMachine.Init();
        stateMachine.RegisterState(GameStates.INTRO, new GMStates.GMStateIntro());
        stateMachine.RegisterState(GameStates.GAMEPLAY, new GMStates.GMStateGameplay());
        stateMachine.RegisterState(GameStates.PAUSE, new GMStates.GMStatePause());
        stateMachine.RegisterState(GameStates.WIN, new GMStates.GMStateWin());
        stateMachine.RegisterState(GameStates.LOSE, new GMStates.GMStateLose());

        stateMachine.SwitchState(GameStates.INTRO);
    }

}
