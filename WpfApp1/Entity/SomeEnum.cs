using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public enum SomeEnum
    {
        Dog,
        Cat,
        Elephant,
        Pig,
    }

    public static partial class SomuEnumExtend
    {
        public static string GetText(this SomeEnum param)
        {
            string ret = string.Empty;
            switch (param)
            {
                case SomeEnum.Dog:
                    ret = "イヌ";
                    break;
                case SomeEnum.Cat:
                    ret = "ネコ";
                    break;
                case SomeEnum.Elephant:
                    ret = "ゾウ";
                    break;
                case SomeEnum.Pig:
                    ret = "ブタ";
                    break;
            }
            return ret;
        }
    }
}
