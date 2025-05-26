using Jigsawgram.Enums;
using Jigsawgram.Models;
using Jigsawgram.Utils;
using UnityEngine;

namespace Jigsawgram.Models
{
    public class PuzzlesModel
    {
        private const string PURCHASED_PUZZLES_KEY = nameof(PuzzlesModel) + "_PURCHASED_PUZZLES";
        
        private string _purchasedPuzzleIds;
        private readonly ResourcesModel _resourcesModel;
        
        public PuzzlesModel(ResourcesModel resourcesModel)
        {
            _resourcesModel = resourcesModel;
            
            _purchasedPuzzleIds = PlayerPrefs.GetString(PURCHASED_PUZZLES_KEY);
        }
        
        public bool IsPuzzlePurchased(PuzzleData puzzleData)
        {
            return puzzleData.PurchaseType == PurchaseType.None || _purchasedPuzzleIds.Contains(puzzleData.Id);
        }

        public bool TryPurchase(PuzzleData puzzleData)
        {
            if (_resourcesModel.TryUseCoins(puzzleData.Price))
            {
                _purchasedPuzzleIds = $"{_purchasedPuzzleIds}, {puzzleData.Id}";
                PlayerPrefs.SetString(PURCHASED_PUZZLES_KEY, _purchasedPuzzleIds);
                return true;
            }
            
            return false;
        }
    }

}
