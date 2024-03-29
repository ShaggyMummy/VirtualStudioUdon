﻿#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using EasyQuestSwitch.Fields;

namespace EasyQuestSwitch.Types
{
    public class Type_GameObject : Type_Base
    {
        [System.NonSerialized]
        private GameObject type;

        public SharedBool Active = new SharedBool();
        public SharedTag Tag = new SharedTag();
        public SharedLayer Layer = new SharedLayer();
        public SharedStaticEditorFlags StaticEditorFlags = new SharedStaticEditorFlags();

        public override void Setup(Object type)
        {
            GameObject component = (GameObject)type;
            Active.Setup(component.activeInHierarchy);
            Tag.Setup(component.tag);
            Layer.Setup(component.layer);
            StaticEditorFlags.Setup(GameObjectUtility.GetStaticEditorFlags(component));
        }

        public override void Process(Object type, BuildTarget buildTarget)
        {
            GameObject component = (GameObject)type;
            switch (buildTarget)
            {
                case BuildTarget.StandaloneWindows64:
                    component.SetActive(Active.PC);
                    component.tag = Tag.PC;
                    component.layer = Layer.PC;
                    GameObjectUtility.SetStaticEditorFlags(component, StaticEditorFlags.PC);
                    break;
                case BuildTarget.Android:
                    component.SetActive(Active.Quest);
                    component.tag = Tag.Quest;
                    component.layer = Layer.Quest;
                    GameObjectUtility.SetStaticEditorFlags(component, StaticEditorFlags.Quest);
                    break;
                default:
                    break;
            }
        }
    }
}
#endif

