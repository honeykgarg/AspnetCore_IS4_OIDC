// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace Identity.Server
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResource(
                    "country",
                    "The country you're living in",
                    new List<string>() { "country" }),
                new IdentityResource(
                    "roles",
                    "The country you're living in",
                    new List<string>() { "role" }),
            };

        public static IEnumerable<ApiResource> Apis =>
            new ApiResource[]
            {
                new ApiResource(
                    "searchvehicleapi",
                    "Search Vehicle API"
                    )
                    {
                        Scopes = { "searchvehicle.findbymake" }
                    }

            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            { 
                new ApiScope("searchvehicle.findbyvrn"),
                new ApiScope("searchvehicle.findbymake"),
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
                {
                new Client
                {
                    ClientId = "mvc",
                    ClientSecrets = {
                            new Secret("secret".Sha256())
                            },

                    AllowedGrantTypes = GrantTypes.Code,

                    // where to redirect to after login
                    //RedirectUris = { "https://localhost:44317/signin-oidc" },
                    RedirectUris = { "https://localhost:44317/Home/Privacy" },

                    // where to redirect to after logout
                    PostLogoutRedirectUris = { "https://localhost:44317/signout-callback-oidc" },

                   

                    AllowedScopes = new List<string>
                        {
                            IdentityServerConstants.StandardScopes.OpenId,
                            IdentityServerConstants.StandardScopes.Profile,
                            "country",
                            "searchvehicle.findbyvrn",
                            "roles"
                        }
                    },
                new Client
                {
                    ClientId="consoleApp",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = {
                            new Secret("consolesecret".Sha256())
                            },
                     AllowedScopes = new List<string>
                     {
                          "searchvehicle.findbymake",
                     }
                }
                };
    }
}