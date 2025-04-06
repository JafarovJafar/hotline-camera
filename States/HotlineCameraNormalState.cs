using System;
using Shafir.FSM;

namespace Shafir.HotlineCameraSpace
{
    internal class HotlineCameraNormalState : ITickableState
    {
        public event Action FocusRequested;

        private Context _context;

        public HotlineCameraNormalState(Context context)
        {
            _context = context;
        }

        public void Enter()
        {

        }

        public void Tick()
        {
            if (_context.Input.IsFocusPressed)
            {
                FocusRequested?.Invoke();
                return;
            }

            var goalPos = _context.Target.position;
            goalPos.y = 0f;

            _context.HorRotDummy.position = goalPos;
        }

        public void Exit()
        {

        }
    }
}