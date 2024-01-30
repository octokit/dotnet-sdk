#!/usr/bin/env bash

# GitHub Actions performs linting in .github/workflows/build.yml.
# This script may be used to update files before pushing to a PR check.
dotnet format
