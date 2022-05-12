﻿using UnityEngine;
using System.Collections;
<<<<<<< HEAD
using UnityEngine.Serialization;
=======
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc


namespace TMPro.Examples
{
    
    public class ObjectSpin : MonoBehaviour
    {

#pragma warning disable 0414

<<<<<<< HEAD
        [FormerlySerializedAs("SpinSpeed")] public float spinSpeed = 5;
        [FormerlySerializedAs("RotationRange")] public int rotationRange = 15;
        private Transform mTransform;

        private float mTime;
        private Vector3 mPrevPos;
        private Vector3 mInitialRotation;
        private Vector3 mInitialPosition;
        private Color32 mLightColor;
        private int frames = 0;

        public enum MotionType { Rotation, BackAndForth, Translation };
        [FormerlySerializedAs("Motion")] public MotionType motion;

        void Awake()
        {
            mTransform = transform;
            mInitialRotation = mTransform.rotation.eulerAngles;
            mInitialPosition = mTransform.position;

            Light light = GetComponent<Light>();
            mLightColor = light != null ? light.color : Color.black;
=======
        public float SpinSpeed = 5;
        public int RotationRange = 15;
        private Transform m_transform;

        private float m_time;
        private Vector3 m_prevPOS;
        private Vector3 m_initial_Rotation;
        private Vector3 m_initial_Position;
        private Color32 m_lightColor;
        private int frames = 0;

        public enum MotionType { Rotation, BackAndForth, Translation };
        public MotionType Motion;

        void Awake()
        {
            m_transform = transform;
            m_initial_Rotation = m_transform.rotation.eulerAngles;
            m_initial_Position = m_transform.position;

            Light light = GetComponent<Light>();
            m_lightColor = light != null ? light.color : Color.black;
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc
        }


        // Update is called once per frame
        void Update()
        {
<<<<<<< HEAD
            if (motion == MotionType.Rotation)
            {
                mTransform.Rotate(0, spinSpeed * Time.deltaTime, 0);
            }
            else if (motion == MotionType.BackAndForth)
            {
                mTime += spinSpeed * Time.deltaTime;
                mTransform.rotation = Quaternion.Euler(mInitialRotation.x, Mathf.Sin(mTime) * rotationRange + mInitialRotation.y, mInitialRotation.z);
            }
            else
            {
                mTime += spinSpeed * Time.deltaTime;

                float x = 15 * Mathf.Cos(mTime * .95f);
                float y = 10; // *Mathf.Sin(m_time * 1f) * Mathf.Cos(m_time * 1f);
                float z = 0f; // *Mathf.Sin(m_time * .9f);    

                mTransform.position = mInitialPosition + new Vector3(x, z, y);
=======
            if (Motion == MotionType.Rotation)
            {
                m_transform.Rotate(0, SpinSpeed * Time.deltaTime, 0);
            }
            else if (Motion == MotionType.BackAndForth)
            {
                m_time += SpinSpeed * Time.deltaTime;
                m_transform.rotation = Quaternion.Euler(m_initial_Rotation.x, Mathf.Sin(m_time) * RotationRange + m_initial_Rotation.y, m_initial_Rotation.z);
            }
            else
            {
                m_time += SpinSpeed * Time.deltaTime;

                float x = 15 * Mathf.Cos(m_time * .95f);
                float y = 10; // *Mathf.Sin(m_time * 1f) * Mathf.Cos(m_time * 1f);
                float z = 0f; // *Mathf.Sin(m_time * .9f);    

                m_transform.position = m_initial_Position + new Vector3(x, z, y);
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc

                // Drawing light patterns because they can be cool looking.
                //if (frames > 2)
                //    Debug.DrawLine(m_transform.position, m_prevPOS, m_lightColor, 100f);

<<<<<<< HEAD
                mPrevPos = mTransform.position;
=======
                m_prevPOS = m_transform.position;
>>>>>>> 79e2fe3a0a4ad8805a9270cec6cc78af4a4004dc
                frames += 1;
            }
        }
    }
}