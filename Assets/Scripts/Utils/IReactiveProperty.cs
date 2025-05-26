using System;

namespace Jigsawgram.Utils
{
    public interface IReactiveProperty<T>
    {
        T Value { get; }
        event Action<T> ValueChanged;
    }
}