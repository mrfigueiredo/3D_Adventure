using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Boss
{
    public enum BossActions
    {
        INIT,
        IDLE,
        WALK,
        ATTACK,
        DEATH
    }


    public class BossBase : HealthBase, IDamageable
    {
        private StateMachine<BossActions> _stateMachine;

        [Header("Movement")]
        public float speed = 5f;
        public float minDistanceToPoint = 1f;
        public List<Transform> waypoints;

        [Header("Animation")]
        public float startAnimationDuration = 1f;
        public Ease startAnimationEase = Ease.InBounce;
        public float attackAnimationDuration = 0.25f;
        public float attackScaleFactor = 0.25f;
        public Ease attackAnimationEase = Ease.OutBack;
        public FlashColor flashColor;
        public ParticleSystem damageVFX;

        [Header("Attack")]
        public int attackAmmount = 5;
        public float timeBetweenAttacks = 1.5f;
        public float damage = 25;
        public EnemyGun bossGun;
        private PlayerBase _player;

        protected override void Awake()
        {
            base.Init();
            init();
            base.OnKill += OnBossKill;
            base.OnDamage += OnDamageCB;
            _player = GameObject.FindObjectOfType<PlayerBase>();
        }

        private void init()
        {
            _stateMachine = new StateMachine<BossActions>();
            _stateMachine.Init();

            _stateMachine.RegisterState(BossActions.INIT, new BossStateInit());
            _stateMachine.RegisterState(BossActions.WALK, new BossStateWalk());
            _stateMachine.RegisterState(BossActions.ATTACK, new BossStateAttack());
            _stateMachine.RegisterState(BossActions.DEATH, new BossStateDeath());
        }

        private void OnBossKill(HealthBase healthBase)
        {
            SwitchState(BossActions.DEATH);
        }

        public void OnDamageCB(HealthBase healthBase)
        {
            if (flashColor != null)
                flashColor.Flash();

            if (damageVFX != null)
                damageVFX.Play();
        }

        #region STATE_MACHINE

        public void SwitchState(BossActions state)
        {
            _stateMachine.SwitchState(state, this);
        }

        #endregion

        #region MOVEMENT

        public void GoToRandomPoint(Action onArrive = null)
        {
            StartCoroutine(GoToPointCo(waypoints[UnityEngine.Random.Range(0, waypoints.Count)], onArrive));
        }

        IEnumerator GoToPointCo(Transform t, Action onArrive = null)
        {
            this.transform.LookAt(t);
            while (Vector3.Distance(transform.position, t.position) > minDistanceToPoint)
            {
                transform.position = Vector3.MoveTowards(transform.position, t.position, Time.deltaTime * speed);

                yield return new WaitForEndOfFrame();
            }

            onArrive?.Invoke();
                
        }

        #endregion

        #region ATTACK

        public void StartAttack(Action onAttackEnd = null)
        {
            StartCoroutine(AttackCoroutine(onAttackEnd));
        }

        IEnumerator AttackCoroutine(Action onAttackEnd = null)
        {
            int attacks = 0;
            while (attacks < attackAmmount)
            {
                attacks++;
                ShootAction();
                AttackAnimation();
                yield return new WaitForSeconds(timeBetweenAttacks);
            }
            onAttackEnd?.Invoke();
        }

        private void ShootAction()
        {
            this.transform.LookAt(_player.transform);
            bossGun.ShootAtTarget(_player.transform.position);
        }

        #endregion

        #region ANIMATION

        public void StartInitAnimation(Action OnAnimaitonEnd = null)
        {
            StartCoroutine(InitAnimationCoroutine(OnAnimaitonEnd));
        }

        IEnumerator InitAnimationCoroutine(Action OnAnimaitonEnd = null)
        {
            var anim = transform.DOScale(0, startAnimationDuration).SetEase(startAnimationEase).From();

            while(anim.active)
            {
                yield return new WaitForEndOfFrame();
            }
            OnAnimaitonEnd?.Invoke();
        }

        public void AttackAnimation()
        {
            transform.DOScale(attackScaleFactor, attackAnimationDuration).SetRelative().SetEase(attackAnimationEase).SetLoops(2, LoopType.Yoyo);
        }

        #endregion


        #region DEBUG
        [NaughtyAttributes.Button]
        public void SwitchInit()
        {
            SwitchState(BossActions.INIT);
        }

        [NaughtyAttributes.Button]
        public void SwitchWalk()
        {
            SwitchState(BossActions.WALK);
        }

        [NaughtyAttributes.Button]
        public void SwitchAttack()
        {
            SwitchState(BossActions.ATTACK);
        }
        #endregion
    }



}
