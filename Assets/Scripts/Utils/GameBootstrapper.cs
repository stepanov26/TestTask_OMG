using Jigsawgram.Managers;
using Jigsawgram.Models;
using Jigsawgram.UI.Model.Screens.MainScreen;
using Jigsawgram.UI.View.Screens.MainScreen;
using UnityEngine;
using Zenject;

namespace Jigsawgram.Utils
{
    public class GameBootstrapper : MonoBehaviour
    {
        private GuiManager _guiMnager;
        private ResourcesModel _resourcesModel;
        private PuzzlesModel _puzzlesModel;

        [Inject]
        private void Construct(GuiManager guiManager, ResourcesModel resourcesModel, PuzzlesModel puzzlesModel)
        {
            _guiMnager = guiManager;
            _resourcesModel = resourcesModel;
            _puzzlesModel = puzzlesModel;
        }

        private void Start()
        {
            _resourcesModel.AddCoins(1000);
            var screen = _guiMnager.ShowScreen<MainScreenView>();
            screen.Init(new MainScreenModel(_resourcesModel, _guiMnager, _puzzlesModel));
        }
    }
}