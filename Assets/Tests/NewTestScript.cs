using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System;
using System.Reflection;
using System.Linq;
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


    [UnityTest]
    public IEnumerator NewTestScriptWithEnumerator()
    {
        object[] obj = new object[] { null };
        obj = new object[] { "forward" };
        string flag = TestUtils.ReflectMethod("Assembly-CSharp", "CarController", "", "GetVector3", obj).ToString();
        object target = TestUtils.GetTargetObject("Assembly-CSharp", "CarController");
        PropertyInfo propertyInfo = TestUtils.GetPropertyInfoBy(target,"");
        //因为传了参数 "forward",所以预期测试结果是 Vector3.forward,即(0.00，0.00，1.00)
        Assert.AreEqual("(0.00, 0.00, 1.00)", flag);
        Debug.Log("flag:" + flag);
        Debug.Log("propertyInfo:" + propertyInfo);
        yield return null;
    }




}
