# Azure Deployment Plan

## Status
Approved

## Goal
Create a GitHub Actions workflow that deploys BookManager to Azure App Service.

## Workspace Findings
- ASP.NET Core MVC application targeting .NET 10 (`net10.0`).
- SQLite database, initialized at startup.
- A multi-stage Dockerfile was added for .NET 10 and stores the database under `/data`.
- No GitHub Actions workflows or repository agent instructions were found.

## Proposed Approach
- Build the Docker image once, publish its commit-SHA and `staging` tags to GitHub Container Registry (GHCR), then deploy that image to the staging App Service.
- Smoke-test staging before promoting the same commit-SHA image to the GHCR `production` tag and deploying it to the production App Service.
- Add GitHub Actions environments named `staging` and `production`; configure required reviewers on `production` to gate the production deployment.
- Authenticate both Azure deployments using OIDC, with environment-scoped Azure credentials and resource names.
- Configure App Service GHCR pull credentials as GitHub environment secrets. Persist each environment's SQLite database under `/home` and keep each App Service at one instance.
- Trigger the workflow on pushes to `main` and manual dispatch.

## Assumptions Requiring Confirmation
- Separate Linux App Services for staging and production already exist.
- The production GitHub Environment is configured with required reviewers.
- Configure environment variables `AZURE_RESOURCE_GROUP` and `AZURE_WEBAPP_NAME` separately in the `staging` and `production` GitHub Environments.
- Configure environment secrets `AZURE_CLIENT_ID`, `AZURE_TENANT_ID`, `AZURE_SUBSCRIPTION_ID`, `GHCR_PULL_USERNAME`, and `GHCR_PULL_TOKEN` in both environments.
- Configure GitHub OIDC federated credentials for the `staging` and `production` environment subjects; scope each Azure identity to its target App Service.
- `GHCR_PULL_TOKEN` is a read-only package token that can pull the private GHCR image. The workflow's `GITHUB_TOKEN` has package write permission.
- Each App Service uses one instance because the application stores its data in SQLite.

## Out of Scope
- Creating Azure resources or provisioning infrastructure.
- Deploying to Azure from this session.
