Custom permissions are implemented in a permissions.cs file.
In this file we'll implement the *IPermissionProvider* interface.
The definition is a 3 step process, define the permission, return a list of Permissions used in the Module, and the last step is to map the permissions to the build in roles in Orchard.

# Creating a Custom Permissions

    using System.Collections.Generic;
    using Orchard.Environment.Extensions.Models;
    using Orchard.Security.Permissions;

    namespace Orchard.Comments {
    public class Permissions : IPermissionProvider {
        public static readonly Permission AddComment = new Permission { Description = "Add comment", Name = "AddComment" };
        public static readonly Permission ManageComments = new Permission { Description = "Manage comments", Name = "ManageComments" };

        public virtual Feature Feature { get; set; }

        public IEnumerable<Permission> GetPermissions() {
            return new[] {
                AddComment,
                ManageComments,
            };
        }

        public IEnumerable<PermissionStereotype> GetDefaultStereotypes() {
            return new[] {
                new PermissionStereotype {
                    Name = "Administrator",
                    Permissions = new[] {ManageComments, AddComment}
                },
                new PermissionStereotype {
                    Name = "Anonymous",
                    Permissions = new[] {AddComment}
                },
                new PermissionStereotype {
                    Name = "Authenticated",
                    Permissions = new[] {AddComment}
                },
                new PermissionStereotype {
                    Name = "Editor",
                    Permissions = new[] {AddComment}
                },
                new PermissionStereotype {
                    Name = "Moderator",
                    Permissions = new[] {ManageComments, AddComment}
                },
                new PermissionStereotype {
                    Name = "Author",
                    Permissions = new[] {AddComment}
                },
                new PermissionStereotype {
                    Name = "Contributor",
                    Permissions = new[] {AddComment}
                },
            };
        }
    }
    }


# Using Custom Permissions from Code 

From our controller (or any other location) we can call the *Services.Authorizer.Authorize* to check if the current user has the correct Permission. In this example, even the "anonymous" role has the permission to add comments(check the code above).

    if (!Services.Authorizer.Authorize(Permissions.AddComment, T("Couldn't add comment")))
        return new HttpUnauthorizedResult();
            