using UnityEngine;

namespace Shafir.HotlineCameraSpace.Test
{
    internal class HotlineCameraTestAdapter : MonoBehaviour
    {
        private HotlineCamera _hotlineCamera;

        public void Initialize(HotlineCamera hotlineCamera)
        {
            _hotlineCamera = hotlineCamera;
        }

        private void Update()
        {
            var mousePos = Input.mousePosition;
            var screenSize = new Vector2(Screen.width, Screen.height);
            var viewport = new Vector2(mousePos.x / screenSize.x, mousePos.y / screenSize.y);
            var isFocusPressed = Input.GetMouseButton(1);

            var input = _hotlineCamera.Input;
            input.ViewportPos = viewport;
            input.IsFocusPressed = isFocusPressed;
        }
    }
}