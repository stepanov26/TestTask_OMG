using UnityEngine;

namespace Jigsawgram.UI.View
{
    public class BaseScreen : MonoBehaviour
    {
        [SerializeField]
        private Transform _subscreensContainer;
        
        public Transform SubscreensContainer => _subscreensContainer;
        
        public void Close()
        {
            Destroy(gameObject);
        }
    }
}