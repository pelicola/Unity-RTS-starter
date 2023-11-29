        using UnityEngine;

        public class SelectingObjects : MonoBehaviour
        {
            [SerializeField]
            private LayerMask objectLayer;
            [SerializeField]
            private new Camera camera;

            [SerializeField]
            private Color selectedColor, originalColor;
            private MeshRenderer lastSelected;

            void Start()
            {
                this.camera = Camera.main;
            }

            void Update()
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Ray ray = this.camera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out RaycastHit hit, 100, objectLayer))
                    {
                        //Can also use Draw Ray
                        Debug.DrawLine(ray.origin, hit.point, Color.red, 1f);

                        //cache material and colors before changing the color
                        lastSelected = hit.transform.GetComponent<MeshRenderer>();
                        originalColor = lastSelected.material.color;
                        lastSelected.material.color = selectedColor;
                    }
                }
                else if (Input.GetMouseButtonUp(0) && lastSelected != null)
                    lastSelected.material.color = originalColor;
            }
        }