using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACG_Class.Model.ServerError
{
    public static class ServerError
    {
        public static string MessageFromServer(Exception ex, string NameClass, string Namemethod)
        {
            return $"⚠️ Server error ⚠️ \nClass: {NameClass} \nName Method: {Namemethod} \nError message: {ex.Message}";
        }

        public static string MessageFromClient(Exception ex, string NameClass, string Namemethod)
        {
            return $"❗ Client error ❗ \nClass: {NameClass} \nName Method: {Namemethod} \nError message: {ex.Message}";
        }
    }
}
