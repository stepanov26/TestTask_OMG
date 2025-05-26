using UnityEngine;
using UnityEngine.UI;

namespace Jigsawgram.UI.View
{
    public class PuzzlesScrollItemView : MonoBehaviour
    {
        [SerializeField] 
        private Button _button;
        
        [SerializeField]
        private Image _puzzleImage;

        [SerializeField] 
        private GameObject _lockIcon;

        private IPuzzlesScrollItemViewModel _model;
        
        public void Init(IPuzzlesScrollItemViewModel model)
        {
            _model = model;
            
            _button.onClick.AddListener(() => _model.Click());
            
            _puzzleImage.sprite = _model.PuzzleSprite;
            _lockIcon.SetActive(_model.IsLocked);
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveAllListeners();
        }
    }   
}
