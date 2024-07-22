using Cosmos.Utility;
using System.Collections.Generic;
using UnityEngine;

namespace Cosmos.InGame.System
{
    /// <summary>
    /// 弾や敵などのオブジェクトが範囲外に出たかチェックするクラス
    /// </summary>
    public class RangeOutChecker : SingletonMonoBehaviour<RangeOutChecker>
    {
        [SerializeField, Min(1f)]
        private Vector2 _outRange;
        private List<IRangeOut> _checkObjects = new List<IRangeOut>();

        protected override bool IsDontDestroyOnLoad => false;

        public Vector2 Range => _outRange;

        private void Update()
        {
            if (_checkObjects.Count <= 0) { return; }

            List<IRangeOut> destroyList = new List<IRangeOut>();

            foreach (IRangeOut obj in _checkObjects)
            {
                if (CheckRangeOut(obj.SelfObject.transform.position))
                {
                    destroyList.Add(obj);
                }
            }

            foreach (IRangeOut obj in destroyList)
            {
                _checkObjects.Remove(obj);
                Destroy(obj.SelfObject);
            }

            destroyList.Clear();
        }

        public void AddCheckObject(IRangeOut target)
        {
            _checkObjects.Add(target);
        }

        public void RemoveCheckObject(IRangeOut target)
        {
            _checkObjects.Remove(target);
        }

        /// <summary>
        /// 範囲外に出たかどうか判定する
        /// </summary>
        /// <returns></returns>
        private bool CheckRangeOut(Vector3 objectPosition)
        {
            Vector2 range = _outRange / 2;

            bool xCheck = objectPosition.x < -range.x || objectPosition.x > range.x;
            bool yCheck = objectPosition.y < -range.y || objectPosition.y > range.y;

            if (xCheck || yCheck)
            {
                return true;
            }

            return false;
        }
    }
}


