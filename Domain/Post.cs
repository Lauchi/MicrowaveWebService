﻿using System;
using System.Collections.Generic;

namespace Domain.Posts
{
    public partial class Post
    {
        public static CreationResult<Post> Create(PostCreateCommand command)
        {
            var newGuid = Guid.NewGuid();
            var post = new Post(newGuid, command.Title);
            var createEvent = new PostCreateEvent(post, newGuid);
            var domainEventBases = new List<DomainEventBase>();
            domainEventBases.Add(createEvent);
            return CreationResult<Post>.OkResult(domainEventBases, post);
        }
    }
}