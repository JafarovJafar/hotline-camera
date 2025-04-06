using System;
using Shafir.FSM;

namespace Shafir.HotlineCameraSpace
{
    internal class HotlineCameraFocusState : ITickableState
    {
        public event Action Finished;

        private Context _context;

        public HotlineCameraFocusState(Context context)
        {
            _context = context;
        }

        public void Enter()
        {

        }

        public void Tick()
        {
            if (_context.Input.IsFocusPressed == false)
            {
                Finished?.Invoke();
                return;
            }

            var viewportPos = _context.Input.ViewportPos;
            viewportPos.x -= 0.5f;
            viewportPos.y -= 0.5f;
            viewportPos *= 2f;

            var maxRange = _context.MaxRange;

            var finalPos = _context.Target.position;
            finalPos.x += maxRange * viewportPos.x;
            finalPos.z += maxRange * viewportPos.y;

            _context.HorRotDummy.position = finalPos;
        }

        public void Exit()
        {

        }
    }
}