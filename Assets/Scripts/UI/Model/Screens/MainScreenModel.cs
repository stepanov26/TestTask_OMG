using Jigsawgram.Managers;
using Jigsawgram.Models;
using Jigsawgram.UI.Model.Subscreens.StartLevel;
using Jigsawgram.UI.View;
using Jigsawgram.UI.View.Screens.MainScreen;
using Jigsawgram.UI.View.Subscreens.StartLevel;
using Jigsawgram.Utils;
using UnityEngine;

namespace Jigsawgram.UI.Model.Screens.MainScreen
{
    public class MainScreenModel : IMainScreenViewModel
    {
        public IPuzzlesScrollViewModel PuzzlesScrollViewModel { get; }
        public IReactiveProperty<int> CoinsAmount { get; }
        
        private readonly GuiManager _guiManager;
        private readonly PuzzlesModel _puzzlesModel;

        public MainScreenModel(ResourcesModel resourcesModel, GuiManager guiManager, PuzzlesModel puzzlesModel)
        {
            _guiManager = guiManager;
            _puzzlesModel = puzzlesModel;
            CoinsAmount = resourcesModel.CoinsAmount;

            var puzzlesDatabase = Resources.Load<PuzzlesDatabase>($"Databases/{nameof(PuzzlesDatabase)}");
            var puzzlesScrollItems = new PuzzlesScrollItemModel[puzzlesDatabase.Puzzles.Length];

            for (int i = 0; i < puzzlesDatabase.Puzzles.Length; i++)
            {
                puzzlesScrollItems[i] = new PuzzlesScrollItemModel(puzzlesDatabase.Puzzles[i], ShowStartLevelSubscreen);
            }
            
            PuzzlesScrollViewModel = new PuzzlesScrollModel(puzzlesScrollItems);
        }

        private void ShowStartLevelSubscreen(PuzzleData puzzleData)
        {
            var model = new StartLevelSubscreenModel(puzzleData, _puzzlesModel);
            _guiManager.ShowSubscreen<StartLevelSubscreenView>().Init(model);
        }
    }
}
