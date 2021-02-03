# AspnetCore_IS4_OIDC
Implemented OIDC with Identity Server to manage MVC application and API Resource

This solution has 4 different projects - 

1. Identity.Server - which is an instance of Indentity Server 4 that manages the idenity for our MVC and Vehicle Search API using the OIDC Protocol.
2. MVCClient - This is an MVC application built using Asp.net Core 3.1 MVC and using Identity Server for managing the identities of the users.
3. Vehicle.Search.Api - This is an Api resource that is secured using the Identity Server. Any user needs to 
