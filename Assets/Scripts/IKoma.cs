namespace DevotionEntertainment
{
    using UnityEngine;
    using UnityEngine.UI;

    public interface IKoma
    {
        bool IsPlayingAnimation(GameObject obj);
        GameObject InstantiateAsChild(GameObject prefab, Transform parent);
        void ChangeAlphaSmoothly(Image material, float from, float to, float time);
    }
}