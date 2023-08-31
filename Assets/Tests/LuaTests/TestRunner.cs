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


public class TestRunner

{
    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    //cs方法测试示例
    [UnityTest]
    public IEnumerator LoginCall()
    {

        object[] obj = new object[] { "123", "http://192.168.1.1:8080/login", null };
        string result = (string)TestUtils.ReflectMethod("Assembly", "Login", "", "GetUrl", obj);
        Debug.Log("result:" + result);
        Debug.Log("obj:" + obj[0]);

        yield return null;
    }

    //LoginModel
    public class GetUrl {
       

     [UnityTest]
     //param：登录id=123,Url="http://192.168.1.1:8080/login",callbakc=null
     //result：获得ticket
        public IEnumerator GetUrl_1()
    {   
        object[] obj = new object[] { "123", "http://192.168.1.1:8080/login", null };
        string flag = TestUtils.ReflectMethod("Assembly", "Test_Methods", "", "GetUrl", obj).ToString();
        Debug.Log("flag:" + flag);
        yield return null;
    }

    [UnityTest]
        //param：登录id=123,Url=null,callbakc=null
        //result：异常
        public IEnumerator GetUrl_2()
    {
        object[] obj = new object[] { "123", null, null };
        string flag = TestUtils.ReflectMethod("Assembly", "Test_Methods", "", "GetUrl", obj).ToString();
        Debug.Log("flag:" + flag);
        yield return null;
    }

    [UnityTest]
        //param：登录id=null,Url="http://192.168.1.1:8080/login",callbakc=null
        //result：异常
        public IEnumerator GetUrl_3()
    {
        object[] obj = new object[] { null, "http://192.168.1.1:8080/login", null };
        string flag = TestUtils.ReflectMethod("Assembly", "Test_Methods", "", "GetUrl", obj).ToString();
        Debug.Log("flag:" + flag);
        yield return null;
    }

    [UnityTest]
        //param：登录id=0,Url="http://192.168.1.1:8080/login",callbakc=null
        //result：获得ticket
        public IEnumerator GetUrl_4()
    {
        object[] obj = new object[] { "0", "http://192.168.1.1:8080/login", null };
        string flag = TestUtils.ReflectMethod("Assembly", "Test_Methods", "", "GetUrl", obj).ToString();
        Debug.Log("flag:" + flag);
        yield return null;
    }
 
    [UnityTest]
        //param：登录id=10000000,Url="http://192.168.1.1:8080/login",callbakc=null
        //result：获得ticket
        public IEnumerator GetUrl_5()
    {
        object[] obj = new object[] { "10000000", "http://192.168.1.1:8080/login", null };
        string flag = TestUtils.ReflectMethod("Assembly", "Test_Methods", "", "GetUrl", obj).ToString();
        Debug.Log("flag:" + flag);
        yield return null;
    }

    [UnityTest]
        //param：登录id=1,Url="http://192.168.1.1:8080/",callbakc=null
        //result：网络错误
        public IEnumerator GetUrl_6()
    {
        object[] obj = new object[] { "1", "http://192.168.1.1:8080/", null };
        string flag = TestUtils.ReflectMethod("Assembly", "Test_Methods", "", "GetUrl", obj).ToString();
        Debug.Log("flag:" + flag);
        yield return null;
    }
}
    public class RegAccount
    {  
        [UnityTest]
        //result：注册新号
        public IEnumerator RegAccount_1()
        {
            object[] obj = new object[] { "帅哥", "1", null };
            string flag = TestUtils.ReflectMethod("Assembly", "Test_Methods", "", "RegAccount", obj).ToString();
            Debug.Log("flag:" + flag);
            yield return null;
        }

        [UnityTest]
        //result：注册新号
        public IEnumerator RegAccount_2()
        {
            object[] obj = new object[] { "帅哥", "2", null };
            string flag = TestUtils.ReflectMethod("Assembly", "Test_Methods", "", "RegAccount", obj).ToString();
            Debug.Log("flag:" + flag);
            yield return null;
        }
        [UnityTest]
        //result：注册新号
        public IEnumerator RegAccount_3()
        {
            object[] obj = new object[] { "帅哥", "3", null };
            string flag = TestUtils.ReflectMethod("Assembly", "Test_Methods", "", "RegAccount", obj).ToString();
            Debug.Log("flag:" + flag);
            yield return null;
        }
        [UnityTest]
        //result：注册新号
        public IEnumerator RegAccount_4()
        {
            object[] obj = new object[] { "帅哥", "4", null };
            string flag = TestUtils.ReflectMethod("Assembly", "Test_Methods", "", "RegAccount", obj).ToString();
            Debug.Log("flag:" + flag);
            yield return null;
        }
        [UnityTest]
        //result：注册新号
        public IEnumerator RegAccount_5()
        {
            object[] obj = new object[] { "帅哥", "5", null };
            string flag = TestUtils.ReflectMethod("Assembly", "Test_Methods", "", "RegAccount", obj).ToString();
            Debug.Log("flag:" + flag);
            yield return null;
        }
        [UnityTest]
        //result：avaterType超出范围
        public IEnumerator RegAccount_6()
        {
            object[] obj = new object[] { "帅哥", "6", null };
            string flag = TestUtils.ReflectMethod("Assembly", "Test_Methods", "", "RegAccount", obj).ToString();
            Debug.Log("flag:" + flag);
            yield return null;
        }
    }
    public class Relogin
    {   
        [UnityTest]
        //result：重新登录，返回登录结果
        public IEnumerator Relogin_1()
        {   //_Host，_Port，_Ticket
            object[] obj = new object[] { "192.168.1.1", "8080", "16405" };
            string flag = TestUtils.ReflectMethod("Assembly", "Test_Methods", "", "login", obj).ToString();
            Debug.Log("flag:" + flag);
            Assert.AreEqual(flag,"123456");
            yield return null;
        }
        [UnityTest]
        //result：重新登录，返回登录结果
        public IEnumerator Relogin_2() 
        {   //_Host，_Port，_Ticket
            object[] obj = new object[] { "192.168.1.1", "8080", "16405" };
            string flag = TestUtils.ReflectMethod("Assembly", "Test_Methods", "", "login", obj).ToString();
            Debug.Log("flag:" + flag);
            yield return null;
        }
    }

    [UnityTest]
    public IEnumerator OnClickLogin_1()
    {
        object[] obj = new object[] { };
        string flag = TestUtils.ReflectMethod("Assembly", "Test_Methods", "", "OnClickLogin", obj).ToString();
        Debug.Log("flag:" + flag);
        yield return null;
    }


}
