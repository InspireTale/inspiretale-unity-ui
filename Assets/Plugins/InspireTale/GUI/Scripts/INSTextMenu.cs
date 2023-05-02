
namespace InspireTale.UI
{
#if UNITY_EDITOR
    using UnityEngine;
    using UnityEditor;
    public class INSTextMenu : MonoBehaviour
    {
        [MenuItem("GameObject/UI/InspierTale/INSText")]
        private static void CreateINSTextObject(MenuCommand menuCommand)
        {
            GameObject gameObject = new GameObject("INSText");
            INSText text = gameObject.AddComponent<INSText>();
            text.text = "Text";
            GameObjectUtility.SetParentAndAlign(gameObject, Selection.activeGameObject);
            Undo.RegisterCreatedObjectUndo(gameObject, $"Create {gameObject.name}");
            Selection.activeObject = gameObject;
        }

        [MenuItem("GameObject/UI/InspierTale/INSTextMesh")]
        private static void CreateINSTextMeshObject(MenuCommand menuCommand)
        {
            GameObject gameObject = new GameObject("INSTextMesh");
            INSTextMesh textMesh = gameObject.AddComponent<INSTextMesh>();
            textMesh.text = "Text";
            GameObjectUtility.SetParentAndAlign(gameObject, Selection.activeGameObject);
            Undo.RegisterCreatedObjectUndo(gameObject, $"Create {gameObject.name}");
            Selection.activeObject = gameObject;
        }
    }
#endif
}
