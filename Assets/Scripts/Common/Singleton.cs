﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        [SerializeField]
        private bool m_IsNeedDestroy = false;
        
        private static T m_Instance;
        public static T I
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = GameObject.FindObjectOfType<T>();
                }
                return m_Instance;
            }
        }

        protected virtual void Awake()
        {
            
            if (m_Instance == null)
            {
                m_Instance = this as T;
                if (!m_IsNeedDestroy)
                {
                    //If I am the first instance, make me the Singleton
                    DontDestroyOnLoad(this);
                }
            }
            else
            {
                //If a Singleton already exists and you find
                //another reference in scene, destroy it!
                if (this != m_Instance)
                    Destroy(gameObject);
            }
        }

        protected virtual void OnDestroy()
        {
            if (m_Instance == this)
                m_Instance = null;
        }
    }
