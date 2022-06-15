namespace DevotionEntertainment
{
    using UnityEngine;
    using UnityEngine.UI;

    [RequireComponent(typeof(Button))]
    public class WindowTransition : MonoBehaviour
    {
        [SerializeField]
        protected GameObject current;

        [SerializeField]
        protected GameObject target;

        void Start()
        {
            GetComponent<Button>().onClick.AddListener(OnClick);
        }

        void OnClick()
        {
            if (current != null)
                current.SetActive(false);

            if (target != null)
                target.SetActive(true);
        }
    }
}