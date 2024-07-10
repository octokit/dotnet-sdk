Currently for this CLI (or any other) to use GitHubs App Installation Auth you need a private key that can be used to create a Json Web Token.

You should be able to follow the steps [here](https://docs.github.com/en/apps/creating-github-apps/authenticating-with-a-github-app/managing-private-keys-for-github-apps) to generate a private key for the cli to use during app installation auth. `.gitignore` will ignore any .pem files that are in this directory to prevent anyone from accidentally commiting a private key.
