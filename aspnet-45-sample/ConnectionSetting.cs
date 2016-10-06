#region Copyright ©2016, Click2Cloud Inc. - All Rights Reserved
/* ------------------------------------------------------------------- *
*                            Click2Cloud Inc.                          *
*                  Copyright ©2016 - All Rights reserved               *
*                                                                      *
* Apache 2.0 License                                                   *
* You may obtain a copy of the License at                              * 
* http://www.apache.org/licenses/LICENSE-2.0                           *
* Unless required by applicable law or agreed to in writing,           *
* software distributed under the License is distributed on an "AS IS"  *
* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express  *
* or implied. See the License for the specific language governing      *
* permissions and limitations under the License.                       *
*                                                                      *
* -------------------------------------------------------------------  */
#endregion Copyright ©2016, Click2Cloud Inc. - All Rights Reserved

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace aspnet_45_sample
{
    public class ConnectionSetting
    {
        private static string _userName = "user1";
        private static string _password = "user1#123";
        private static string _defaultDB = "sampledb";
        private static string _clusterIp = "localhost";

        internal static string CONNECTION_STRING
        {
            get
            {
                if (!(string.IsNullOrEmpty(MONGODB_USER) || string.IsNullOrEmpty(MONGODB_PASSWORD)
                || string.IsNullOrEmpty(mongoDBClusterIP) || string.IsNullOrEmpty(MONGODB_DATABASE)))
                {
                    string _connectionString = string.Format("mongodb://{0}:{1}@{2}:{3}/{4}", MONGODB_USER, MONGODB_PASSWORD,
                    mongoDBClusterIP, "27017", MONGODB_DATABASE);

                    return _connectionString;
                }
                else { throw new Exception("MongoDB Cluster IP is not set."); }
            }
        }

        private static string mongoDBClusterIP
        {
            get
            {
                if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("MONGODB_SERVICE_HOST")))
                {
                    return Environment.GetEnvironmentVariable("MONGODB_SERVICE_HOST");
                }

                return _clusterIp;
            }
        }

        private static string MONGODB_USER
        {
            get
            {
                if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("MONGODB_USER")))
                {
                    return Environment.GetEnvironmentVariable("MONGODB_USER");
                }

                return _userName;
            }
        }

        private static string MONGODB_PASSWORD
        {
            get
            {
                if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("MONGODB_PASSWORD")))
                {
                    return Environment.GetEnvironmentVariable("MONGODB_PASSWORD");
                }

                return _password;
            }
        }

        internal static string MONGODB_DATABASE
        {
            get
            {
                if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("MONGODB_DATABASE")))
                {
                    return Environment.GetEnvironmentVariable("MONGODB_DATABASE");
                }

                return _defaultDB;
            }
        }
    }
}