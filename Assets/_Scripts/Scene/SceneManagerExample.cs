using SceneLogic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SceneLogic
{
    public sealed class SceneManagerExample : SceneManagerBase
    {
        public override void InitScenesMap()
        {
            //������������� ��� �����.
            this.sceneConfigMap[SceneConfigExample.SCENE_NAME] = new SceneConfigExample();
        }
    }

}
