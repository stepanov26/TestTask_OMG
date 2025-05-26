using System.Collections.Generic;
using System.Linq;
using Jigsawgram.UI.View;
using UnityEngine;

namespace Jigsawgram.Utils
{
    [CreateAssetMenu(fileName = "GuiDatabase", menuName = "Database/GuiDatabase")]
    public class GuiDatabase : ScriptableObject
    {
        [SerializeField] private List<BaseSubscreen> _subscreens;
        [SerializeField] private List<BaseScreen> _screens;

        public T GetSubscreen<T>() where T : BaseSubscreen
        {
            var window = _subscreens.First(x => x.GetType() == typeof(T));
            if (window ==null)
            {
                Debug.LogError($"Window of type {typeof(T)} not found in the database.");
                return null;
            }

            return window as T;
        }

        public T GetScreen<T>() where T : BaseScreen
        {
            var screen = _screens.First(x => x.GetType() == typeof(T));
            if (screen == null)
            {
                Debug.LogError($"Screen of type {typeof(T)} not found in the database.");
                return null;
            }

            return screen as T;
        }
    }
}