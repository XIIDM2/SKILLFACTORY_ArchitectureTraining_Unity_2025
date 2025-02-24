using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PresenterWindowBase<TWindow> where TWindow : WindowBase
{
    public abstract void SetWindow(TWindow window);
}
