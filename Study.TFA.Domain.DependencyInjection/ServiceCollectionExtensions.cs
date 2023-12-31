﻿using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Study.TFA.Domain.Authentication;
using Study.TFA.Domain.Authorization;
using Study.TFA.Domain.UseCases.CreateForum;
using Study.TFA.Domain.UseCases.CreateTopic;
using Study.TFA.Domain.UseCases.GetForums;
using Study.TFA.Domain.UseCases.GetTopics;
using Study.TFA.Domain.UseCases.SignIn;
using Study.TFA.Domain.UseCases.SignOn;

namespace Study.TFA.Domain.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddForumDomain(this IServiceCollection services)
        {
            services
                .AddScoped<ICreateForumUseCase, CreateForumUseCase>()
                .AddScoped<IIntentionResolver, ForumIntentionResolver>()
                .AddScoped<IGetForumsUseCase, GetForumsUseCase>()
                .AddScoped<ICreateForumUseCase, CreateForumUseCase>()
                .AddScoped<ICreateTopicUseCase, CreateTopicUseCase>()
                .AddScoped<IGetTopicsUseCase, GetTopicsUseCase>()
                .AddScoped<ISignInUseCase, SignInUseCase>()
                .AddScoped<ISignOnUseCase, SignOnUseCase>()
                .AddScoped<IIntentionResolver, TopicIntentionResolver>();

            services
                .AddScoped<IIntentionManager, IntentionManager>()
                .AddScoped<IIdentityProvider, IdentityProvider>()
                .AddScoped<IPasswordManager, PasswordManager>()
                .AddScoped<IAuthenticationService, AuthenticationService>()
                .AddScoped<ISymmetricDecryptor, AesSymmetricEncryptorDecryptor>()
                .AddScoped<ISymmetricEncryptor, AesSymmetricEncryptorDecryptor>();

            services
                .AddValidatorsFromAssemblyContaining<Models.Forum>(includeInternalTypes: true);

            return services;
        }
    }
}
