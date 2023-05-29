using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Boss
{
    public class BossStateBase : StateBase
    {
        protected BossBase boss;
        public override void OnStateEnter(params object[] objs)
        {
            base.OnStateEnter(objs);

            boss = (BossBase)objs[0];

        }
    }

    public class BossStateInit : BossStateBase
    {
        public override void OnStateEnter(params object[] objs)
        {
            base.OnStateEnter(objs);
            boss.StartInitAnimation(OnAnimationEnd);
        }

        private void OnAnimationEnd()
        {
            boss.SwitchState(BossActions.WALK);
        }
    }

    public class BossStateWalk : BossStateBase
    {
        public override void OnStateEnter(params object[] objs)
        {
            base.OnStateEnter(objs);
            boss.GoToRandomPoint(OnArrive);
        }

        private void OnArrive()
        {
            boss.SwitchState(BossActions.ATTACK);
        }

        public override void OnStateExit()
        {
            base.OnStateExit();
            boss.StopAllCoroutines();
        }
    }

    public class BossStateAttack : BossStateBase
    {

        public override void OnStateEnter(params object[] objs)
        {
            base.OnStateEnter(objs);
            boss.StartAttack(OnAttackEnd);
        }

        private void OnAttackEnd()
        {
            boss.SwitchState(BossActions.WALK);
        }

        public override void OnStateExit()
        {
            base.OnStateExit();
            boss.StopAllCoroutines();
        }

    }

    public class BossStateDeath: BossStateBase
    {
        public override void OnStateEnter(params object[] objs)
        {
            base.OnStateEnter(objs);
        }
    }
}
