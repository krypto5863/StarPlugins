﻿using KKAPI.Studio.SaveLoad;
using KKAPI.Utilities;
using Studio;
using UnityEngine;

namespace LightToggler.Koikatu {
    internal class SceneDataController : SceneCustomFunctionController {
        protected override void OnSceneLoad(SceneOperationKind operation, ReadOnlyDictionary<int, ObjectCtrlInfo> loadedItems) {
            LightToggler.LogThis("Scene loaded!");
        }

        protected override void OnSceneSave() {
            LightToggler.LogThis("Scene saved!");
        }

        protected override void OnObjectVisibilityToggled(ObjectCtrlInfo _objectCtrlInfo, bool _visible)
        {
            GameObject toggledObject;
            switch (_objectCtrlInfo.GetType().ToString())
            {
                case "Studio.OCIItem":
                    OCIItem OCI1 = (OCIItem)_objectCtrlInfo;
                    toggledObject = OCI1.objectItem;
                    break;
                case "Studio.OCIFolder":
                    OCIFolder OCI2 = (OCIFolder)_objectCtrlInfo;
                    toggledObject = OCI2.objectItem;
                    break;
                case "Studio.OCILight":
                    OCILight OCI3 = (OCILight)_objectCtrlInfo;
                    toggledObject = OCI3.objectLight;
                    break;
                case "Studio.OCICamera":
                    OCICamera OCI4 = (OCICamera)_objectCtrlInfo;
                    toggledObject = OCI4.objectItem;
                    break;
                default:
                    return;
            }
            Extensions.SetAllLightsState(toggledObject, _visible);
            LightToggler.LogThis(toggledObject.name);
        }
    }
}