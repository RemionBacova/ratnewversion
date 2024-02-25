
namespace RatServer.Global.Constants
{
    public static class RoleConstants
    {
        public const string AllRoles = "SuperUser,SystemUser,RetailerAdmin,RetailerUser,Client,PoolManager";
        public const string ClientAndInternal = "SuperUser,SystemUser,Client";
        public const string RetailerAndInternal = "SuperUser,SystemUser,RetailerAdmin,RetailerUser,PoolManager";
        public const string RetailerManagementAndInternal = "SuperUser,SystemUser,RetailerAdmin,PoolManager";
        public const string Client = "Client";
        public const string Retailer = "RetailerAdmin,RetailerUser";
        public const string RetailerAdmin = "RetailerAdmin";
        public const string RetailerAdminAndPoolManager = "RetailerAdmin,PoolManager";
        public const string Internal = "SuperUser,SystemUser";
        public const string SuperUser = "SuperUser";


    }
}