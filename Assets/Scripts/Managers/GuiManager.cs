using Jigsawgram.UI.View;
using Jigsawgram.Utils;
using UnityEngine;

namespace Jigsawgram.Managers
{
    public class GuiManager
    {
        private readonly Canvas _guiCanvas;
        private readonly SubscreenParent _subscreenParentPrefab;
        private readonly GuiDatabase _guiDatabase;
        
        private BaseScreen _currentScreen;

        private GuiManager(Canvas guiCanvas, SubscreenParent subscreenParentPrefab)
        {
            _guiCanvas = guiCanvas;
            _subscreenParentPrefab = subscreenParentPrefab;

            _guiDatabase = Resources.Load<GuiDatabase>($"Databases/{nameof(GuiDatabase)}");
        }

        public T ShowSubscreen<T>() where T : BaseSubscreen
        {
            var subscreenParent = Object.Instantiate(_subscreenParentPrefab, _currentScreen.SubscreensContainer);
            var subscreen = Object.Instantiate(_guiDatabase.GetSubscreen<T>(), subscreenParent.transform);

            subscreenParent.SetSubscreen(subscreen);
            subscreen.Open();

            return subscreen;
        }

        public T ShowScreen<T>() where T : BaseScreen
        {
            if (_currentScreen != null && _currentScreen.GetType() == typeof(T))
            {
                return _currentScreen as T;
            }

            if (_currentScreen != null)
            {
                _currentScreen.Close();
            }

            var screenPrefab = _guiDatabase.GetScreen<T>();
            var screen = Object.Instantiate(screenPrefab, _guiCanvas.transform);
            _currentScreen = screen;

            return screen;
        }
    }
}