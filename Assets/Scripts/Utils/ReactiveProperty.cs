namespace Jigsawgram.Utils
{
    using System;

    public class ReactiveProperty<T> : IReactiveProperty<T>
    {
        private T _value;

        public event Action<T> ValueChanged;

        public T Value
        {
            get => _value;
            set
            {
                if (!Equals(_value, value))
                {
                    _value = value;
                    ValueChanged?.Invoke(_value);
                }
            }
        }

        public ReactiveProperty(T initialValue = default)
        {
            _value = initialValue;
        }
    }
}