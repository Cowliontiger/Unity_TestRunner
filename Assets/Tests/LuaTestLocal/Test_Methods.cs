using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;
using System.Reflection;
using XLua;
using System.IO;
using System.Text.RegularExpressions;
using System.Text;

[CSharpCallLua]
delegate string GetUrl(string id, string loginServerUrl, Action<bool, bool> callBack);
[CSharpCallLua]
delegate string Relogin(string _Host, string _Port, string _Ticket);

//TestRunner调用此处方法
public class Test_Methods
//使用了MethodInfo.GetCurrentMethod().Name.ToString()获取当前方法名，此处的方法名称需要与lua函数名称一致

//addValues[] 表示不为空时，将会在调用的lua函数中添加参数字段。 
//适用：lua方法无参数且引用本地变量的情况,改造lua方法，把本地变量变为参数，传入值进行测试
{
    public string GetUrl(string id, string loginServerUrl, Action<bool, bool> callBack)
    {   
        string[] addValues = { };
        string[] returnValues = {  "loginServerUrl" };
        LuaEnv luaEnv = TUtils.LuaTestBefore("Login\\", "Login.lua", MethodInfo.GetCurrentMethod().Name.ToString(), addValues, returnValues);
        GetUrl method2 = luaEnv.Global.GetInPath<GetUrl>("GetUrl");
        return method2(id, loginServerUrl,null);

       
    }
    public bool RegAccount(string name, string avaterType, Action<bool, bool> callBack)
    {
        string[] addValues = {  };
        string[] returnValues = { "name"};
        LuaEnv luaEnv = TUtils.LuaTestBefore("Login\\", "Login.lua", MethodInfo.GetCurrentMethod().Name.ToString(), addValues, returnValues);
        Action<string, string, Action<bool>, object> method = luaEnv.Global.GetInPath<Action<string, string, Action<bool>, object>>(MethodInfo.GetCurrentMethod().Name.ToString());
        method(name, avaterType, null, null);
        return true;
    }
    //lua方法无参数且引用本地变量的情况,改造lua方法，把本地变量变为参数，传入值进行测试
    public string Relogin(string _Host, string _Port, string _Ticket)
    {   //参数字段
        string[] addValues = { "_Host", "_Port", "_Ticket" };
        string[] returnValues = { "_Ticket" };

        LuaEnv luaEnv = TUtils.LuaTestBefore("Login\\", "Login.lua", MethodInfo.GetCurrentMethod().Name.ToString(), addValues,returnValues);
        Relogin method2 = luaEnv.Global.GetInPath<Relogin>("Relogin");
        return method2(_Host, _Port, _Ticket);
    }
    public bool OnClickLogin()
    {
        string[] addValues = { };
        string[] returnValues = { };
        LuaEnv luaEnv = TUtils.LuaTestBefore("Login\\", "LoginPresent.lua", "ViewCall", addValues, returnValues);
         Action<string> method = luaEnv.Global.GetInPath<Action<string>>("ViewCall");
        method("OnLogin");
        return true;
    }

}
