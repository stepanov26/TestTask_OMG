using System;
using Jigsawgram.Enums;
using Jigsawgram.Utils;
using UnityEngine;

namespace Jigsawgram.UI.View
{
    public class PuzzlesScrollItemModel : IPuzzlesScrollItemViewModel
    {
        public Sprite PuzzleSprite { get; }
        public bool IsLocked { get; }

        private readonly PuzzleData _puzzleData;
        private readonly Action<PuzzleData> _onClick;

        public PuzzlesScrollItemModel(PuzzleData puzzleData, Action<PuzzleData> onClick)
        {
            _puzzleData = puzzleData;
            PuzzleSprite = _puzzleData.Sprite;
            IsLocked = _puzzleData.PurchaseType != PurchaseType.None;

            _onClick = onClick;
        }

        public void Click()
        {
            _onClick?.Invoke(_puzzleData);
        }
    }
}