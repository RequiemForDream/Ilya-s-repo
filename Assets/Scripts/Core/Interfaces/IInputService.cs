using System;
using UnityEngine;

namespace Core.Interfaces
{
    public interface IInputService
    {
        event Action<Vector3> OnMove;
        event Action<Vector2> OnMouseLook;
        event Action OnLeftMouseButtonDown;
        event Action OnInteractBtnTap;
    }
}
