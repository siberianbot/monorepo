import os.path
import pathlib
import sys
import markdown
import chevron
import re

defaults: dict = {
    "primary_lang": "en",
    "output_ext": "html",
    "output_directory": None,
    "template": """
<!DOCTYPE html>
<html>
  <head>
    <title>{{ title }}</title>
  </head>
  <body>
    {{{ content }}}
  </body>
</html>
""",
    "template_file": None,
    "title_separator": "/"
}


def get_option(options: dict, name: str) -> object:
  from_options = options.get(name) if options else None
  return from_options if from_options else defaults.get(name)


def parse_filename(filename: str) -> dict:
  if not filename:
    raise ValueError("empty filename is provided")

  split = filename.split(".")
  split_len = len(split)

  if split_len < 2:
    raise ValueError("invalid filename: {}".format(filename))

  have_lang = split_len > 2 and split[-2]
  filename_len = split_len - (2 if have_lang else 1) if split_len > 2 else 1

  result = {
      "filename": ".".join(split[0:filename_len]),
      "ext": split[-1],
      "lang": split[-2] if have_lang else None
  }

  if not result["filename"]:
    raise ValueError(
        "provided filename does not contains filename: {}".format(filename))

  if not result["ext"]:
    raise ValueError(
        "provided filename does not contains extension: {}".format(filename))

  return result


def build_filename(name: str, lang: str, options: dict) -> str:
  output_ext = get_option(options, "output_ext")
  primary_lang = get_option(options, "primary_lang")

  items = [name, lang, output_ext] if lang and lang != primary_lang else [
      name, output_ext]

  return ".".join(items)


def build_title(name: str, lang: str, path: pathlib.PurePath, root: pathlib.PurePath, options: dict) -> str:
  relative_path = path.relative_to(root)

  items = [p.name for p in relative_path.parents]
  items.reverse()

  if len(items) == 0:
    items.append("")

  if lang and lang != get_option(options, "primary_lang"):
    items.append("{}.{}".format(name, lang))
  else:
    items.append(name)

  separator: str = get_option(options, "title_separator")

  return separator.join(items)


def build_output_path(input_path: pathlib.Path, root_path: pathlib.PurePath, target_root_path: pathlib.PurePath) -> pathlib.PurePath:
  if target_root_path and not root_path:
    return target_root_path

  if target_root_path and root_path:
    relative_path = input_path.relative_to(root_path)
    return target_root_path / relative_path

  return input_path


def get_template(options: dict) -> str:
  template_file_path = get_option(options, "template_file")
  if template_file_path and os.path.isfile(template_file_path):
    with open(template_file_path, "r", encoding="utf8") as template_file:
      return template_file.read()
  else:
    return get_option(options, "template")


def render_file(src_path: pathlib.PurePath, dest_path: pathlib.Path, title: str, options: dict):
  template = get_template(options)
  src_content = None

  with open(src_path, "r", encoding="utf8") as src_content_file:
    src_content = src_content_file.read()

  data = {
      "title": title,
      "content": markdown.markdown(src_content)
  }

  if not dest_path.parent.exists():
    dest_path.parent.mkdir()

  with open(dest_path, "w", encoding="utf8") as dest:
    dest.write(chevron.render(template, data))


def process_file(input_path: pathlib.PurePath, root_path: pathlib.PurePath, options: dict):
  filename_data = parse_filename(input_path.name)
  filename = filename_data["filename"]
  lang = filename_data["lang"]

  title = build_title(filename, lang, input_path,
                      root_path if root_path else input_path.parent, options)

  output_filename = build_filename(filename, lang, options)
  output_file_path = build_output_path(input_path.parent, root_path, get_option(
      options, "output_directory")) / output_filename

  render_file(input_path, output_file_path, title, options)


def process_dir(input_path: pathlib.Path, options: dict):
  for x in input_path.glob("**/*.md"):
    process_file(x, input_path, options)


def process_option_arg(arg: str) -> str:
  if arg == "--primary-lang":
    return "primary_lang"
  elif arg == "--output-ext":
    return "output_ext"
  elif arg == "--template-file":
    return "template_file"
  elif arg == "--output-directory":
    return "output_directory"
  else:
    None


def process_option_value(name: str, arg: str, options: dict):
  if name == "primary_lang" and not re.match("[a-zA-Z]+", arg):
    raise ValueError("primary language does not match to regex \"[a-zA-Z]+\"")
  elif name == "output_ext" and not re.match("[a-zA-Z0-9]+", arg):
    raise ValueError(
        "output extension does not match to regex \"[a-zA-Z0-9]+\"")
  elif name == "template_file" and not os.path.isfile(arg):
    raise ValueError("path to template file is invalid")

  options[name] = arg


def process_args(args: list) -> (list[pathlib.Path], dict):
  current_option = None
  options: dict = {}
  paths: list[pathlib.Path] = []

  for arg in args:
    option = process_option_arg(arg)

    if option != None:
      current_option = option
    elif current_option != None:
      process_option_value(current_option, arg, options)
      current_option = None
    else:
      if not os.path.isdir(arg) and not os.path.isfile(arg):
        raise ValueError("provided path is invalid: {}".format(arg))
      paths.append(pathlib.Path(arg))

  return (paths, options)


def usage():
  usage = """
  usage:
  md2site --primary-lang [ln] --output-ext [ext] --output-directory [path] --template-file [path] <files... | directories...>

  --primary-lang [ln]       defines primary language of site (default: en);
  --output-ext [ext]        defines output extension (default: html);
  --output-directory [path] defines path to output directory;
  --template-file [path]    defines template file, otherwise uses default template.
  """

  print(usage)


def main():
  if len(sys.argv) < 2:
    usage()
    return

  paths, options = process_args(sys.argv[1:])

  for path in paths:
    if path.is_file():
      process_file(path, None, options)
    elif path.is_dir():
      process_dir(path, options)
    else:
      print("invalid path: ", path)


if __name__ == "__main__":
  main()
