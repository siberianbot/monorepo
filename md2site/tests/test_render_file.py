import unittest
from unittest.mock import patch, MagicMock, mock_open
import io
import src.md2site as md2site
import pathlib
import chevron
import markdown


class test_render_file(unittest.TestCase):
  def test_success(self):
    template = "{{ title }}: {{ content }}"
    content = "test content"
    title = "test title"
    options = {
        "template": template
    }
    test_render = chevron.render(template, {
        "title": title,
        "content": markdown.markdown(content)
    })

    input = io.StringIO(content)
    output = mock_open()

    def open_fn(path, mode, encoding):
      if mode == "r":
        return input
      elif mode == "w":
        return output()
      else:
        raise NotImplementedError()

    with patch("src.md2site.open", new=open_fn):
      md2site.render_file(pathlib.PurePath("src_path"), pathlib.Path("dest_path"), title, options)

    output().write.assert_called_with(test_render)
