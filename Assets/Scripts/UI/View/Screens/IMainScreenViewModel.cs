using Jigsawgram.Utils;

namespace Jigsawgram.UI.View.Screens.MainScreen
{
    public interface IMainScreenViewModel
    {
        IPuzzlesScrollViewModel PuzzlesScrollViewModel { get; }
        IReactiveProperty<int> CoinsAmount { get; }
    }
}