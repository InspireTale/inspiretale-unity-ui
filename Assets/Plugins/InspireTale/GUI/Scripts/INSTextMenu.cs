
namespace InspireTale.UI
{
#if UNITY_EDITOR
    using UnityEngine;
    using UnityEditor;
    public class INSTextMenu : MonoBehaviour
    {
        [MenuItem("GameObject/UI/InspierTale/INSText")]
        private static void CreateINSTextObject()
        {
            GameObject gameObject = new("INSText");
            INSText text = gameObject.AddComponent<INSText>();
            text.text = "Text";
            text.color = Color.black;
            GameObjectUtility.SetParentAndAlign(gameObject, Selection.activeGameObject);
            Undo.RegisterCreatedObjectUndo(gameObject, $"Create {gameObject.name}");
            Selection.activeObject = gameObject;
        }

        [MenuItem("GameObject/UI/InspierTale/INSTextMesh")]
        private static void CreateINSTextMeshObject()
        {
            GameObject gameObject = new("INSTextMesh");
            INSTextMesh textMesh = gameObject.AddComponent<INSTextMesh>();
            textMesh.text = "Text";
            textMesh.color = Color.black;
            GameObjectUtility.SetParentAndAlign(gameObject, Selection.activeGameObject);
            Undo.RegisterCreatedObjectUndo(gameObject, $"Create {gameObject.name}");
            Selection.activeObject = gameObject;
        }
    }
#endif
}
