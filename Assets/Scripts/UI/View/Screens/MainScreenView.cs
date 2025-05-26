using TMPro;
using UnityEngine;

namespace Jigsawgram.UI.View.Screens.MainScreen
{
    public class MainScreenView : BaseScreen
    {
        [SerializeField] 
        private PuzzlesScrollView _puzzlesScrollView;

        [SerializeField]
        private TextMeshProUGUI _coinsAmountLabel;

        private IMainScreenViewModel _viewModel;

        public void Init(IMainScreenViewModel viewModel)
        {
            _viewModel = viewModel;
            
           _puzzlesScrollView.Init(_viewModel.PuzzlesScrollViewModel);
           _viewModel.CoinsAmount.ValueChanged += SetCoinsAmount;
           SetCoinsAmount(_viewModel.CoinsAmount.Value);
        }

        private void OnDestroy()
        {
            _viewModel.CoinsAmount.ValueChanged -= SetCoinsAmount;
        }

        public void SetCoinsAmount(int amount)
        {
            _coinsAmountLabel.text = amount.ToString();
        }
    }
}
