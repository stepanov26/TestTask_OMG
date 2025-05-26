using System;
using Jigsawgram.Enums;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Jigsawgram.UI.View.Subscreens.StartLevel
{
    public class StartLevelSubscreenView : BaseSubscreen
    {
        [SerializeField] private Image _puzzleImage;
        
        [SerializeField] private Button _purchasePuzzleButton;

        [SerializeField] private TextMeshProUGUI _priceLabel;

        [SerializeField] private GameObject _priceLayout;

        [SerializeField] private GameObject _adLayout;

        [SerializeField] private GameObject _levelSettingsGroup;
        
        [SerializeField] private GridSelectorEntry[] _gridEntries;

        [SerializeField] private Color _defaultGridSelectorButtonColor;
        
        [SerializeField] private Color _selectedGridSelectorButtonColor;
        
        [SerializeField] private Button _startLevelButton;

        private IStartLevelSubscreenViewModel _model;
        private GridSelectorEntry _selectedGrid;

        public void Init(IStartLevelSubscreenViewModel model)
        {
            _model = model;

            _puzzleImage.sprite = model.PuzzleData.Sprite;
            
            _purchasePuzzleButton.onClick.AddListener(() => _model.TryPurchasePuzzle());
            _priceLayout.SetActive(_model.PuzzleData.PurchaseType == PurchaseType.GameCurrency);
            _adLayout.SetActive(_model.PuzzleData.PurchaseType == PurchaseType.Ad);
            _priceLabel.text = _model.PuzzleData.Price.ToString();
            
            _model.IsPurchased.ValueChanged += OnIsPurchasedChanged;
            OnIsPurchasedChanged(_model.IsPurchased.Value);
            
            foreach (var entry in _gridEntries)
            {
                entry.Grid.SetActive(false);
                entry.Button.targetGraphic.color = _defaultGridSelectorButtonColor;
                entry.Button.onClick.AddListener(() => SelectGrid(entry));
            }
            SelectGrid(_gridEntries[1]);

            _startLevelButton.onClick.AddListener(() => _model.StartLevel());
        }

        private void OnDestroy()
        {
            foreach (var entry in _gridEntries)
            {
                entry.Button.onClick.RemoveAllListeners();
            }
            _model.IsPurchased.ValueChanged -= OnIsPurchasedChanged;
        }

        private void OnIsPurchasedChanged(bool isPurchased)
        {
            _purchasePuzzleButton.gameObject.SetActive(!isPurchased);
            _levelSettingsGroup.SetActive(isPurchased);
        }

        private void SelectGrid(GridSelectorEntry entry)
        {
            if (_selectedGrid == entry)
            {
                return;
            }
            
            if (_selectedGrid != null)
            {
                _selectedGrid.Grid.SetActive(false);
                _selectedGrid.Button.targetGraphic.color = _defaultGridSelectorButtonColor;
            }
            
            _selectedGrid = entry;
            
            _model.SelectGrid(_selectedGrid.GridType);
            _selectedGrid.Grid.SetActive(true);
            _selectedGrid.Button.targetGraphic.color = _selectedGridSelectorButtonColor;
        }
        
        
        [Serializable]
        private class GridSelectorEntry
        {
            [SerializeField]
            private GridType _gridType;

            [SerializeField] 
            private GameObject _grid;
            
            [SerializeField]
            private Button _button;
            
            public GridType GridType => _gridType;
            public GameObject Grid => _grid;
            public Button Button => _button;
        }
    }
}
