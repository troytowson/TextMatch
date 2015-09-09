using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http.Dependencies;

namespace TextMatch
{
    public class StructuremapResolver : IDependencyResolver
    {
        protected IContainer container;
        private readonly bool _isNested;

        public StructuremapResolver(IContainer container, bool isNested)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }
            this.container = container;
            _isNested = isNested;
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return container.GetInstance(serviceType);
            }
            catch (Exception)
            {
                return null;
            }
        }
        
        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return container.GetAllInstances(serviceType).Cast<object>();
            }
            catch (Exception)
            {
                return new List<object>();
            }
        }

        public IDependencyScope BeginScope()
        {
            var child = container.GetNestedContainer();
            return new StructuremapResolver(child, true);
        }

        public void Dispose()
        {
            container.Dispose();
        }
    }
}