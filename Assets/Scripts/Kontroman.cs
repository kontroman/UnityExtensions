namespace DevotionEntertainment
{
    using System.Collections;
    using UnityEngine;
    using UnityEngine.UI;

    public class KontromanMono : KomaBase
    {
        /// <summary>
        /// Change the alpha of the color by time
        /// </summary>
        /// <param name="material">Material color attached to</param>
        /// <param name="from">Start alpha value</param>
        /// <param name="to">End alpha value</param>
        /// <param name="time">Duration</param>
        public override void ChangeAlphaSmoothly(Image material, float from, float to, float time)
        {
            StartCoroutine(ChangeAlpha(material, from, to, time));
        }

        IEnumerator ChangeAlpha(Image material, float from, float to, float time)
        {
            float alpha = material.color.a;

            for (float t = 0.0f; t < time; t += Time.deltaTime / time)
            {
                Color newColor = new Color(material.color.r, material.color.g, material.color.b, Mathf.Lerp(from, to, t));
                material.color = newColor;
                yield return null;
            }
        }

        /// <summary>
        /// Default Instantiate method
        /// </summary>
        /// <param name="prefab">Object to Instantiate</param>
        /// <param name="parent">Transform` attach to</param>
        /// <returns>Instantiated GameObject</returns>
        public override GameObject InstantiateAsChild(GameObject prefab, Transform parent)
        {
            GameObject go = Instantiate(prefab, new Vector3(0,0,0), Quaternion.identity);

            go.transform.SetParent(parent);
            go.transform.localPosition = new Vector3(0, 0, 0);

            return go;
        }


        /// <summary>
        /// Instantiate object with rotation
        /// </summary>
        /// <param name="prefab">Object to Instantiate</param>
        /// <param name="parent">Transform` attach to</param>
        /// <param name="rotation">Rotation apply to object</param>
        /// <returns>Instantiated GameObject</returns>
        public override GameObject InstantiateAsChild(GameObject prefab, Transform parent, Quaternion rotation)
        {
            GameObject go = Instantiate(prefab, new Vector3(0, 0, 0), rotation);

            go.transform.SetParent(parent);
            go.transform.localPosition = new Vector3(0, 0, 0);

            return go;
        }
        /// <summary>
        /// Instantiate object with local position to parent
        /// </summary>
        /// <param name="prefab">Object to Instantiate</param>
        /// <param name="parent">Transform` attach to</param>
        /// <param name="position">Position apply to object</param>
        /// <returns>Instantiated GameObject</returns>
        public override GameObject InstantiateAsChild(GameObject prefab, Transform parent, Vector3 position)
        {
            GameObject go = Instantiate(prefab, position, Quaternion.identity);

            go.transform.SetParent(parent, false);
            go.transform.localPosition = position;

            return go;
        }
        /// <summary>
        /// Default Instantiate with all parametrs
        /// </summary>
        /// <param name="prefab">Object to Instantiate</param>
        /// <param name="parent">Transform` attach to</param>
        /// <param name="position">Position apply to object</param>
        /// <param name="rotation">Rotation apply to object</param>
        /// <returns>Instantiated GameObject</returns>
        public override GameObject InstantiateAsChild(GameObject prefab, Transform parent, Vector3 position, Quaternion rotation)
        {
            GameObject go = Instantiate(prefab, position, rotation);

            go.transform.SetParent(parent, false);
            go.transform.localPosition = position;

            return go;
        }

        /// <summary>
        /// Checks if any animation is currently playing on object
        /// </summary>
        /// <param name="obj">Object on which the animation is played </param>
        /// <returns></returns>
        public override bool IsPlayingAnimation(GameObject obj)
        {
            Animator animator = obj.GetOrAddComponent<Animator>();

            return animator.GetCurrentAnimatorStateInfo(0).length > 
                animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
        }

        /// <summary>
        /// Checks if any animation is currently playing in animator
        /// </summary>
        /// <param name="animator">Animator on which the animation is played</param>
        /// <returns></returns>
        public override bool IsPlayingAnimation(Animator animator)
        {
            return animator.GetCurrentAnimatorStateInfo(0).length >
                animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
        }
    }
}

