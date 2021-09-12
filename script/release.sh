#!/bin/sh

set -ue

update_package_json() {
  package_json_file=$1
  version=$2

  dependency_content="$(cat "$package_json_file" | jq '. | select(.dependencies["me.mattak.unityhooks"] != null)')"

  if [ "$dependency_content" != "" ]; then
    cat "$package_json_file" |
      jq --arg version "$version" '.version = $version | .dependencies["me.mattak.unityhooks"] = $version' > /tmp/package.json
  else
    cat "$package_json_file" |
      jq --arg version "$version" '.version = $version' > /tmp/package.json
  fi

  mv /tmp/package.json "$package_json_file"
}

if [ $# -lt 1 ]; then
  cat << __USAGE__
Usage: $0 <version>
Example:
  $0 0.4.2
__USAGE__

  exit 1
fi

VERSION=$1

if [ "$(git status --short | wc -l | awk '{print $1}')" != "0" ]; then
  echo "ERROR: git status is not clean. Please commit or clean files"
  exit 1
fi

if git tag | grep "$VERSION" > /dev/null; then
  echo "ERROR: already exists version tag $VERSION"
  exit 1
fi

for package_json_file in $(find Assets -type f -name 'package.json' | grep Assets/UnityHooks)
do
  update_package_json "$package_json_file" "$VERSION"
  git add "$package_json_file"
done

git commit -m ":up: Bump up $VERSION"
git tag $VERSION
git push origin master
git push origin master --tags

