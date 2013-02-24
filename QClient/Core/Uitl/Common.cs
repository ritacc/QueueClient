using System;
using System.ComponentModel;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;

namespace QClient.Core.Util
{
    /// <summary>
    /// 通用帮助类
    /// </summary>
    internal static class Common
    {
        public readonly static string ApplicationDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "QClient");

        public readonly static string TempFile = GetAppPath("tmp");

        public static string GetAppPath(string path)
        {
            if (!Directory.Exists(ApplicationDataPath))
            {
                Directory.CreateDirectory(ApplicationDataPath);
            }
            return Path.Combine(ApplicationDataPath, path);
        }

        public static string GetAppPath(string path1, string path2)
        {
            if (!Directory.Exists(ApplicationDataPath))
            {
                Directory.CreateDirectory(ApplicationDataPath);
            }
            return Path.Combine(Path.Combine(ApplicationDataPath, path1), path2);
        }

        private static readonly bool _IsInDesignMode = (bool)DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof(DependencyObject)).DefaultValue;
        public static bool IsInDesignMode
        {
            get { return _IsInDesignMode; }
        }

        /// <summary>
        /// 获取文件安全路径
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string GetSafeFilePath(string path)
        {
            // 如果只有文件名, 打开文件对话框会影响当前默认目录, 所以需要试探下
            if (!path.Contains("\\"))
            {
                return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);
            }
            return path;
        }

        ///// <summary>
        ///// 判断当前是否具有管理员权限
        ///// </summary>
        //public static bool IsAdmin()
        //{
        //    return new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
        //}
    }
}
