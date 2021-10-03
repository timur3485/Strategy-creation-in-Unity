using System;

//не знаю что должно быть в этом классе, но без его создания Unity выдовала ошибку
public class ScriptableObjectValueBase<TAwaited>
{
    public Action<TAwaited> OnNewValue;
    
}
