using UnityEngine;

namespace Cosmos.InGame.System
{
    public class RangeOutGizmoDrawer : MonoBehaviour
    {
        [SerializeField]
        private bool _isGizomDraw = false;
        [SerializeField]
        private Color _gizomColor = Color.white;

        private void OnDrawGizmos()
        {
            if (!_isGizomDraw) { return; }

            Gizmos.color = _gizomColor;
            Gizmos.DrawWireCube(RangeOutChecker.Instance.transform.position, RangeOutChecker.Instance.Range);
        }
    }
}


