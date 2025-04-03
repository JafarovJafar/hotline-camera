using UnityEngine;

namespace Shafir.HotlineCameraSpace
{
    /// <summary>
    /// Плавно двигает камеру к целевой позиции
    /// </summary>
    internal class HotlineCameraLerper : MonoBehaviour
    {
        [SerializeField] private Transform cameraTransform;
        [SerializeField] private Transform goalTransform;
        [SerializeField] private float speed = 10f;

        private void Update()
        {
            var finalPos = Vector3.Lerp(cameraTransform.position, goalTransform.position, speed * Time.deltaTime);
            cameraTransform.position = finalPos;
        }
    }
}