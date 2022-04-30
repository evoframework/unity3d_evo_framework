using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
namespace Evo
{
    /// <summary>
    /// 
    /// </summary>
    public class UReflection : UObject
    {

        /// <summary>
        /// 
        /// </summary>
        public static EObjectIClass DoReflection(EvoObject evoObject)
        {
            try
            {
                System.Type typeTmp = evoObject.GetType();
                EObjectIClass eObjectClass = new EObjectIClass();
                eObjectClass.iD = IuKey.ToId(typeTmp.Name);

                eObjectClass.name = typeTmp.Name;
                eObjectClass.gType = 0;

                eObjectClass.baseClass = typeTmp.BaseType.Name;
                eObjectClass.type = typeTmp;
                eObjectClass.mapEObjectIProperty = new Map();
                eObjectClass.isSelected = true;

                MethodInfo[] myArrayMethodInfo = typeTmp.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);

                foreach (MethodInfo methodInfo in myArrayMethodInfo)
                {
                    try
                    {

                        ParameterInfo[] arrayParameterInfo = methodInfo.GetParameters();

                        if (arrayParameterInfo.Length == 1)
                        {
                            if (arrayParameterInfo[0].ParameterType.Name.Equals("EMessage"))
                            {
                                //	if (methodInfo.Name != "OnDidLoad" && methodInfo.Name != "OnDidUnload" && methodInfo.Name != "OnView" && methodInfo.Name != "OnHide") {

                                EObjectIMethod eObjectMethod = new EObjectIMethod();
                                eObjectMethod.iD = IuKey.ToId(methodInfo.Name);
                                eObjectMethod.name = methodInfo.Name;
                                eObjectClass.mapEObjectIMethod.DoSet(eObjectMethod);
                                if (methodInfo.IsStatic)
                                {
                                    if (methodInfo.IsPrivate)
                                    {
                                        eObjectMethod.visibility = EnumVisibilty.VISIBILITY_STATIC_PRIVATE;
                                    }

                                    if (methodInfo.IsVirtual)
                                    {
                                        eObjectMethod.visibility = EnumVisibilty.VISIBILITY_STATIC_PROTECTED;
                                    }


                                    if (methodInfo.IsPublic)
                                    {
                                        eObjectMethod.visibility = EnumVisibilty.VISIBILITY_STATIC_PUBLIC;
                                    }

                                }
                                else
                                {
                                    if (methodInfo.IsPrivate)
                                    {
                                        eObjectMethod.visibility = EnumVisibilty.VISIBILITY_PRIVATE;
                                    }

                                    if (methodInfo.IsVirtual)
                                    {
                                        eObjectMethod.visibility = EnumVisibilty.VISIBILITY_PROTECTED;
                                    }


                                    if (methodInfo.IsPublic)
                                    {
                                        eObjectMethod.visibility = EnumVisibilty.VISIBILITY_PUBLIC;
                                    }
                                }


                                //}
                            }
                        }

                    }
                    catch (System.Exception e)
                    {
                        Debug.LogException(e);
                    }

                }

                return eObjectClass;
            }
            catch (System.Exception e)
            {
                Debug.LogException(e);
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        public static EObjectIClass DoReflectionFull(EvoObject evoObject)
        {
            try
            {

                System.Type typeTmp = evoObject.GetType();
                EObjectIClass eObjectClass = new EObjectIClass();
                eObjectClass.iD = IuKey.ToId(typeTmp.Name);

                eObjectClass.name = typeTmp.Name;
                eObjectClass.gType = 0;

                eObjectClass.baseClass = typeTmp.BaseType.Name;
                eObjectClass.type = typeTmp;
                eObjectClass.mapEObjectIProperty = new Map();
                eObjectClass.isSelected = true;

                MethodInfo[] myArrayMethodInfo = typeTmp.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);

                foreach (MethodInfo methodInfo in myArrayMethodInfo)
                {
                    try
                    {

                        ParameterInfo[] arrayParameterInfo = methodInfo.GetParameters();

                        if (arrayParameterInfo.Length == 1)
                        {
                            if (arrayParameterInfo[0].ParameterType.Name.Equals("EMessage"))
                            {
                                //	if (methodInfo.Name != "OnDidLoad" && methodInfo.Name != "OnDidUnload" && methodInfo.Name != "OnView" && methodInfo.Name != "OnHide") {

                                EObjectIMethod eObjectMethod = new EObjectIMethod();
                                eObjectMethod.iD = IuKey.ToId(methodInfo.Name);
                                eObjectMethod.name = methodInfo.Name;
                                eObjectClass.mapEObjectIMethod.DoSet(eObjectMethod);
                                if (methodInfo.IsStatic)
                                {
                                    if (methodInfo.IsPrivate)
                                    {
                                        eObjectMethod.visibility = EnumVisibilty.VISIBILITY_STATIC_PRIVATE;
                                    }

                                    if (methodInfo.IsVirtual)
                                    {
                                        eObjectMethod.visibility = EnumVisibilty.VISIBILITY_STATIC_PROTECTED;
                                    }


                                    if (methodInfo.IsPublic)
                                    {
                                        eObjectMethod.visibility = EnumVisibilty.VISIBILITY_STATIC_PUBLIC;
                                    }

                                }
                                else
                                {
                                    if (methodInfo.IsPrivate)
                                    {
                                        eObjectMethod.visibility = EnumVisibilty.VISIBILITY_PRIVATE;
                                    }

                                    if (methodInfo.IsVirtual)
                                    {
                                        eObjectMethod.visibility = EnumVisibilty.VISIBILITY_PROTECTED;
                                    }


                                    if (methodInfo.IsPublic)
                                    {
                                        eObjectMethod.visibility = EnumVisibilty.VISIBILITY_PUBLIC;
                                    }
                                }


                                //}
                            }
                        }

                    }
                    catch (System.Exception e)
                    {
                        Debug.LogException(e);
                    }

                }




                FieldInfo[] myArrayPropertyInfo = typeTmp.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);

                foreach (FieldInfo fieldInfo in myArrayPropertyInfo)
                {
                    try
                    {

                        EObjectIProperty eObjectProperty = new EObjectIProperty();


                        eObjectProperty.iD = IuKey.ToId(fieldInfo.Name);
                        eObjectProperty.name = fieldInfo.Name;
                        eObjectProperty.type = fieldInfo.FieldType;
                        eObjectProperty.typeName = fieldInfo.FieldType.ToString();

                        System.Object valueObject = System.Activator.CreateInstance(fieldInfo.FieldType);


                        eObjectProperty.value = fieldInfo.GetValue(valueObject);


                        eObjectClass.mapEObjectIProperty.DoSet(eObjectProperty);
                        if (fieldInfo.IsStatic)
                        {
                            if (fieldInfo.IsPrivate)
                            {
                                eObjectProperty.visibility = EnumVisibilty.VISIBILITY_STATIC_PRIVATE;
                            }

                            /*if(fieldInfo.i){
                                eObjectProperty.visibility = EObjectIProperty.VISIBILITY_STATIC_PROTECTED;
                                    }*/


                            if (fieldInfo.IsPublic)
                            {
                                eObjectProperty.visibility = EnumVisibilty.VISIBILITY_STATIC_PUBLIC;
                            }

                        }
                        else
                        {
                            if (fieldInfo.IsPrivate)
                            {
                                eObjectProperty.visibility = EnumVisibilty.VISIBILITY_PRIVATE;
                            }

                            /*if(fieldInfo.IsVirtual){
                                eObjectProperty.visibility = EObjectIProperty.VISIBILITY_PROTECTED;
                                    }*/


                            if (fieldInfo.IsPublic)
                            {
                                eObjectProperty.visibility = EnumVisibilty.VISIBILITY_PUBLIC;
                            }
                        }


                    }
                    catch (System.Exception e)
                    {
                        Debug.LogException(e);
                    }

                }




                return eObjectClass;
            }
            catch (System.Exception e)
            {
                Debug.LogException(e);
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        public static EObjectIClass DoReflectionPublic(EvoObject evoObject)
        {
            try
            {

                System.Type typeTmp = evoObject.GetType();
                EObjectIClass eObjectClass = new EObjectIClass();
                eObjectClass.iD = IuKey.ToId(typeTmp.Name);

                eObjectClass.name = typeTmp.Name;
                eObjectClass.gType = 0;

                eObjectClass.baseClass = typeTmp.BaseType.Name;
                eObjectClass.type = typeTmp;
                eObjectClass.mapEObjectIProperty = new Map();
                eObjectClass.isSelected = true;

                MethodInfo[] myArrayMethodInfo = typeTmp.GetMethods(BindingFlags.Public | BindingFlags.Instance);

                foreach (MethodInfo methodInfo in myArrayMethodInfo)
                {
                    try
                    {

                        ParameterInfo[] arrayParameterInfo = methodInfo.GetParameters();

                        if (arrayParameterInfo.Length == 1)
                        {
                            if (arrayParameterInfo[0].ParameterType.Name.Equals("EMessage"))
                            {
                                //if (methodInfo.Name != "OnDidLoad" && methodInfo.Name != "OnDidUnload" && methodInfo.Name != "OnView" && methodInfo.Name != "OnHide") {

                                EObjectIMethod eObjectMethod = new EObjectIMethod();
                                eObjectMethod.iD = IuKey.ToId(methodInfo.Name);
                                eObjectMethod.name = methodInfo.Name;
                                eObjectClass.mapEObjectIMethod.DoSet(eObjectMethod);
                                //}
                            }
                        }

                    }
                    catch (System.Exception e)
                    {
                        Debug.LogException(e);
                    }

                }
                return eObjectClass;
            }
            catch (System.Exception e)
            {
                Debug.LogException(e);
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        public static EObjectIClass DoReflectionFullPublic(EvoObject evoObject)
        {
            try
            {
                IuKey.GenerateId(evoObject);
                System.Type typeTmp = evoObject.GetType();
                EObjectIClass eObjectClass = new EObjectIClass();
                eObjectClass.iD = IuKey.ToId(evoObject.iD.ToString());

                eObjectClass.name = typeTmp.Name;
                eObjectClass.gType = 0;

                eObjectClass.baseClass = typeTmp.BaseType.Name;
                eObjectClass.type = typeTmp;
                eObjectClass.mapEObjectIProperty = new Map();
                eObjectClass.isSelected = true;

                MethodInfo[] myArrayMethodInfo = typeTmp.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

                foreach (MethodInfo methodInfo in myArrayMethodInfo)
                {
                    try
                    {

                        ParameterInfo[] arrayParameterInfo = methodInfo.GetParameters();

                        if (arrayParameterInfo.Length == 1)
                        {
                            if (arrayParameterInfo[0].ParameterType.Name.Equals("EMessage"))
                            {
                                //	if (methodInfo.Name != "OnDidLoad" && methodInfo.Name != "OnDidUnload" && methodInfo.Name != "OnView" && methodInfo.Name != "OnHide") {

                                EObjectIMethod eObjectMethod = new EObjectIMethod();
                                eObjectMethod.iD = IuKey.ToId(methodInfo.Name);
                                eObjectMethod.name = methodInfo.Name;
                                eObjectClass.mapEObjectIMethod.DoSet(eObjectMethod);
                                if (methodInfo.IsStatic)
                                {
                                    if (methodInfo.IsPrivate)
                                    {
                                        eObjectMethod.visibility = EnumVisibilty.VISIBILITY_STATIC_PRIVATE;
                                    }

                                    if (methodInfo.IsVirtual)
                                    {
                                        eObjectMethod.visibility = EnumVisibilty.VISIBILITY_STATIC_PROTECTED;
                                    }


                                    if (methodInfo.IsPublic)
                                    {
                                        eObjectMethod.visibility = EnumVisibilty.VISIBILITY_STATIC_PUBLIC;
                                    }

                                }
                                else
                                {
                                    if (methodInfo.IsPrivate)
                                    {
                                        eObjectMethod.visibility = EnumVisibilty.VISIBILITY_PRIVATE;
                                    }

                                    if (methodInfo.IsVirtual)
                                    {
                                        eObjectMethod.visibility = EnumVisibilty.VISIBILITY_PROTECTED;
                                    }


                                    if (methodInfo.IsPublic)
                                    {
                                        eObjectMethod.visibility = EnumVisibilty.VISIBILITY_PUBLIC;
                                    }
                                }


                                //}
                            }
                        }

                    }
                    catch (System.Exception e)
                    {
                        Debug.LogException(e);
                    }

                }




                FieldInfo[] myArrayPropertyInfo = typeTmp.GetFields();// (BindingFlags.Public  | BindingFlags.Instance );

                foreach (FieldInfo fieldInfo in myArrayPropertyInfo)
                {
                    try
                    {

                        EObjectIProperty eObjectProperty = new EObjectIProperty();


                        eObjectProperty.iD = IuKey.ToId(fieldInfo.Name);
                        eObjectProperty.name = fieldInfo.Name;
                        eObjectProperty.type = fieldInfo.FieldType;
                        eObjectProperty.typeName = fieldInfo.FieldType.ToString();
                        try
                        {
                            //System.Object valueObject =   System.Activator.CreateInstance(fieldInfo.FieldType);


                            eObjectProperty.value = fieldInfo.GetValue(evoObject);


                            eObjectClass.mapEObjectIProperty.DoSet(eObjectProperty);
                        }
                        catch (System.Exception e)
                        {
                            Debug.LogException(e);
                        }


                        if (fieldInfo.IsStatic)
                        {
                            if (fieldInfo.IsPrivate)
                            {
                                eObjectProperty.visibility = EnumVisibilty.VISIBILITY_STATIC_PRIVATE;
                            }

                            /*if(fieldInfo.i){
                                eObjectProperty.visibility = EObjectIProperty.VISIBILITY_STATIC_PROTECTED;
                                    }*/


                            if (fieldInfo.IsPublic)
                            {
                                eObjectProperty.visibility = EnumVisibilty.VISIBILITY_STATIC_PUBLIC;
                            }

                        }
                        else
                        {
                            if (fieldInfo.IsPrivate)
                            {
                                eObjectProperty.visibility = EnumVisibilty.VISIBILITY_PRIVATE;
                            }

                            /*if(fieldInfo.IsVirtual){
                                eObjectProperty.visibility = EObjectIProperty.VISIBILITY_PROTECTED;
                                    }*/


                            if (fieldInfo.IsPublic)
                            {
                                eObjectProperty.visibility = EnumVisibilty.VISIBILITY_PUBLIC;
                            }
                        }


                    }
                    catch (System.Exception e)
                    {
                        Debug.LogException(e);
                    }

                }




                return eObjectClass;
            }
            catch (System.Exception e)
            {
                Debug.LogException(e);
            }
            return null;
        }


    }
}