using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
   public class MD5Helper
    {
       public static string GetMd5(string txt)
       {
           //创建MD5对象
           //将字符串转成字节数组
           //加密
           //将字节数组转换成字符串，返回该字符串

           MD5 md5 = MD5.Create();//在这里注意，创建对象的时候没办法new，就用这个类.，如上。这个类指定了创建对象的方法，类似工厂模式，就 直接.方法。

           byte[] bs = Encoding.UTF8.GetBytes(txt);
           byte[] bs2= md5.ComputeHash(bs);
          // string md5pwd = string.Empty;
           StringBuilder sb = new StringBuilder();
           for (int i = 0; i < bs2.Length;i++ )
           {
               //0-255 => 00-ff,所以用16进制两位
               sb.Append(bs2[i].ToString("x2").ToLower());
            //   md5pwd += bs2[i].ToString("x2");
           }
          // return md5pwd;
           return sb.ToString();
       }
    }
}
