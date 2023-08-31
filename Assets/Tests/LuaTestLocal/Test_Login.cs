using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;
using System.Reflection;
using XLua;
using System.IO;
using System.Text.RegularExpressions;
using System.Text;


    class Test_Login
    {
        /// <summary>
        /// GetUrl
        /// </summary>
        /// <param id="">登录id</param>
        /// <param loginServerUrl="">Url地址</param>
        /// <summary>
        /// GetUrl：登录id=1,Url="http://192.168.1.1:8080/login"。预期：获得ticket
        /// </summary>
        public bool GetUrl_1() {
        string[] addValues = { };
        LuaEnv luaEnv =TUtils.LuaTestBefore("Login\\", "LoginModule.lua", "GetUrl",addValues);
            //GetUrl(id, loginServerUrl, callback)
            Action<string, string, Action<bool>, object> method = luaEnv.Global.GetInPath<Action<string, string, Action<bool>, object>>("GetUrl");
            method("1", "http://192.168.1.1:8080/login", null, null);
            return true;
        }
        /// <summary>
        ///GetUrl：登录id=1,Url=null。预期：报错
        /// </summary> 
        public bool GetUrl_2()
        {
        string[] addValues = {  };
            LuaEnv luaEnv = TUtils.LuaTestBefore("Login\\", "LoginModule.lua", "GetUrl", addValues);
            //GetUrl(id, loginServerUrl, callback)
            Action<string, string, Action<bool>, object> method = luaEnv.Global.GetInPath<Action<string, string, Action<bool>, object>>("GetUrl");
            method("1", null, null, null);
            return true;
        }
        /// <summary>
        ///GetUrl：登录id=null,Url=null。预期：报错
        /// </summary> 
        public bool GetUrl_3()
        {
        string[] addValues = { };
        LuaEnv luaEnv = TUtils.LuaTestBefore("Login\\", "LoginModule.lua", "GetUrl", addValues);
            //GetUrl(id, loginServerUrl, callback)
            Action<string, string, Action<bool>, object> method = luaEnv.Global.GetInPath<Action<string, string, Action<bool>, object>>("GetUrl");
            method(null, null, null, null);
            return true;
        }
        /// <summary>
        ///GetUrl：登录id=null,Url="http://192.168.1.1:8080/login"。预期：报错
        /// </summary> 
        public bool GetUrl_4()
        {
        string[] addValues = { };
        LuaEnv luaEnv = TUtils.LuaTestBefore("Login\\", "LoginModule.lua", "GetUrl", addValues);
            //GetUrl(id, loginServerUrl, callback)
            Action<string, string, Action<bool>, object> method = luaEnv.Global.GetInPath<Action<string, string, Action<bool>, object>>("GetUrl");
            method(null, "http://192.168.1.1:8080/login", null, null);
            return true;
        }
        ///<summary>
        ///GetUrl：登录id=1,Url="http://192.168.1.1:8080/login"。预期：获得ticket
        ///</summary>
        public bool GetUrl_5(object[] param)
        {
        string[] addValues = { };
        Debug.Log(param);
            GetUrl(id, loginServerUrl, callback)
            Action< object> method = luaEnv.Global.GetInPath<Action< object>>("GetUrl");
            method(param);
            return true;
        }
        /// <summary>
        ///OnLogin_：登录id=null,Url="http://192.168.1.1:8080/login"。预期：报错
        /// </summary> 
        public bool OnClickLogin_1()
        {
        string[] addValues = { };
        LuaEnv luaEnv = TUtils.LuaTestBefore("Login\\", "LoginPresent.lua", "GetUrl", addValues);
            Action<string, string,string, object> method = luaEnv.Global.GetInPath<Action<string, string, string, object>>("ViewCall");
            method("OnLogin", "1", "http://192.168.1.1:8080/login", null);
            return true;
        }
        public  bool RegisterNewAccount ()
        {
        string[] addValues = { };
        LuaEnv luaEnv = TUtils.LuaTestBefore("Login\\", "LoginModule.lua", "RegAccount", addValues);
            Action<string, string, Action<bool>, object> method =luaEnv.Global.GetInPath<Action<string, string, Action<bool>, object>>("RegAccount");
            method("帅哥","15", null, null);
        
            return true;
        }
        public bool GetUrl_obj(string id, string loginServerUrl, Action<bool, bool> callBack)
        {
        string[] addValues = { };
        LuaEnv luaEnv = TUtils.LuaTestBefore("Login\\", "LoginModule.lua", "GetUrl", addValues);
            Action<string, string, Action<bool>, object> method = luaEnv.Global.GetInPath<Action<string, string, Action<bool>, object>>("GetUrl");
             method(id, loginServerUrl, null, null);
            return true;
        }
    }

