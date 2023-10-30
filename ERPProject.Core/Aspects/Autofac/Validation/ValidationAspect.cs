using Castle.DynamicProxy;
using ERPProject.Core.CrossCuttingConcerns.Validation;
using ERPProject.Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// AOP --> bir metodun önünde ,sonunda , hata verdiğinde çalışan kod parçacıklarına denir.
// Autofac avantajı --> biz program.cs de yazarsak bu instanceleri ileride ekstra bir api mimarisi eklemek istersek bize sıkıntı çıkaracak.Bunu backend tarafına çekmek daha yararlı oluyor.

namespace ERPProject.Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception //Aspect
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            //defensive coding
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değil");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }


    }
}
