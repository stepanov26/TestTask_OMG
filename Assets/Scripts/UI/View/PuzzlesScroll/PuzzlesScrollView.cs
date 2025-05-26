using UnityEngine;

namespace Jigsawgram.UI.View
{
    public class PuzzlesScrollView : MonoBehaviour
    {
        [SerializeField]
        private PuzzlesScrollItemView _itemViewPrefab;
        
        [SerializeField]
        private RectTransform _content;

        private IPuzzlesScrollViewModel _model;
        
        public void Init(IPuzzlesScrollViewModel model)
        {
            _model = model;
            RefreshContent();
        }

        private void RefreshContent()
        {
            ClearContent();
            
            if (_model.ItemModels == null || _model.ItemModels.Length == 0)
            {
                return;
            }
            
            foreach (var itemModel in _model.ItemModels)
            {
                var itemView = Instantiate(_itemViewPrefab, _content);
                itemView.Init(itemModel);
            }
        }

        private void ClearContent()
        {
            foreach (Transform t in _content)
            {
                Destroy(t);
            }
        }
    }
}