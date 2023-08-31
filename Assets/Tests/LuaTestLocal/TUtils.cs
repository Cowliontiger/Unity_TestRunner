using UnityEngine;
using System;
using System.Reflection;
using XLua;
using System.IO;
using System.Text.RegularExpressions;

//namespace Assets._0_Script.MainSystem
//{
    public class TUtils
    {   
        /*
         * 
         * @description Reflection non-private provides objects that describe assemblies, modules, types, methods
         * @param library = Assembly-CSharp
         * @param clazz = Login
         * @param interfaceName = IModule
         * @param method = GetUrl
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

    /// <summary>
    /// c#调用lua,加载lua文件
    /// </summary>
    /// <param name="mpath">Assets下的文件路径。例Login\\</param>
    /// <param name="targetLuaFile">lua文件名，例Login.lua</param>
    /// <param name="functionName">需要加入参数的函数名，如果不需改造参数的话，可以为空。需要改造参数的话此值必须与函数名一致</param>
    /// <param name="addValues">需要加入参数的keyname</param>

    public static LuaEnv LuaTestBefore(String mpath, String targetLuaFile,string functionName,string[] addValues, string[] returnValues)
        {


            var luaPath = Application.dataPath + mpath;
            var path = luaPath + targetLuaFile;
            var bakPath = Application.dataPath + mpath;
            var bakFile = Application.dataPath + mpath + targetLuaFile;
            LuaEnv luaEnv = new LuaEnv();
            LuaTable scriptEnv = luaEnv.NewTable();
            LuaTable meta = luaEnv.NewTable();
            meta.Set("__index", luaEnv.Global);
            scriptEnv.SetMetaTable(meta);
            meta.Dispose();
            //处理lua文件
            var fileContent = ModifyLuaContent(path, targetLuaFile.Replace(".lua", ""), functionName, addValues,returnValues);
			var bytesContent = System.Text.Encoding.UTF8.GetBytes(fileContent);
            LuaEnv.CustomLoader method = CustomLoaderMethod;
        
            Debug.Log("CustomLoader:"+method);
            luaEnv.AddLoader(method);
			luaEnv.DoString(@" require('GameServerCommon/BaseClass')");
			luaEnv.DoString(bytesContent);
            Action luaStart, luaUpdate, luaOnDestroy;
            scriptEnv.Get("Start", out luaStart);
            scriptEnv.Get("Update", out luaUpdate);
            scriptEnv.Get("OnDestroy", out luaOnDestroy);
            return luaEnv;
        }

        private static byte[] CustomLoaderMethod(ref string fileName)
        {
            //找到指定文件     
            fileName = Application.dataPath + "Resources/" + fileName.Replace('.', '/') + ".lua";
            //Debug.Log(fileName);
            if (File.Exists(fileName))
            {
                return File.ReadAllBytes(fileName);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 复制文件夹及文件
        /// </summary>
        /// <param name="sourceFolder">原文件路径</param>
        /// <param name="destFolder">目标文件路径</param>
        /// <returns></returns>
        public static int CopyFolder(string sourceFolder, string destFolder)
        {
            try
            {
                //如果目标路径不存在,则创建目标路径
                if (!System.IO.Directory.Exists(destFolder))
                {
                    System.IO.Directory.CreateDirectory(destFolder);
                }
                //得到原文件根目录下的所有文件
                string name = System.IO.Path.GetFileName(sourceFolder);
                string dest = System.IO.Path.Combine(destFolder, name);
                System.IO.File.Copy(sourceFolder, dest, true);//复制文件

                return 1;
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
                return 0;
            }

        }

     
    public static string ModifyLuaContent(string fileContent, string fileName, string functionName, string[] addValues, string[] returnValues)
    {
        
        return resultStr;
    }
    private static int showMatch(string text, string expr)
        {
            int pos = 0;
            try
            {
                MatchCollection mc = Regex.Matches(text, expr);

                foreach (Match m in mc)
                {
                    pos = m.Index;
                }
            }
            catch (Exception e)
            {

            }
            return pos;
        }

    }
//}
