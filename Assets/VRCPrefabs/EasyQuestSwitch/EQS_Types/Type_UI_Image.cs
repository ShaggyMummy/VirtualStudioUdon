#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using EasyQuestSwitch.Fields;

namespace EasyQuestSwitch.Types
{
    public class Type_UI_Image : Type_Base
    {
        [System.NonSerialized]
        private Image type;

        public SharedMaterial Mat = new SharedMaterial();

        public override void Setup(Object type)
        {
            Image component = (Image)type;
            Mat.Setup(component.material);
        }

        public override void Process(Object type, BuildTarget buildTarget)
        {
            Image component = (Image)type;
            switch (buildTarget)
            {
                case BuildTarget.StandaloneWindows64:
                    component.material = Mat.PC;
                    break;
                case BuildTarget.Android:
                    component.material = Mat.Quest;
                    break;
                default:
                    break;
            }
        }
    }
}
#endif