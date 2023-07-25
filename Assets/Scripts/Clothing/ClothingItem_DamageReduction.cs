using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Clothing
{
    public class ClothingItem_DamageReduction : ClothingItemBase
    {
        public float damageReductionFactor = 0.5f;

        private PlayerBase _player;

        private void Start()
        {
            _player = FindObjectOfType<PlayerBase>();
        }

        protected override void Collect()
        {
            base.Collect();
            _player.ChangeDamageFactor(damageReductionFactor,duration);
            StartCoroutine(OnCollectAnim());
        }

        private IEnumerator OnCollectAnim()
        {

            DOTween.Kill(transform);
            yield return new WaitForSeconds(0.1f);
            Destroy(gameObject);

        }
    }
}
