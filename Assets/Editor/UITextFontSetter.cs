using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

namespace Modules.Util
{
    public class UITextFontSetter
    {
        // ��Ʈ ��� ����
        public const string PATH_FONT_TEXTMESHPRO_NEO = "Assets/TextMesh Pro/Fonts/neodgm SDF.asset";

        [MenuItem("Tools/��ü ��Ʈ ����")]
        public static void ChangeFontInTexMeshPro()
        {
            GameObject[] rootObj = GetSceneRootObjects();

            for (int i = 0; i < rootObj.Length; i++)
            {
                GameObject gbj = rootObj[i];
                TextMeshProUGUI[] texts = gbj.GetComponentsInChildren<TextMeshProUGUI>(true);

                foreach (TextMeshProUGUI txt in texts)
                {
                    txt.font = AssetDatabase.LoadAssetAtPath<TMP_FontAsset>(PATH_FONT_TEXTMESHPRO_NEO);
                    // ��Ʈ �� ���� ����
                    // txt.color = Color.black;
                }
            }
        }

        /// <summary>
        /// ��� �ֻ��� Root�� GameObject�� �޾ƿ�
        /// </summary>
        private static GameObject[] GetSceneRootObjects()
        {
            Scene currentScene = SceneManager.GetActiveScene();
            return currentScene.GetRootGameObjects();
        }
    }
}
