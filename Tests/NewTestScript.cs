using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System;
using System.Reflection;
using System.Linq;
using Google.Protobuf;
using System.Text;
using UnityEngine.TestTools.Utils;

public class NewTestScript
{

    // A Test behaves as an ordinary method
    [Test]
    public void NewTestScriptSimplePasses()
    {
        // Use the Assert class to test conditions
        Assert.AreEqual(1, 1);
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator NewTestScriptWithEnumeratorPasses()
    {

        object[] obj = new object[] { };
        TestUtils.ReflectMethod("Assembly-CSharp", "LoginModule", "", "IModule.Init", obj);

        obj = new object[] { "123", "http://192.168.20.213:8080/login", null };
        string result = (string)TestUtils.ReflectMethod("Assembly-CSharp", "LoginModule", "", "GetGameServerUrl", obj);
        Debug.Log("result:" + result);
        Debug.Log("obj:" + obj[2]);

        obj = new object[] { "test", "test套装", null };
        TestUtils.ReflectMethod("Assembly-CSharp", "LoginModule", "", "RegisterNewAccount", obj);


        //Assert.AreEqual(ms,"123");


        yield return null;
    }

    [UnityTest]
    public IEnumerator NewTestScriptWithEnumerator()
    {
        object[] obj = new object[] { null };
        string flag = TestUtils.ReflectMethod("Assembly-CSharp", "Assets._0_Script.MainSystem.Shop.Class1", "", "NewTestScriptSimplePasses", obj).ToString();
        Debug.Log("flag:" + flag);
        yield return null;
    }


}
