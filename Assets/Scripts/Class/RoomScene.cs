﻿using Photon.Pun;
using UnityEngine;

namespace Class
{
    public class RoomScene : Iscene
    {
        public void SceneSetting()
        {
            UIManager.Instance.CreateUI<UIRoom>();
        }

    }
}