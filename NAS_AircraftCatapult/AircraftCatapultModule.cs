using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace NAS_AircraftCatapult
{
    class AircraftCatapultModule : PartModule
    {
        [KSPField]
        public float rotateSpeed = 0.0f;
        [KSPField]
        public float rotateAngle = 0.0f;
        [KSPField]
        public bool isLeft = false;

        [KSPEvent(guiName = "Catapult Start", active = true, guiActive = true, guiActiveEditor = false, name = "catapultstart", guiActiveUnfocused = false)]
        public void CatapultStart()
        {
            try
            {
                GameObject father = FindFirstFather(this.transform);
                print("first father:" + father.name);
                PrintChild(father.transform);
            }
            catch(Exception ex)
            {
                print(ex.Message);
            }
        }

        public void PrintChild(Transform father)
        {
            if (father.transform.childCount == 0)
            {
                print(father.name+" no child!");
                return;
            }
            for (int i = 0; i < father.transform.childCount; i++)
            {
                print("son" + i + ":" + father.transform.GetChild(i).name);
                print("----------------------------MonoBehaviour----------------------------------");
                foreach(var a in father.transform.GetComponents<MonoBehaviour>())
                {
                    print(a.ToString());
                }
                print("----------------------------MonoBehaviour----------------------------------");
                PrintChild(father.transform.GetChild(i));
            }
        }

        public GameObject FindFirstFather(Transform temp)
        {
//             var objs = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();
//             for (int i = 0; i < objs.Count<GameObject>();i++)
//             {
//                 if(temp==objs[i])
//                     return temp.gameObject;
//             }
            foreach (GameObject rootObj in UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects())
            {
                if (temp.name == rootObj.name)
                {
                    return temp.gameObject;
                }
            }
            return FindFirstFather(temp.parent);
        }

        public override void OnStart(StartState state)
        {
            base.OnStart(state);
        }

        public override void OnUpdate()
        {
            if (HighLogic.LoadedSceneIsFlight)
            {
                ///dummy
            }
        }
    }
}