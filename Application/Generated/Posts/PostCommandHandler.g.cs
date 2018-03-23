//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Application.Posts
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Domain;
    using Domain.Posts;
    using Microsoft.AspNetCore.Mvc;
    
    
    public partial class PostCommandHandler
    {
        
        public IEventStore EventStore { get; private set; }
        
        public IPostRepository PostRepository { get; private set; }
        
        public PostCommandHandler(IEventStore EventStore, IPostRepository PostRepository)
        {
            this.EventStore = EventStore;
            this.PostRepository = PostRepository;
        }
        
        public async Task<IActionResult> GetPosts()
        {
            var listResult = await PostRepository.GetPosts();
            return new OkObjectResult(listResult);
        }
        
        public async Task<IActionResult> GetPost(Guid id)
        {
            var result = await PostRepository.GetPost(id);
            if (result != null) return new JsonResult(result);
            return new NotFoundObjectResult(new List<string> { $"Could not find Root Post with ID: {id}" });
        }
        
        public async Task<IActionResult> CreatePost(PostCreateCommand command)
        {
            CreationResult<Post> createResult = Post.Create(command);
            if (createResult.Ok)
            {
                var hookResult = await EventStore.AppendAll(createResult.DomainEvents);
                if (hookResult.Ok)
                {
                    await PostRepository.CreatePost(createResult.CreatedEntity);
                    return new CreatedResult("uri", createResult.CreatedEntity);
                }
                return new BadRequestObjectResult(hookResult.Errors);
            }
            return new BadRequestObjectResult(createResult.DomainErrors);
        }
    }
}
