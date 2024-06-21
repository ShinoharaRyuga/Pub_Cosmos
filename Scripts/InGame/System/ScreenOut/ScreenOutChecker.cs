using Cosmos.Utility;
using System.Collections.Generic;
using UnityEngine;

namespace Cosmos.InGame.System
{
    /// <summary>
    /// 弾や敵などのオブジェクトがカメラの範囲外に出たかチェックするくらす
    /// </summary>
    public class ScreenOutChecker : SingletonMonoBehaviour<ScreenOutChecker>
    {
        private const float CheckMinValue = 0f;
        private const float CheckMaxValue = 1f;

        private List<IScreenOut> _checkObjects = new List<IScreenOut>();

        protected override bool IsDontDestroyOnLoad => false;

        private void Update()
        {
            if (_checkObjects.Count <= 0) { return; }

            for (int i = 0; i < _checkObjects.Count; i++)
            {
                IScreenOut obj = _checkObjects[i];

                if (CheckScreenOut(obj.SelfObject.transform.position))
                {
                    _checkObjects.Remove(obj);
                    Destroy(obj.SelfObject);
                }
            }
        }

        public void AddCheckObject(IScreenOut target)
        {
            _checkObjects.Add(target);
        }

        /// <summary>
        /// カメラの範囲外に出たかどうか判定する
        /// </summary>
        /// <returns></returns>
        private bool CheckScreenOut(Vector3 objectPosition)
        {
            Vector3 viewPosition = Camera.main.WorldToViewportPoint(objectPosition);

            bool xCheck = viewPosition.x < CheckMinValue || viewPosition.x > CheckMaxValue; //x軸がカメラの範囲外かチェック
            bool yCheck = viewPosition.y < CheckMinValue || viewPosition.y > CheckMaxValue; //y軸がカメラの範囲外かチェック

            if (xCheck || yCheck)  //カメラの範囲外
            {
                return true;
            }

            return false;
        }
    }
}


