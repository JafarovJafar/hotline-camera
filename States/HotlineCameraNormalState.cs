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

            _context.HorRotDummy.position = _context.Target.position;
        }

        public void Exit()
        {

        }
    }
}