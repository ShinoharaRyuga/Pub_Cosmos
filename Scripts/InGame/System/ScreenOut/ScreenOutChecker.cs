using Cosmos.Utility;
using System.Collections.Generic;
using UnityEngine;

namespace Cosmos.InGame.System
{
    /// <summary>
    /// �e��G�Ȃǂ̃I�u�W�F�N�g���J�����͈̔͊O�ɏo�����`�F�b�N���邭�炷
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
        /// �J�����͈̔͊O�ɏo�����ǂ������肷��
        /// </summary>
        /// <returns></returns>
        private bool CheckScreenOut(Vector3 objectPosition)
        {
            Vector3 viewPosition = Camera.main.WorldToViewportPoint(objectPosition);

            bool xCheck = viewPosition.x < CheckMinValue || viewPosition.x > CheckMaxValue; //x�����J�����͈̔͊O���`�F�b�N
            bool yCheck = viewPosition.y < CheckMinValue || viewPosition.y > CheckMaxValue; //y�����J�����͈̔͊O���`�F�b�N

            if (xCheck || yCheck)  //�J�����͈̔͊O
            {
                return true;
            }

            return false;
        }
    }
}


