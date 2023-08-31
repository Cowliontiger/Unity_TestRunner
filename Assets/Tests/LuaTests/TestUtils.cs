using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System;
using System.Reflection;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Channels;
using System.Security.Permissions;
using System.Runtime.Remoting;

public class TestUtils
{
    /*
     * 
     * @description Reflection non-private provides objects that describe assemblies, modules, types, methods
     * @param library = Assembly-CSharp
     * @param clazz = LoginModule
     * @param interfaceName = IModule
     * @param method = GetGameServerUrl
     * @param param = {"1","2",null}
     * @return MethodInfo instance
     * 
     */
    public static object ReflectMethod(string library, string clazz, string interfaceName, string method, object[] param)
    {
        Debug.Log(method);
        Debug.Log("obj[]:" + param);
        MethodInfo m;
        BindingFlags flags;
        Assembly assembly = Assembly.Load(library);
        Type t = assembly.GetType(clazz);
        m = getMethodName(t, method, interfaceName);
        var obj = Activator.CreateInstance(t);
        return m.Invoke(obj, param);
        
    }


    public static MethodInfo getMethodName(Type t, string method, string interfaceName)
    {
        MethodInfo m;
        Debug.Log("TestUtils_getMethodName");
        try
        {
            if (interfaceName.Equals(""))
            {
                m = t.GetMethod(method);

                if (m == null)
                {
                    Assert.Catch<Exception>(() => { });
                }
                else
                {
                    Debug.Log("方法名称" + m);
                }
            }
            else
            {
                m = t.GetInterface(interfaceName).GetMethod(method);

                if (m == null)
                {
                    Assert.Catch<Exception>(() => { });
                }
                else
                {
                    Debug.Log("方法名称" + m);
                }
            }
        }
        catch (Exception E)
        {
            Debug.Log("获取方法名异常,采用非公共静态方法");
            if (interfaceName.Equals(""))
            {
                m = (MethodInfo)t.GetMethod(method, BindingFlags.NonPublic | BindingFlags.Instance);
            }
            else
            {
                m = (MethodInfo)t.GetInterface(interfaceName).GetMethod(method, BindingFlags.NonPublic | BindingFlags.Instance);
            }
            Debug.Log("方法名称" + m);

        }
        return m;
    }

    // Create a custom 'RealProxy'.
    public class MyProxy : System.Runtime.Remoting.Proxies.RealProxy
    {
       
            return myReturnMessage;
        }
    }

}
