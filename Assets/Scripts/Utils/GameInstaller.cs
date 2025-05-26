using Jigsawgram.Managers;
using Jigsawgram.Models;
using Jigsawgram.UI.View;
using UnityEngine;
using Zenject;

namespace Jigsawgram.Utils
{
    public class GameInstaller : MonoInstaller
    { 
        [SerializeField] private Canvas _guiCanvasPrefab;
        [SerializeField] private SubscreenParent _subscreenParentPrefab;

        public override void InstallBindings()
        {
            BindGuiManager();
            BindModels();
        }

        private void BindGuiManager()
        {
            var canvasInstance = Container.InstantiatePrefabForComponent<Canvas>(_guiCanvasPrefab);
            Container.Bind<GuiManager>().AsSingle().WithArguments(canvasInstance, _subscreenParentPrefab);
        }

        private void BindModels()
        {
            Container.Bind<ResourcesModel>().AsSingle();
            Container.Bind<PuzzlesModel>().AsSingle();
        }
    }
}