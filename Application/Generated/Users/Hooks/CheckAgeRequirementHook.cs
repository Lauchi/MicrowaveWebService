//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Domain.Posts;

namespace Application.Users.Hooks
{
    using System;
    using Domain.Users;
    using Domain;
    
    
    public partial class CheckAgeRequirementHook : IChildHook
    {
        public IUserRepository Repository { get; }

        CheckAgeRequirementHook(IUserRepository repository)
        {
            Repository = repository;
        }
        
        public Type EventType { get; private set; } = typeof(UserCreateEvent);
        
        public HookResult ExecuteChildHook(DomainEventBase domainEvent, User parent)
        {
            if (domainEvent is PostUpdateTitleEvent casted)
            {
                var domainResult = parent.CheckAgeRequirement_OnPostUpdateTitle(casted);
                if (domainResult.Ok)
                {
                    return HookResult.OkResult();
                }
                return HookResult.ErrorResult(domainResult.DomainErrors);
            }
            throw new Exception("Event is not in the correct list");
        }
    }

    public interface IChildHook
    {
        HookResult ExecuteChildHook(DomainEventBase domainEvent, User parent);
    }
}