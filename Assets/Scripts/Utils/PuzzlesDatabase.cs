using System;
using Jigsawgram.Enums;
using UnityEngine;

namespace Jigsawgram.Utils
{
    [CreateAssetMenu(fileName = nameof(PuzzlesDatabase), menuName = "Database/PuzzlesDatabase")]
    public class PuzzlesDatabase : ScriptableObject
    {
        [SerializeField]
        private PuzzleData[] _puzzles;
        
        public PuzzleData[] Puzzles => _puzzles;
    }

    [Serializable]
    public struct PuzzleData
    {
        [SerializeField] 
        private string _id;
        
        [SerializeField]
        private Sprite _sprite;
        
        [SerializeField]
        private PurchaseType _purchaseType;

        [SerializeField] 
        private int _price;
        
        public string Id => _id;
        public Sprite Sprite => _sprite;
        public PurchaseType PurchaseType => _purchaseType;
        public int Price => _price;
    }
}
