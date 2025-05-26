using System;
using Jigsawgram.Utils;
using UnityEngine;

namespace Jigsawgram.UI.View
{
    public interface IPuzzlesScrollItemViewModel
    {
        Sprite PuzzleSprite { get; }
        bool IsLocked { get;  }
        void Click();
    }
}
