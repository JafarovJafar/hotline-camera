using UnityEngine;

namespace Shafir.HotlineCameraSpace.Test
{
    internal class HotlineCameraTestAdapterEntryPoint : MonoBehaviour
    {
        [SerializeField] private Transform playerDummy;
        [SerializeField] private HotlineCameraTestAdapter adapter;
        [SerializeField] private HotlineCamera hotlineCamera;
        [SerializeField] private float cameraRange = 1f;

        private void Start()
        {
            hotlineCamera.Initialize();
            hotlineCamera.SetTarget(playerDummy);
            adapter.Initialize(hotlineCamera);
        }

        private void Update()
        {
            hotlineCamera.SetRange(cameraRange);
        }
    }
}