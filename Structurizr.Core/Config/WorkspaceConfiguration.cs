using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Structurizr.Documentation;

namespace Structurizr.Config
{
    
    [DataContract]
    public sealed class WorkspaceConfiguration
    {
    
        [DataMember(Name = "users", EmitDefaultValue = false)]
        public ISet<User> Users { get; internal set; }

        [JsonConstructor]
        internal WorkspaceConfiguration()
        {
            Users = new HashSet<User>();
        }
        
        public void AddUser(string username, Role role)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentException("A username must be specified.");
            }

            Users.Add(new User(username, role));
        }
   
    }
    
}