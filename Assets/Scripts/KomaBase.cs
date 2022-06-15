namespace DevotionEntertainment
{
    using UnityEngine;
    using UnityEngine.UI;

    public abstract class KomaBase : MonoBehaviour, IKoma
    {
        public abstract bool IsPlayingAnimation(GameObject obj);
        public abstract bool IsPlayingAnimation(Animator animator);
        public abstract void ChangeAlphaSmoothly(Image material, float from, float to, float time);
        public abstract GameObject InstantiateAsChild(GameObject prefab, Transform parent);
        public abstract GameObject InstantiateAsChild(GameObject prefab, Transform parent, Quaternion rotation);
        public abstract GameObject InstantiateAsChild(GameObject prefab, Transform parent, Vector3 position);
        public abstract GameObject InstantiateAsChild(GameObject prefab, Transform parent, Vector3 position, Quaternion rotation);
    }
}
