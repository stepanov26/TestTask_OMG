using Jigsawgram.Enums;
using Jigsawgram.Utils;
using UnityEngine;

namespace Jigsawgram.UI.View.Subscreens.StartLevel
{
    public interface IStartLevelSubscreenViewModel
    {
        ReactiveProperty<bool> IsPurchased { get; }
        PuzzleData PuzzleData { get; }

        void SelectGrid(GridType gridType);
        void StartLevel();
        void TryPurchasePuzzle();
    }   
}
