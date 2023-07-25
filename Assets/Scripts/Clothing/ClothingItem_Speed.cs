using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Clothing
{
    public class ClothingItem_Speed : ClothingItemBase
    {
        public float speed = 40f;
        public bool isMultiplier = false;
        public float speedMultiFactor = 2f;

        protected override void Collect()
        {
            base.Collect();
            MovementController.Instance.ChangeSpeed(
                isMultiplier?MovementController.Instance.GetBaseSpeed()*speedMultiFactor:speed,
                duration);
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
