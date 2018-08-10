﻿// MIT License

// Copyright (c) 2018 Felix Lange 

// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:

// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.

// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using RecordAndPlay;

public class HeadRecorder : StringRecorder
{

    [System.Serializable]
    public class Head
    {
        public Vector3 worldPos;
        public Vector3 forward;
        
        public Head(){}
        public Head(Transform t)
        {
            worldPos = t.position;
            forward = t.forward;
        }
        
        public void DebugDraw(float radius, float rayLength)
        {
            Gizmos.DrawWireSphere(worldPos, radius);

            Vector3 from = worldPos;
            Vector3 to = from + forward * rayLength;
            Gizmos.DrawLine(from, to);
        }
    }


    protected new void Update()
    {
        base.Update();

        if (IsRecording)
        {
            Head head = new Head(transform);

            string json = JsonUtility.ToJson(head);
            Debug.Log(json);
            RecordData(json);
        }
    }
}