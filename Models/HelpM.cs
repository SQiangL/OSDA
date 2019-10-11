﻿using OSDA.ViewModels;
using System;
using System.Runtime.Serialization;

namespace OSDA.Models
{
    [DataContract]
    public sealed class GitRelease
    {
        private Version _version = null;

        [DataMember(Name = "tag_name")]
        public string TagName { get; set; }

        public Version GetVersion()
        {
            if (_version != null)
            {
                return _version;
            }

            string version = TagName;

            if (version.StartsWith("v", StringComparison.CurrentCulture))
            {
                version = version.Substring(1);
            }

            return (_version = Version.Parse(version));
        }
    }

    public class HelpModel : MainWindowBase
    {
        /// <summary>
        /// 本地软件的版本号
        /// </summary>
        public string VerInfoNumber { get; set; }

        /// <summary>
        /// 菜单栏 - 帮助 - 本地版本信息
        /// </summary>
        private string _VerInfo;
        public string VerInfo
        {
            get
            {
                return _VerInfo;
            }
            set
            {
                if(_VerInfo != value)
                {
                    _VerInfo = value;
                    RaisePropertyChanged(nameof(VerInfo));
                }
            }
        }

        /// <summary>
        /// 服务器软件的版本信息
        /// </summary>
        public string UpdateInfo { get; set; }

        /// <summary>
        /// 菜单栏 - 视图 - 精简视图
        /// </summary>
        private bool _ReducedEnable;
        public bool ReducedEnable
        {
            get
            {
                return _ReducedEnable;
            }
            set
            {
                if (_ReducedEnable != value)
                {
                    _ReducedEnable = value;
                    RaisePropertyChanged(nameof(ReducedEnable));
                }
            }
        }

        /// <summary>
        /// 视图可见性
        /// </summary>
        private string _ViewVisibility;
        public string ViewVisibility
        {
            get
            {
                return _ViewVisibility;
            }
            set
            {
                if (_ViewVisibility != value)
                {
                    _ViewVisibility = value;
                    RaisePropertyChanged(nameof(ViewVisibility));
                }
            }
        }

        public void HelpDataContext()
        {
            VerInfoNumber = "3.3.0";
            VerInfo = "OSDA v" + VerInfoNumber;

            UpdateInfo = string.Format(cultureInfo, "OSDA发现新版本le........");

            ReducedEnable = false;
            ViewVisibility = "Visible";
        }
    }
}
