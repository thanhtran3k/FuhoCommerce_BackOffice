using System;
using System.Collections;
using System.Collections.Generic;
using IdentityServer4.Models;

namespace FuhoCommerce.Persistence.Constants
{
    public class IdentityConfigurations
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile(),
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("fuhocommerceapi", "FuhoCommerce API")
                {
                    Scopes = { 
                        new Scope() { 
                            Name = "api.read", 
                            DisplayName = "API Auditor",
                            UserClaims = new List<string>() { Roles.Consumer }
                        }, 
                        //new Scope("api.write")
                        new Scope()
                        {
                            Name = "api.write",
                            DisplayName = "Api modifier",
                            UserClaims = new List<string>() { Roles.Buyer, Roles.Supplier }
                        }
                    }
                }
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new[]
            {
                new Client {
                    RequireConsent = false,
                    ClientId = "angular_spa",
                    ClientName = "Angular SPA",
                    Description = "Fuho Angular Client",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowedScopes = { "openid", "profile", "email", "api.read", "api.write" },
                    RedirectUris = {"http://localhost:4200/auth-callback"},
                    PostLogoutRedirectUris = {"http://localhost:4200/"},
                    AllowedCorsOrigins = {"http://localhost:4200"},
                    AllowAccessTokensViaBrowser = true,
                    AccessTokenLifetime = 3600
                },

                //Hybrid Client needs ClientSecret, offline_access, scope, ResponseType = code id_token
                new Client {
                    RequireConsent = false,
                    ClientId = "fuhocommerce_frontoffice",
                    ClientName = "FuhoCommerce FrontOffice",
                    Description = "Fuho MVC Client",
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedGrantTypes = GrantTypes.HybridAndClientCredentials,
                    AllowedScopes = { "openid", "profile", "email", "api.read", "api.write" },
                    RedirectUris = {"https://localhost:5002/signin-oidc"},
                    PostLogoutRedirectUris = {"https://localhost:5002/signout-callback-oidc"},
                    AllowOfflineAccess = true,
                    AllowAccessTokensViaBrowser = true,
                    AccessTokenLifetime = 3600,
                },
            };
        }
    }
}
