# SophiChain ABP Metronic Theme

## About this solution

This repository contains **SophiChain ABP Metronic Theme modules** for the ABP Framework, along with **demo applications** for testing and developing these themes.

### Project Structure

- **`modules/`** - Contains the actual ABP theme modules that can be distributed as NuGet packages:
  - `SophiChain.Abp.AspNetCore.Components.Server.MetronicTheme` - Blazor Server theme
  - `SophiChain.Abp.AspNetCore.Components.Web.MetronicTheme` - Blazor Web theme  
  - `SophiChain.Abp.AspNetCore.Components.WebAssembly.MetronicTheme` - Blazor WebAssembly theme
  - `SophiChain.Abp.AspNetCore.Mvc.UI.Theme.Metronic` - MVC theme
  - Additional bundling and installer modules

- **Demo Applications** - Used for testing and developing the theme modules:
  - `SophiChainThemeDemo/` - Main demo application showcasing the themes
  - `SophiChainThemeDemo.Client/` - Client-side demo components
  - `SophiChainThemeDemo.Contracts/` - Shared contracts for demo

> **Note**: The demo applications are **development tools** designed to test and showcase the theme modules. They are not production applications but rather serve as a testing environment for theme development and integration.

### Pre-requirements

* [.NET9.0+ SDK](https://dotnet.microsoft.com/download/dotnet)
* [Node v18 or 20](https://nodejs.org/en)

## Before running the application

### Generating a Signing Certificate

In the production environment, you need to use a production signing certificate. ABP Framework sets up signing and encryption certificates in your application and expects an `openiddict.pfx` file in your application.

This certificate is already generated when you created the solution, so most of the time you don't need to generate it yourself. However, if you need to generate a certificate, you can use the following command:

```bash
dotnet dev-certs https -v -ep openiddict.pfx -p ed3e9037-5a98-41ed-a328-450cd4d14230
```

> `ed3e9037-5a98-41ed-a328-450cd4d14230` is the password of the certificate, you can change it to any password you want.

It is recommended to use **two** RSA certificates, distinct from the certificate(s) used for HTTPS: one for encryption, one for signing.

For more information, please refer to: [OpenIddict Certificate Configuration](https://documentation.openiddict.com/configuration/encryption-and-signing-credentials.html#registering-a-certificate-recommended-for-production-ready-scenarios)

> Also, see the [Configuring OpenIddict](https://abp.io/docs/latest/Deployment/Configuring-OpenIddict#production-environment) documentation for more information.

### Install Client-Side libraries

Run the following command in your solution directory. This step is automatically done when you create a new solution, if you didn't especially disabled it. However, you should run it yourself if you have first cloned this solution from your source control, or added a new client-side package dependency to your solution.

```bash
abp install-libs
```

> This command installs all NPM packages for MVC/Razor Pages and Blazor Server UIs and this command is already run by the ABP CLI, so most of the time you don't need to run this command manually.

## How to run the demo application

The demo application is used to test and develop the theme modules. It needs a database to run properly.

### Setting up the demo database

Run the following command in the [SophiChainThemeDemo](./SophiChainThemeDemo) project directory to migrate the database and seed the initial data:

````bash
dotnet run --migrate-database
````

### Running the demo

After database setup, you can run the demo application with any IDE that supports .NET, or use:

````bash
dotnet run
````

The demo application will showcase the Metronic theme modules and provide a development environment for testing theme changes.

### Development workflow

When developing theme modules:
1. Make changes to files in the `modules/` directory
2. The demo application will automatically reflect changes due to physical file replacement in development mode
3. Test your changes in the running demo application
4. Package the modules when ready for distribution

Happy coding..!

## Using the theme modules in your application

To use these Metronic theme modules in your own ABP application:

1. **Install the NuGet packages** (when available):
   ```bash
   abp add-package SophiChain.Abp.AspNetCore.Components.Web.MetronicTheme
   # or other theme modules as needed
   ```

2. **Add module dependencies** to your application module:
   ```csharp
   [DependsOn(typeof(SophiChainAbpAspNetCoreComponentsWebMetronicThemeModule))]
   public class YourApplicationModule : AbpModule
   {
       // ...
   }
   ```

3. **Configure the theme** in your application as needed.

For detailed integration instructions, refer to the specific module documentation or examine the demo application's configuration.

## Deploying the demo application

The demo application can be deployed like any standard ABP application for testing purposes. For production applications using these theme modules, refer to ABP's [deployment documentation](https://abp.io/docs/latest/Deployment/Index).

> **Important**: This deployment guide is for the demo application only. For production applications, you would typically install the theme modules as NuGet packages rather than deploying this entire repository.

### How to deploy on Docker

The application provides the related `Dockerfiles` and `docker-compose` file with scripts. You can build the docker images and run them using docker-compose. The necessary database, DbMigrator, and the application will be running on docker with health checks in an isolated docker network.

#### Creating the Docker images

Navigate to [etc/build](./etc/build) folder and run the `build-images-locally.ps1` script. You can examine the script to set **image tag** for your images. It is `latest` by default.

#### Running the Docker images using Docker-Compose

Navigate to [etc/docker](./etc/docker) folder and run the `run-docker.ps1` script. The script will generate developer certificates (if it doesn't exist already) with `dotnet dev-certs` command to use HTTPS. Then, the script runs the provided docker-compose file on detached mode.

> Not: Developer certificate is only valid for **localhost** domain. If you want to deploy to a real DNS in a production environment, use LetsEncrypt or similar tools.

#### Stopping the Docker containers

Navigate to [etc/docker](./etc/docker) folder and run the `stop-docker.ps1` script. The script stops and removes the running containers.

### Additional resources

You can see the following resources to learn more about ABP Framework themes and this solution:

* [ABP Theming Documentation](https://abp.io/docs/latest/UI/AspNetCore/Theming)
* [ABP Blazor UI Theming](https://abp.io/docs/latest/UI/Blazor/Theming)
* [ABP Module Development](https://abp.io/docs/latest/Module-Development-Basics)
* [Application (Single Layer) Startup Template](https://abp.io/docs/latest/startup-templates/application-single-layer/index)
* [Metronic Theme Official Documentation](https://keenthemes.com/metronic)
