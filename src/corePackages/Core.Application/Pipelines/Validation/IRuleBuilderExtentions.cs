using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Pipelines.Validation
{
    public static class IRuleBuilderExtentions 
    {
        public static IRuleBuilderOptions<T, string> FirstLetterMustBeUpperCase<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.Must(MustBeUpperCase);
        }
        private static bool MustBeUpperCase(string args)
        {
            return args[0] > 65 && args[0] < 91;
        }
        public static IRuleBuilderOptions<T, string> FirstLetterMustBeLowerCase<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.Must(MustBeLowerCase);
        }
        private static bool MustBeLowerCase(string args)
        {
            return args[0] > 96 && args[0] < 123;
        }
    }
}
