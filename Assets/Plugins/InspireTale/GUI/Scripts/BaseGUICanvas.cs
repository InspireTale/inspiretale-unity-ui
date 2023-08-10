using Cysharp.Threading.Tasks;
using UnityEngine;

namespace InspireTale.UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class BaseGUICanvas : MonoBehaviour
    {
        [Tooltip("To make this canvas block the raycast.")]
        [SerializeField]
        protected bool isBlockRaycast;
        [Tooltip("Enable this to use object active for displaying instead of canvas group alpha.")]
        [SerializeField]
        protected bool isUseObjectActive;

        protected CanvasGroup canvasGroup;

        protected GameObject[] childrenList;

        protected virtual void Awake()
        {
            this.canvasGroup = GetComponent<CanvasGroup>();
            this.childrenList = new GameObject[this.transform.childCount];
            for (int i = 0; i < this.transform.childCount; i++)
            {
                Transform child = this.transform.GetChild(i);
                childrenList[i] = child.gameObject;
            }
        }

        public bool IsShow { get; protected set; }

        public virtual UniTask Show()
        {
            this.IsShow = true;
            canvasGroup.alpha = 1;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = this.isBlockRaycast;
            return UniTask.CompletedTask;
        }

        public virtual UniTask Hide()
        {
            this.IsShow = false;
            canvasGroup.alpha = 0;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
            return UniTask.CompletedTask;
        }
    }
}
