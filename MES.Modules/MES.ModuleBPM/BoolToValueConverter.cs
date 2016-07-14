/**
* MES.ModuleBPM
*
* 功 能： N/A
* 类 名： Class1
*
* Ver    变更日期                     负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/12/10 星期四 12:52:49    大熊    初版
*
* Copyright (c) 2015 LightMaster Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：光圣科技（宁波）有限公司    　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Windows.Data;

namespace MES.ModuleBPM
{

    public class BoolToImageConverter : BoolToValueConverter<string> { }
    public class BoolToValueConverter<T> : IValueConverter
    {
        public T FalseValue { get; set; }
        public T TrueValue { get; set; }

        public int Max { get; set; }
        public int Min { get; set; }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return FalseValue;
            else
                // return (bool)value ? TrueValue : FalseValue;
               return (double)value>=0 ? TrueValue : FalseValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value != null ? value.Equals(TrueValue) : false;
        }
    }
}
