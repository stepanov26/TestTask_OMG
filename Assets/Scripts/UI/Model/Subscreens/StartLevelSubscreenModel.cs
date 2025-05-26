using Jigsawgram.Models;
using Jigsawgram.UI.View.Subscreens.StartLevel;
using Jigsawgram.Utils;

namespace Jigsawgram.UI.Model.Subscreens.StartLevel
{
    public class StartLevelSubscreenModel : IStartLevelSubscreenViewModel
    {
        public ReactiveProperty<bool> IsPurchased { get; }
        public PuzzleData PuzzleData { get; }
        
        private PuzzlesModel  _puzzlesModel;
        private GridType _selectedGridType;

        public StartLevelSubscreenModel(PuzzleData puzzleData, PuzzlesModel puzzlesModel)
        {
            _puzzlesModel = puzzlesModel;
            var isPurchased = _puzzlesModel.IsPuzzlePurchased(puzzleData);
            IsPurchased = new ReactiveProperty<bool>(isPurchased);
            PuzzleData = puzzleData;
        }

        public void SelectGrid(GridType gridType)
        {
            _selectedGridType = gridType;
        }

        public void StartLevel()
        {
            //TODO: Launch level
        }

        public void TryPurchasePuzzle()
        {
            if (_puzzlesModel.TryPurchase(PuzzleData))
            {
                IsPurchased.Value = true;
            }
        }
    }   
}
