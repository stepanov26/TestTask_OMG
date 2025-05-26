using UnityEngine;

namespace Jigsawgram.UI.View
{
    public class SubscreenParent : MonoBehaviour
    {
        private BaseSubscreen _subscreen;

        public void SetSubscreen(BaseSubscreen subscreen)
        {
            _subscreen = subscreen;
            name = $"{subscreen.name}Parent";

            if (_subscreen != null)
            {
                _subscreen.OnClosed += OnSubscreenClosed;
            }
        }

        private void OnSubscreenClosed()
        {
            Destroy(gameObject);
        }

        private void OnDestroy()
        {
            if (_subscreen != null)
            {
                _subscreen.OnClosed -= OnSubscreenClosed;
            }
        }
    }
}