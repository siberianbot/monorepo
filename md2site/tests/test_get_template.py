import unittest
import src.md2site as md2site
import io

from unittest.mock import patch, MagicMock


class test_get_template(unittest.TestCase):
  def test_without_template_file(self):
    actual_result = md2site.get_template({})
    expected_result = md2site.defaults["template"]

    self.assertEquals(expected_result, actual_result)

  @patch("src.md2site.open")
  @patch("os.path.isfile")
  def test_with_template_file(self, mock_isfile: MagicMock, mock_open: MagicMock):
    template_file = "A template file mock"
    template_file_path = "foo/bar"
    options = {
        "template_file": template_file_path
    }

    mock_isfile.return_value = True
    mock_open.return_value = io.StringIO(template_file)

    result = md2site.get_template(options)

    self.assertEqual(template_file, result)

  @patch("os.path.isfile")
  def test_with_unknown_template_file(self, mock_isfile: MagicMock):
    template_file_path = "foo/bar"
    options = {
        "template_file": template_file_path
    }

    mock_isfile.return_value = False

    result = md2site.get_template(options)

    self.assertEqual(md2site.defaults["template"], result)
