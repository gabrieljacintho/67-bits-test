﻿using System.Collections.Generic;
using UnityEngine;

namespace Bits.GameObjectStack
{
    public class GameObjectStack : MonoBehaviour
    {
        private Stack<StackableGameObject> _gameObjectsStack = new Stack<StackableGameObject>();


        public void Push(StackableGameObject target)
        {
            _gameObjectsStack.Push(target);
            target.Stack(this);
        }

        public void GetPositionAndRotation(StackableGameObject target, out Vector3 position, out Quaternion rotation)
        {
            bool targetFound = false;
            StackableGameObject[] gameObjectsArray = _gameObjectsStack.ToArray();

            for (int i = 0; i < gameObjectsArray.Length; i++)
            {
                if (gameObjectsArray[i] == target)
                {
                    targetFound = true;
                    continue;
                }

                if (!targetFound)
                {
                    continue;
                }

                StackableGameObject stackableGameObject = gameObjectsArray[i];
                Transform originTransform = stackableGameObject.transform;

                position = originTransform.position + (stackableGameObject.UpDirection * stackableGameObject.Size);
                rotation = originTransform.rotation;
                return;
            }

            position = transform.position;
            rotation = transform.rotation;
        }
    }
}