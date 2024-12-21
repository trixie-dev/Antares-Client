using UnityEngine;

namespace DefaultNamespace.Controllers
{
    public class CameraController : MonoBehaviour
    {
        public float moveSpeed = 10f; // Швидкість переміщення камери
        public float zoomSpeed = 5f; // Швидкість масштабування
        public float minZoom = 5f; // Мінімальне значення масштабу (ближче)
        public float maxZoom = 20f; // Максимальне значення масштабу (далі)

        private Vector3 lastMousePosition; // Остання позиція миші
        private Camera cam; // Силка на камеру

        void Start()
        {
            cam = Camera.main; // Отримання основної камери
        }

        void Update()
        {
            HandleMovement();
            HandleZoom();
        }

        // Обробка переміщення камери
        void HandleMovement()
        {
            if (Input.GetMouseButtonDown(0)) // Початок переміщення (права кнопка миші)
            {
                lastMousePosition = Input.mousePosition;
            }

            if (Input.GetMouseButton(0)) // Утримання правої кнопки миші
            {
                Vector3 delta = Input.mousePosition - lastMousePosition; // Різниця позицій миші
                Vector3 move = new Vector3(-delta.x, -delta.y, 0) * moveSpeed * Time.deltaTime;

                transform.Translate(move, Space.World); // Переміщення камери
                lastMousePosition = Input.mousePosition; // Оновлення останньої позиції миші
            }
        }

        // Обробка масштабування камери колесом миші з фокусом на позиції миші
        void HandleZoom()
        {
            float scroll = Input.GetAxis("Mouse ScrollWheel"); // Отримання значення прокрутки колеса миші
            if (scroll != 0)
            {
                // Позиція миші в світі
                Vector3 mouseWorldPosition = cam.ScreenToWorldPoint(Input.mousePosition);

                // Поточний розмір камери
                float oldSize = cam.orthographicSize;

                // Оновлення розміру камери
                cam.orthographicSize -= scroll * zoomSpeed;
                cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, minZoom, maxZoom);

                // Розрахунок різниці масштабу
                float scaleFactor = cam.orthographicSize / oldSize;

                // Зміщення камери, щоб утримати фокус на позиції миші
                Vector3 difference = mouseWorldPosition - transform.position;
                transform.position += difference * (1 - scaleFactor);
            }
        }
    }
}