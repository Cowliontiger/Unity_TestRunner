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
        MethodInfo m;
        BindingFlags flags;
        Assembly assembly = Assembly.Load(library);
        Type t = assembly.GetType(clazz);
        m = getMethodName(t, method, interfaceName);
        var obj = Activator.CreateInstance(t);
        return m.Invoke(obj, param);
        
        //return obj.GetType().GetField("_loginGameServerCallBack", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(obj);
    }


    public static MethodInfo getMethodName(Type t, string method, string interfaceName)
    {
        MethodInfo m;
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
        String myURIString;
        MarshalByRefObject myMarshalByRefObject;

        [PermissionSet(SecurityAction.LinkDemand)]
        public MyProxy(Type myType) : base(myType)
        {
            // RealProxy uses the Type to generate a transparent proxy.
            myMarshalByRefObject = (MarshalByRefObject)Activator.CreateInstance((myType));
            // Get 'ObjRef', for transmission serialization between application domains.
            ObjRef myObjRef = RemotingServices.Marshal(myMarshalByRefObject);
            // Get the 'URI' property of 'ObjRef' and store it.
            myURIString = myObjRef.URI;
            Console.WriteLine("URI :{0}", myObjRef.URI);
        }

        [SecurityPermissionAttribute(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.Infrastructure)]
        public override IMessage Invoke(IMessage myIMessage)
        {
            Console.WriteLine("MyProxy.Invoke Start");
            Console.WriteLine("");

            if (myIMessage is IMethodCallMessage)
                Console.WriteLine("IMethodCallMessage");

            if (myIMessage is IMethodReturnMessage)
                Console.WriteLine("IMethodReturnMessage");

            Type msgType = myIMessage.GetType();
            Console.WriteLine("Message Type: {0}", msgType.ToString());
            Console.WriteLine("Message Properties");
            IDictionary myIDictionary = myIMessage.Properties;
            // Set the '__Uri' property of 'IMessage' to 'URI' property of 'ObjRef'.
            myIDictionary["__Uri"] = myURIString;
            IDictionaryEnumerator myIDictionaryEnumerator =
               (IDictionaryEnumerator)myIDictionary.GetEnumerator();

            while (myIDictionaryEnumerator.MoveNext())
            {
                System.Object myKey = myIDictionaryEnumerator.Key;
                String myKeyName = myKey.ToString();
                System.Object myValue = myIDictionaryEnumerator.Value;

                Console.WriteLine("\t{0} : {1}", myKeyName,
                   myIDictionaryEnumerator.Value);
                if (myKeyName == "__Args")
                {
                    System.Object[] myObjectArray = (System.Object[])myValue;
                    for (int aIndex = 0; aIndex < myObjectArray.Length; aIndex++)
                        Console.WriteLine("\t\targ: {0} myValue: {1}", aIndex,
                           myObjectArray[aIndex]);
                }

                if ((myKeyName == "__MethodSignature") && (null != myValue))
                {
                    System.Object[] myObjectArray = (System.Object[])myValue;
                    for (int aIndex = 0; aIndex < myObjectArray.Length; aIndex++)
                        Console.WriteLine("\t\targ: {0} myValue: {1}", aIndex,
                           myObjectArray[aIndex]);
                }
            }

            IMessage myReturnMessage;

            myIDictionary["__Uri"] = myURIString;
            Console.WriteLine("__Uri {0}", myIDictionary["__Uri"]);

            Console.WriteLine("ChannelServices.SyncDispatchMessage");
            myReturnMessage = ChannelServices.SyncDispatchMessage(myIMessage);

            // Push return value and OUT parameters back onto stack.

            IMethodReturnMessage myMethodReturnMessage = (IMethodReturnMessage)
               myReturnMessage;
            Console.WriteLine("IMethodReturnMessage.ReturnValue: {0}",
               myMethodReturnMessage.ReturnValue);

            Console.WriteLine("MyProxy.Invoke - Finish");

            return myReturnMessage;
        }
    }

}
