using Jigsawgram.Utils;
using UnityEngine;

namespace Jigsawgram.Models
{
    public class ResourcesModel
    {
        private const string COINS_AMOUNT_KEY = nameof(ResourcesModel) + "_COINS_AMOUNT";

        private ReactiveProperty<int> _coinsAmount;

        public IReactiveProperty<int> CoinsAmount => _coinsAmount;

        public ResourcesModel()
        {
            _coinsAmount = new ReactiveProperty<int>(PlayerPrefs.GetInt(COINS_AMOUNT_KEY, 0));
        }

        public bool TryUseCoins(int amount)
        {
            if (_coinsAmount.Value >= amount)
            {
                _coinsAmount.Value -= amount;
                PlayerPrefs.SetInt(COINS_AMOUNT_KEY, _coinsAmount.Value);
                return true;
            }

            return false;
        }

        public void AddCoins(int amount)
        {
            _coinsAmount.Value += amount;
            PlayerPrefs.SetInt(COINS_AMOUNT_KEY, _coinsAmount.Value);
        }
    }
}