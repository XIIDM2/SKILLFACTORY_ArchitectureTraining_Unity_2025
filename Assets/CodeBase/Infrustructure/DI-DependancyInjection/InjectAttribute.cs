using System;

namespace Assets.CodeBase.Infrustructure.DependencyInjection
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class InjectAttribute : Attribute
    {

    }
}