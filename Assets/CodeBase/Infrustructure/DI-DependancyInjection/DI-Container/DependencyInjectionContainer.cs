using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace Assets.CodeBase.Infrustructure.DependencyInjection.DIContainer
{
    public class DependencyInjectionContainer : IService
    {
        private readonly Dictionary<Type, IService> services = new();
        public void RegisterService<TypeService>(TypeService implementation) where TypeService : class, IService
        {
            services.Add(typeof(TypeService), implementation);
        }

        public void RegisterService<TypeService>() where TypeService : class, IService
        {
            services.Add(typeof(TypeService), (IService)CreateImplementation(typeof(TypeService)));
        }

        public void RegisterService<TypeService, TypeImplemintation>() where TypeService : class, IService where TypeImplemintation : class, IService
        {
            services.Add(typeof(TypeService), (IService)CreateImplementation(typeof(TypeImplemintation)));
        }

        public void UnregisterService<TypeService>() where TypeService : class, IService
        {
            services.Remove(typeof(TypeService));
        }

        private object GetService(Type type)
        {
            if (services.ContainsKey(type))
            {
                return services[type];
            }
            else
            {
                return null;
            }
        }

        private object CreateImplementation(Type type)
        {
            ConstructorInfo constructorInfo = type.GetConstructors().FirstOrDefault();

            if (constructorInfo == null)
            {
                throw new InvalidOperationException($"Не найдет конструктор для типа {type.FullName} ");
            }

            ParameterInfo[] parameterInfos = constructorInfo.GetParameters();

            object[] parametres = new object[parameterInfos.Length];

            for (int i = 0; i < parameterInfos.Length; i++)
            {
                parametres[i] = GetService(parameterInfos[i].ParameterType);

                if (parametres[i] == null)
                {
                    throw new InvalidOperationException($"Зависимость {parameterInfos[i].ParameterType.FullName} в {type.FullName} не Создана");
                }
            }

            return Activator.CreateInstance(type, parametres);
        }

        public object[] GetAllServicesToInject(MethodInfo methodInfo)
        {
            ParameterInfo[] parameterInfos = methodInfo.GetParameters();

            object[] parametres = new object[parameterInfos.Length];

            for (int i = 0;i < parameterInfos.Length;i++)
            {
                services.TryGetValue(parameterInfos[i].ParameterType, out IService objToInject);

                if (objToInject == null)
                {
                    throw new InvalidOperationException($"Зависимость для {parameterInfos[i].ParameterType} не создана");
                }

                parametres[i] = objToInject;
            }

            return parametres;
        }

        public void InjectToMonoBehaviour(MonoBehaviour monoBehaviour)
        {
            MethodInfo[] allMethods = monoBehaviour.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            for (int i = 0; i < allMethods.Length; i++)
            {
                object[] attributes = allMethods[i].GetCustomAttributes(false);

                for (int j = 0; j < attributes.Length; j++)
                {
                    if (attributes[j] is InjectAttribute)
                    {
                        allMethods[i].Invoke(monoBehaviour, GetAllServicesToInject(allMethods[i]));
                    }
                }
            }
        }

        public void InjectToAllMonoBehaviours()
        {
            MonoBehaviour[] monoBehaviours = GameObject.FindObjectsOfType<MonoBehaviour>(true);

            for (int i = 0; i < monoBehaviours.Length; i++)
            {
                InjectToMonoBehaviour(monoBehaviours[i]);
            }
        }

        public void InjectToGameObject(GameObject gameObject)
        {
            MonoBehaviour[] monoBehaviours = gameObject.GetComponentsInChildren<MonoBehaviour>(true);

            for (int i = 0; i < monoBehaviours.Length; i++)
            {
                InjectToMonoBehaviour(monoBehaviours[i]);
            }
        }

        public TType InstantiateAndInject<TType>()
        {
            return (TType) CreateImplementation(typeof(TType));
        }


        public GameObject Instantiate(GameObject gameObject)
        {
            GameObject newObject = GameObject.Instantiate(gameObject);
            InjectToGameObject(newObject);
            return newObject;
        }

    }
}