using System;
using UnityEngine;
using UserControlSystem;
using Utils;

//не знаю что должно быть в этом классе, но без его создания Unity выдовала ошибку
//TODO А э то было ваше домашнее задание, сделать базовый класс для всех SO
//TODO Плюс вам надо было реализовать интерфейс
public class ScriptableObjectValueBase<TAwaited> : ScriptableObject, IAwaitable<TAwaited>
{
    public Action<TAwaited> OnNewValue;

    public TAwaited CurrentValue { get; private set; }

    public void SetValue(TAwaited value)
    {
        CurrentValue = value;
        OnNewValue?.Invoke(CurrentValue);
    }

    public IAwaiter<TAwaited> GetAwaiter()
    {
        return new NewValueNotifier<TAwaited>(this);
    }
}
