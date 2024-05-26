using UnityEngine;

namespace Utilities
{
    public class CursorHandler
    {
        public void LockCursor()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}