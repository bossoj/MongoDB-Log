using System;
using System.Reflection;

namespace BJ.MongoDB.WebUI
{
    public class AssemblyInfo
    {
        #region Methods access to attributes assembly

        public static string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    var titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if ( String.IsNullOrWhiteSpace(titleAttribute.Title))
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        //----------------------------------------------------------------------------------------

        public static string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        //----------------------------------------------------------------------------------------

        public static string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);

                return attributes.Length == 0 ? String.Empty : ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        //----------------------------------------------------------------------------------------

        public static string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);

                return attributes.Length == 0 ? String.Empty : ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        //----------------------------------------------------------------------------------------

        public static string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);

                return attributes.Length == 0 ? String.Empty : ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        //----------------------------------------------------------------------------------------

        public static string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);

                return attributes.Length == 0 ? String.Empty : ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion
    }
}