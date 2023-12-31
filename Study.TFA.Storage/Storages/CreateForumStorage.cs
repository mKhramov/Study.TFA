﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Study.TFA.Domain.UseCases.CreateForum;

namespace Study.TFA.Storage.Storages
{
    internal class CreateForumStorage : ICreateForumStorage
    {
        private readonly IMemoryCache memoryCache;
        private readonly IGuidFactory guidFactory;
        private readonly ForumDbContext dbContext;
        private readonly IMapper mapper;

        public CreateForumStorage(
            IMemoryCache memoryCache,
            IGuidFactory guidFactory,
            ForumDbContext dbContext,
            IMapper mapper)
        {
            this.memoryCache = memoryCache;
            this.guidFactory = guidFactory;
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<Domain.Models.Forum> Create(string title, CancellationToken cancellationToken)
        {
            var forumId = guidFactory.Create();

            var forum = new Forum()
            {
                Title = title,
                ForumId = forumId,
            };

            await dbContext.Forums.AddAsync(forum, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);

            memoryCache.Remove(nameof(GetForumsStorage.GetForums));

            return await dbContext.Forums
                .Where(t => t.ForumId == forumId)
                .ProjectTo<Domain.Models.Forum>(mapper.ConfigurationProvider)
                .FirstAsync(cancellationToken);
        }
    }
}
