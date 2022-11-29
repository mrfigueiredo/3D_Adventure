using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Singleton<PlayerController>
{
    public enum CharacterStates
    {
        IDLE,
        JUMP,
        MOVE
    }

    public StateMachine<CharacterStates> stateMachine;

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
        stateMachine.RegisterState(CharacterStates.IDLE, new CharStates.CSIdle());
        stateMachine.RegisterState(CharacterStates.JUMP, new CharStates.CSJump());
        stateMachine.RegisterState(CharacterStates.MOVE, new CharStates.CSMove());

        stateMachine.SwitchState(CharacterStates.IDLE);
    }

}
