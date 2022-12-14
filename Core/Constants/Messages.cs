using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Constants
{
    public static class Messages
    {
        public static string Added(string fieldName) => $"{fieldName} added successfully";
        public static string FailedAdd(string fieldName) => $"An error occured while adding {fieldName} ";
        public static string Listed(string fieldName) => $"{fieldName} listed successfully";
        public static string Updated(string fieldName) => $"{fieldName} updated successfully.";
        public static string FailedUpdate(string fieldName) => $"An error occured while updating {fieldName}";
        public static string Deleted(string fieldName) => $"{fieldName} deleted successfully.";
        public static string FailedDelete(string fieldName) => $"An error occured while deleting {fieldName}";
        public static string NotFound(string fieldName) => $"{fieldName} not found";
        public static string AuthorizationFailed() => $"Authorization failed for action";
        public static string UserRegisteredSuccessfully() => $"Registered Successfully";
        public static string UserLoggedInSuccessfully() => $"Logged in Successfully";
        public static string UserAlreadyExists() => $"User already exists";
        public static string AccessTokenCreated() => $"Access Token Created";
        public static string LoginFailed() => $"Username or password is wrong";
        public static string RoleAddedToUser() => $"Role added to user";
        public static string ErrorRoleAddedToUser() => $"An error occured while adding role to user";
    }
}
