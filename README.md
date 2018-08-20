# GraphQL with .NET back end PoC

A test project for understanding how to use GraphQL with a .NET back end. This repo is purely for learning purposes and should not be used as the foundation for any applications going forward.

For simplicity, the front end and back end are split into two separate projects that run on separate ports. Due to this, I have enabled CORS (any origin).

## Front end

Based on my [Webpack 4 scratch repo](https://github.com/jpreecedev/webpack-4-scratch), with a few additional packages to support using GraphQL with the Apollo client.

To run, change directory to `/frontend` and run `yarn start`. This will start a server listening on `https://localhost:8080`.

When the back end is running, click **Request some data** to trigger a `POST` request to the GraphQL endpoint. The result of the request will be displayed underneath the button.

## Back end

To run the back end, go to the `/backend` folder and open `BasketGraphQLAPI.sln` with Visual Studio 2015 or higher. When open, press `F5` to start the application running. The backend is based on an [example GraphQL/DotNet repo](https://github.com/graphql-dotnet/graphql-dotnet), with most of the fluff removed.
