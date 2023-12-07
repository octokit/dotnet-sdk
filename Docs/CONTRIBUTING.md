# How to Contribute

NOTE: This SDK is currently in ALPHA and should be considered **unstable**

Contributions take many forms from submitting issues, writing docs, to making
code changes - we welcome it all!

## Getting Started

`git clone https://github.com/octokit/dotnet-sdk.git dotnet-sdk`

## How can I get involved?

We have an [`Status: Up for grabs`](https://github.com/octokit/dotnet-sdk/labels/Status%3A%20Up%20for%20grabs)
tag on our issue tracker to indicate tasks which contributors can pick up.

If you've found something you'd like to contribute to, leave a comment in the issue
so everyone is aware.

NOTE: Everything under the `GitHub\Octokit` folder is 100% generated and should never be manually changed.

## Making Changes

When you're ready to make a change, create a branch off the `main` branch:

```
git checkout main
git pull origin main
git checkout -b SOME-BRANCH-NAME
```

We use `main` as the default branch for the repository, and it holds the most
recent contributions. By working in a branch away from `main` you can handle
potential conflicts that may occur in the future.

If you make focused commits (instead of one monolithic commit) and have descriptive
commit messages, this will help speed up the review process.

### Submitting Changes

You can publish your branch from GitHub for Windows, or run this command from
the Git Shell:

`git push origin MY-BRANCH-NAME`

Once your changes are ready to be reviewed, publish the branch to GitHub and
[open a pull request](https://help.github.com/articles/using-pull-requests)
against it.

A few suggestions when opening a pull request:

 - if you are addressing a particular issue, reference it like this:

>   Fixes #1145

 - Open a DRAFT PR indicate this is a work-in-progress. It's
   always good to get feedback early, so don't be afraid to open the PR before
   it's "done".
 - add comments to the PR about things that are unclear or you would like
   suggestions on

Some things that will increase the chance that your pull request is accepted:

* Follow existing code conventions. Most of what we do follows [standard .NET
  conventions](https://github.com/dotnet/corefx/blob/master/Documentation/coding-guidelines/coding-style.md) except in a few places.
* Include unit tests that would otherwise fail without your code, but pass with
  it.
* Update the documentation, the surrounding one, examples elsewhere, guides,
  whatever is affected by your contribution

# Additional Resources

* [General GitHub documentation](http://help.github.com/)
