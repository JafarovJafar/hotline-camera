using Shafir.HotlineCameraSpace;
using Shafir.FSM;
using UnityEngine;

namespace Shafir
{
    public class HotlineCamera : MonoBehaviour
    {
        public CameraInput Input => _input;
        public float Zoom => Mathf.Abs(zoomDummy.localPosition.z);
        public Vector3 Position => horRotDummy.position;

        [SerializeField] private Transform horRotDummy;
        [SerializeField] private Transform vertRotDummy;
        [SerializeField] private Transform zoomDummy;
        [SerializeField] private Camera mainCamera;

        private CameraInput _input;

        private TickableStateMachine _stateMachine;
        private Context _context;
        private HotlineCameraNormalState _normalState;
        private HotlineCameraFocusState _focusState;

        public void Initialize()
        {
            _input = new CameraInput();

            _context = new Context()
            {
                Input = _input,
                HorRotDummy = horRotDummy,
                VertRotDummy = vertRotDummy,
                ZoomDummy = zoomDummy,
            };

            _normalState = new HotlineCameraNormalState(_context);
            _normalState.FocusRequested += OnFocusRequested;
            _focusState = new HotlineCameraFocusState(_context);
            _focusState.Finished += OnFocusFinished;
            _stateMachine = new TickableStateMachine();
            _stateMachine.ChangeState(_normalState);

            enabled = false;
        }

        public void SetTarget(Transform target, bool moveCameraImmediately = false)
        {
            enabled = true;
            _context.Target = target;

            if (moveCameraImmediately == false)
                return;

            horRotDummy.position = target.position;
            mainCamera.transform.position = zoomDummy.position;
        }

        public void SetRange(float range)
        {
            _context.MaxRange = range;
        }

        public Vector3 ViewportToWorldPoint(Vector2 viewportPos)
        {
            var vector = new Vector3(viewportPos.x, viewportPos.y, Zoom + vertRotDummy.localPosition.y);
            var result = mainCamera.ViewportToWorldPoint(vector);
            return result;
        }

        public Vector3 GetRelativeDirection(Vector3 currentDirection) =>
            horRotDummy.TransformDirection(currentDirection);

        private void OnFocusRequested()
        {
            _stateMachine.ChangeState(_focusState);
        }

        private void OnFocusFinished()
        {
            _stateMachine.ChangeState(_normalState);
        }

        private void Update() => _stateMachine.Tick();
    }
}